using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InStudyAsp.Controllers.User.Teacher
{
    public class TestTeacherController : Controller
    {
        // GET: TestTeacher
        public ActionResult Index()
        {
            return View("../User/Teacher/TestTeacher");
        }
    }
}