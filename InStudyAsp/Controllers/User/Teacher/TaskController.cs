using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace InStudyAsp.Controllers.User.Teacher
{
    public class TaskController : Controller
    {
        // GET: Task
        // TODO: How to get current user
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}