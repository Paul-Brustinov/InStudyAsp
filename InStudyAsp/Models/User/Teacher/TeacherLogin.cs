using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using FluentValidation;

namespace InStudyAsp.Models.User.Teacher
{

    /*************************************************************************************//**
    * \brief ViewModel for Login view
    *****************************************************************************************/
    [FluentValidation.Attributes.Validator(typeof(TeacherLogin))]
    public class TeacherLogin
    {
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }


    /*************************************************************************************//**
    * \brief Login validator
    *****************************************************************************************/
    class TeacherLoginValidator : AbstractValidator<TeacherLogin>
    {

        /*************************************************************************************//**
        * \brief Login validatation rules
        *****************************************************************************************/
        public TeacherLoginValidator()
        {
            RuleFor(x => x.Phone).NotNull().Length(4, 20);
            RuleFor(x => x.Password).NotNull().Length(6, 20);
            RuleFor(x => x.RememberMe).NotNull();
        }

    }
}