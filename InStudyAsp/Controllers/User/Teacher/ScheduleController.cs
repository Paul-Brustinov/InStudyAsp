using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EFOracle.Model;
using InStudyAsp.Models.User.Teacher;
using Newtonsoft.Json;
using Repo;
using Repo.Common;

namespace InStudyAsp.Controllers.User.Teacher
{

    /*************************************************************************************//**
    * \ScheduleController contains CRUD actions for SCHEDULES
    *****************************************************************************************/
    public class ScheduleController : Controller
    {
        private IGenericRepository<TEACHER> teachers;
        private IGenericRepository<GROUP> groups;
        private IGenericRepository<SCHEDULE> schedules;
        private IGenericRepository<DISCIPLINE> disciplines;
        private TEACHER teacher;

        /************************************************************************************//**
        * \brief  CTOR for Ninject, and get current Teacher from System.Web.HttpContext
        *****************************************************************************************/
        public ScheduleController(IGenericRepository<TEACHER> _teachers, IGenericRepository<GROUP> _groups, ScheduleRepository _schedules, IGenericRepository<DISCIPLINE> _disciplines)
        {
            teachers = _teachers;
            groups = _groups;
            schedules = _schedules;
            disciplines = _disciplines;
            teacher = teachers.FindBy(x => x.USER_PHONE == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
        }



        /************************************************************************************//**
        * \brief  Task\Index returns List of Schedules for current user(teacher)
        *****************************************************************************************/
        [Authorize]
        public ActionResult Index()
        {
            // Getting identity
 
            List<SCHEDULE> teacherSchedules;
            using (EFOracle.Model.dbContext context = new EFOracle.Model.dbContext())
            {
                teacherSchedules = schedules.FindBy(x => x.TEACHER_ID == teacher.TEACHER_ID).ToList();
                teacherSchedules.ForEach(x => { x.DISCIPLINE = context.DISCIPLINEs.FirstOrDefault(y=>y.DISCIPLINE_CODE==x.DISCIPLINE_CODE); });
                teacherSchedules.ForEach(x => { x.GROUP = context.GROUPs.FirstOrDefault(y => y.GROUP_CODE == x.GROUP_CODE); });
            }

            return View(teacherSchedules);
        }

        /*************************************************************************************//**
        * \brief  
        *****************************************************************************************/
        [Authorize]
        [HttpGet]
        public ActionResult New()
        {
            ViewModelSchedule model = new ViewModelSchedule(null, schedules, disciplines, groups);
            SCHEDULE schedule = model;

            string json = JsonConvert.SerializeObject(schedule, Formatting.Indented);


            ViewBag.DISCIPLINE_CODE = model.GetDiscipline;
            ViewBag.GROUP_CODE = model.GetGroup;
            ViewBag.BeforeID = json;
            return View("Edit", model);
        }

        /*************************************************************************************//**
        * \brief Saving data from new or existing SCHEDULE
        *****************************************************************************************/
        [Authorize]
        [HttpPost]
        public ActionResult EditPost(ViewModelSchedule _schedule)
        {
            if (!ModelState.IsValid) return RedirectToAction("EditGet");
            try
            {
                _schedule.TEACHER_ID = teacher.TEACHER_ID;
                SCHEDULE BeforeSchedule = JsonConvert.DeserializeObject<SCHEDULE>(_schedule.OldID); ;
                SCHEDULE Schedule = _schedule;

                _schedule.SCHEDULE_DATE = _schedule.GetDateTime();

                ViewModelSchedule.AddOrUpdate(BeforeSchedule, Schedule, schedules);
                schedules.Save();
                //return View("Index", repoGood.GetAll());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                if (e.InnerException?.InnerException != null) ViewBag.Message = e.InnerException.InnerException.Message;
                return RedirectToAction("EditGet");
            }
        }


        /*************************************************************************************//**
        * \brief Geting page to Edit SCHEDULE
        * There is using POST request to pass multiple params for multiple columns Primary Key
        *****************************************************************************************/
        [Authorize]
        [HttpPost]
        public ActionResult EditGet()
        {
            decimal teacherId = 0; decimal.TryParse(Request.Form["TeacherID"], out teacherId);
            decimal disciplineCode = 0; decimal.TryParse(Request.Form["DisciplineCode"], out disciplineCode);
            DateTime sDate;
            DateTime.TryParse(Request.Form["ScheduleDate"], out sDate);
            string groupCode = Request.Form["GroupCode"];

            SCHEDULE schedule = schedules.FindBy(
                x => x.TEACHER_ID == teacherId && 
                x.GROUP_CODE == groupCode &&
                x.DISCIPLINE_CODE == disciplineCode &&
                x.SCHEDULE_DATE == sDate
                ).FirstOrDefault();

            ViewModelSchedule model = new ViewModelSchedule(schedule, schedules, disciplines, groups);

            string json = JsonConvert.SerializeObject(schedule, Formatting.Indented);

            ViewBag.DISCIPLINE_CODE = model.GetDiscipline;
            ViewBag.GROUP_CODE = model.GetGroup;
            ViewBag.BeforeID = json;
            return View("Edit", model);
        }

        /*************************************************************************************//**
        * \brief Action to delete SCHEDULE
        *****************************************************************************************/
        [Authorize]
        [HttpPost]
        public ActionResult Delete()
        {
            decimal teacherId = 0; decimal.TryParse(Request.Form["TeacherID"], out teacherId);
            decimal disciplineCode = 0; decimal.TryParse(Request.Form["DisciplineCode"], out disciplineCode);
            DateTime sDate;
            DateTime.TryParse(Request.Form["ScheduleDate"], out sDate);
            string groupCode = Request.Form["GroupCode"];

            SCHEDULE schedule = schedules.FindBy(
                x => x.TEACHER_ID == teacherId &&
                x.GROUP_CODE == groupCode &&
                x.DISCIPLINE_CODE == disciplineCode &&
                x.SCHEDULE_DATE == sDate
                ).FirstOrDefault();



            schedules.Delete(schedule);
            schedules.Save();
            return RedirectToAction("Index");
        }
        //public ActionResult 
    }
}