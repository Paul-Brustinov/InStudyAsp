using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InStudyAsp.Controllers.User.Student
{
    public class TestStudentController : Controller
    {
        // GET: TestStudent
        public ActionResult Index()
        {
            return View("../User/Student/TestStudent");
        }
    }
}