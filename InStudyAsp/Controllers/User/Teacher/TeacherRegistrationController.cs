using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using System.Web.Security;
using EFOracle;
using InStudyAsp.Models.User.Teacher;
using Microsoft.Web.Mvc.Controls;

namespace InStudyAsp.Controllers.User.Teacher
{
    public class TeacherRegistrationController : Controller
    {
        /*!
        * Registration GET action
        */

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        /*!
        * Registration POST action
        */

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registration(
            [Bind(Exclude = "IsEmailVeryfied,ActivationCode")] TeacherRegistration teacherRegistration)
        {

            bool Status = false;
            string Message = "";

            if (!ModelState.IsValid)
            {
                ViewBag.Message = "ModelState is invalid!";
                ViewBag.Status = Status;
                return View(teacherRegistration);
            }


            //TODO: Findout why is this damned teacherRegistration.Avatar null
            // Файл почему-то не передается
            //using (MemoryStream memoryStream = new MemoryStream())
            //{
            //    teacherRegistration.Avatar.InputStream.CopyTo(memoryStream);
            //    using (FileStream file = new FileStream("file.bin", FileMode.Create, System.IO.FileAccess.Write))
            //    {
            //        byte[] bytes = new byte[memoryStream.Length];
            //        memoryStream.Read(bytes, 0, (int)memoryStream.Length);
            //        file.Write(bytes, 0, bytes.Length);
            //    }
            //}


            #region Phone is already exists

            if (teacherRegistration.PhoneExist())
            {
                ModelState.AddModelError("PhoneExist", "Phone already exists!");
                return View(teacherRegistration);
            }

            #endregion

            #region Save data to database

            teacherRegistration.ActivationCode = Guid.NewGuid().ToString();

            teacherRegistration.SaveToDatabase(new EFOracle.Model.dbContext());
            

            //Send Email to User
            //SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
            Message = "Registration successfully done.";
                //;" Account activation link has been send to you email id :" + user.EmailID;
            Status = true;

            var verifyUrl = "/TeacherRegistration/VerifyAccount/" + teacherRegistration.ActivationCode;
            var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
            new VerificationMailSender()
            {
                FromEmail = new MailAddress("ab.lern4@gmail.com", "Paul"),
                ToEmail = new MailAddress(teacherRegistration.Email),
                FromEmailPassword = "G@n1u$2017",
                Subject = "Your account is successfully created!",
                Body = "<br/> <br/> we are excited to tell you that your account is succsesfully created. Please click on the link to verify your account " +
                "<a href = " + link + ">" + link + "</a>",
                SmtpHost = "smtp.gmail.com",
                SmtpPort = 587
            }.SendVerificationLinkEmail();

            #endregion

            return View(teacherRegistration);
        }


        /*!
         * Vetify Account 
        */
        [HttpGet]
        public ActionResult VerifyAccount(string id)
        {
            bool status = false;

            using (EFOracle.Model.dbContext dbContext = new EFOracle.Model.dbContext())
            {
                dbContext.Configuration.ValidateOnSaveEnabled = false; //to avoid password does not match issue on save changes

                var UserSession = dbContext.USER_SESSION.FirstOrDefault(u => u.SESSION_HASH == id);
                if (UserSession != null)
                {
                    var user = dbContext.USERs.FirstOrDefault(u => u.USER_PHONE == UserSession.USER_PHONE_FK);
                    //TODO: Findout where IsEmailVerified must be persisted!
                    //user.IsEmailVerified = true;
                    //dbContext.SaveChanges();
                    status = true;
                }
                else
                {
                    ViewBag.Message = "Invalid Request";
                }
            }

            ViewBag.Status = status;

            return View();
        }


        //Login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        /*!
         * Process sended login data
         */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(TeacherLogin login, string returnUrl = "")
        {
            using (var dc = new EFOracle.Model.dbContext())
            {
                var user = dc.USERs.FirstOrDefault(u => u.USER_PHONE == login.Phone);
                if (user != null)
                {
                    var crPass = Convert.ToBase64String(System.Security.Cryptography.SHA256.Create().ComputeHash(Encoding.UTF8.GetBytes(login.Password)));

                    if (string.CompareOrdinal(crPass, user.USER_PASSWORD) == 0)
                    {
                        int timeout = login.RememberMe ? 525600 : 20; // 525600 == year
                        var ticket = new FormsAuthenticationTicket(login.Phone, login.RememberMe, timeout);
                        string encryped = FormsAuthentication.Encrypt(ticket);
                        var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryped)
                        {
                            Expires = DateTime.Now.AddMinutes(timeout),
                            HttpOnly = true
                        };
                        Response.Cookies.Add(cookie);

                        if (Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
                        return RedirectToAction("Index", "Home");
                    }
                }

            }
            ViewBag.Message = "Invalid credential provided";
            return View();
        }

        /*!
         *  Processing Logout
         * \return redurect to Action Login
         */
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "TeacherRegistration");
        }


    }
}