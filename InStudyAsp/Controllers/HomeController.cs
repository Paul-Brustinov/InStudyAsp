﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InStudyAsp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var dbContext = new EFOracle.Model1();
            var Teachers = dbContext.TEACHERs.ToList();

            return View(Teachers);
        }
    }
}