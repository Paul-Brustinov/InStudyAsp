using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;

namespace InStudyAsp.Models.User.Teacher
{

    [FluentValidation.Attributes.Validator(typeof(TeacherLogin))]
    public class TeacherLogin
    {
        [Display(Name = "Phone")]
        public string Phone { get; set; }
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }

    class TeacherLoginValidator : AbstractValidator<TeacherLogin>
    {
        public TeacherLoginValidator()
        {
            RuleFor(x => x.Phone).NotNull().Length(4, 20);
            RuleFor(x => x.Password).NotNull().Length(6, 20);
            RuleFor(x => x.RememberMe).NotNull();
        }

    }
}