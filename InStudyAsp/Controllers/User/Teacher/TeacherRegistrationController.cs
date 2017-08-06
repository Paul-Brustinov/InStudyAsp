using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFOracle;
using InStudyAsp.Models.User.Teacher;

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

            #region Phone is already exists

            if (teacherRegistration.PhoneExist())
            {
                ModelState.AddModelError("PhoneExist", "Phone already exists!");
                return View(teacherRegistration);
            }

            #endregion

            #region Save data to database

            teacherRegistration.SaveToDatabase(new EFOracle.Context());

            //user.ActivationCode = Guid.NewGuid(); //Generate activation code

            //teacherRegistration.HashPass();

            //teacherRegistration.IsEmailVerified = false;

            //using (var dbContext = new EFOracle.Context())
            //{
            //    dbContext.USERs.Add(new USER()
            //    {
            //        USER_PHONE = teacherRegistration.Phone,
            //        USER_PASSWORD = teacherRegistration.Password,
            //        USER_EMAIL = teacherRegistration.Email,
            //        USER_FIRSTNAME = teacherRegistration.Firstname,
            //        USER_LASTNAME = teacherRegistration.Lastname,
            //        USER_BIRTHDAY = teacherRegistration.Birthday,
            //    });

            //    dbContext.TEACHERs.Add(new TEACHER()
            //    {
            //        TEACHER_ID = dbContext.TEACHERs.Max(x => x.TEACHER_ID) + 1,
            //        USER_PHONE = teacherRegistration.Phone,
            //        TEACHER_START = teacherRegistration.Start,
            //    });

            //    try
            //    {
            //        // Your code...
            //        // Could also be before try if you know the exception occurs in SaveChanges

            //        dbContext.SaveChanges();
            //    }
            //    catch (DbEntityValidationException e)
            //    {
            //        foreach (var eve in e.EntityValidationErrors)
            //        {
            //            Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
            //                eve.Entry.Entity.GetType().Name, eve.Entry.State);
            //            foreach (var ve in eve.ValidationErrors)
            //            {
            //                Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
            //                    ve.PropertyName, ve.ErrorMessage);
            //            }
            //        }
            //        throw;
            //    }


            //}

            //Send Email to User
            //SendVerificationLinkEmail(user.EmailID, user.ActivationCode.ToString());
            Message = "Registration successfully done.";
                //;" Account activation link has been send to you email id :" + user.EmailID;
            Status = true;

            #endregion



            return View(teacherRegistration);
        }
    }
}