using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using EFOracle;
using EFOracle.Model;
using FluentValidation;
using InStudyAsp.Models.User.Teacher;

namespace InStudyAsp.Models.User.Teacher
{

    [FluentValidation.Attributes.Validator(typeof(TeacherValidator))]
    [MetadataType(typeof(TeacherMetadata))]
    public class TeacherRegistration
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public HttpPostedFileBase Avatar { get; set; }
        public DateTime Start { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string ActivationCode { get; set; }

        public bool PhoneExist()
        {
            var dbContext = new EFOracle.Model.dbContext();
            return dbContext.USERs.Find(Phone) != null;
        }

        private string Hash(string pass) =>
            Convert.ToBase64String(
                System.Security.Cryptography.SHA256.Create().
                    ComputeHash(Encoding.UTF8.GetBytes(Password)));

        public void HashPass()
        {
            Password = Hash(Password);
            ConfirmPassword = Password;
        }

        public void SaveToDatabase(EFOracle.Model.dbContext dbContext)
        {
            HashPass();

            dbContext.USERs.Add(new USER()
            {
                USER_PHONE = Phone,
                USER_PASSWORD = Password,
                USER_EMAIL = Email,
                USER_FIRSTNAME = Firstname,
                USER_LASTNAME = Lastname,
                USER_BIRTHDAY = Birthday,
            });

            dbContext.TEACHERs.Add(new TEACHER()
            {
                TEACHER_ID = dbContext.TEACHERs.Max(x => x.TEACHER_ID) + 1,
                USER_PHONE = Phone,
                TEACHER_START = Start,
            });

            dbContext.USER_SESSION.Add(new USER_SESSION()
            {
                USER_PHONE_FK = Phone,
                SESSION_DATETIME = DateTime.Now,
                SESSION_HASH = ActivationCode,
                SESSION_EXPIRE = DateTime.Now.AddDays(1)
            });

            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
        

    }

    public class TeacherMetadata
    {
        [Display(Name = "First name")]
        public string Firstname { get; set; }

        [Display(Name = "Last name")]
        public string Lastname { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Date of birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Birthday { get; set; }

        [Display(Name = "Avatar")]
        [Microsoft.Web.Mvc.FileExtensions(Extensions = "jpg",
             ErrorMessage = "Choose an image")]
        public HttpPostedFileBase Avatar { get; set; }


        [Display(Name = "Date of start position")]
        [DataType(DataType.Date)]
        public DateTime Start { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}

class TeacherValidator:AbstractValidator<TeacherRegistration>
{
    public TeacherValidator()
    {

        RuleFor(x => x.Firstname).NotNull().Length(4, 20);
        RuleFor(x => x.Lastname).NotNull().Length(4, 20);
        RuleFor(x => x.Phone).NotNull().Length(10, 20);
        RuleFor(x => x.ConfirmPassword).NotNull().Equal(x => x.Password);

    }

}
