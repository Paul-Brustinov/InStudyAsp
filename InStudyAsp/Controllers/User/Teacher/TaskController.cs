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
    public class TaskController : Controller
    {
        private IGenericRepository<TEACHER> teachers;
        private IGenericRepository<GROUP> groups;
        private IGenericRepository<SCHEDULE> schedules;
        private IGenericRepository<DISCIPLINE> disciplines;
        private TEACHER teacher;

        public TaskController(IGenericRepository<TEACHER> _teachers, IGenericRepository<GROUP> _groups, ScheduleRepository _schedules, IGenericRepository<DISCIPLINE> _disciplines)
        {
            teachers = _teachers;
            groups = _groups;
            schedules = _schedules;
            disciplines = _disciplines;
            teacher = teachers.FindBy(x => x.USER_PHONE == System.Web.HttpContext.Current.User.Identity.Name).FirstOrDefault();
        }


        // GET: Task
        [Authorize]
        public ActionResult Index()
        {
            // Getting identity
            
            //IQueryable<SCHEDULE> schedules;
            List<SCHEDULE> teacherSchedules;
            using (EFOracle.Model.dbContext context = new EFOracle.Model.dbContext())
            {
                
                //var teacher = new TeacherRepository(context).FindBy(x => x.USER_PHONE == identity).FirstOrDefault();
                //var teacher = context.TEACHERs.FirstOrDefault(x => x.USER_PHONE == identity);
                //schedules = context.SCHEDULEs.Where(x => x.TEACHER_ID == teacher.TEACHER_ID).ToList();
                //schedules = new ScheduleRepository(context).FindBy(x => x.TEACHER_ID == teacher.TEACHER_ID).ToList();
                teacherSchedules = schedules.FindBy(x => x.TEACHER_ID == teacher.TEACHER_ID).ToList();
                teacherSchedules.ForEach(x => { x.DISCIPLINE = context.DISCIPLINEs.FirstOrDefault(y=>y.DISCIPLINE_CODE==x.DISCIPLINE_CODE); });
                teacherSchedules.ForEach(x => { x.GROUP = context.GROUPs.FirstOrDefault(y => y.GROUP_CODE == x.GROUP_CODE); });
            }

            return View(teacherSchedules);
        }

        [Authorize]
        [HttpGet]
        public ActionResult Edit(string Id = "")
        {
            ViewModelSchedule model = new ViewModelSchedule(Id, schedules, disciplines, groups);
            SCHEDULE schedule = model.Schedule;

            string json = JsonConvert.SerializeObject(schedule, Formatting.Indented);


            ViewBag.DISCIPLINE_CODE = model.GetDiscipline;
            ViewBag.GROUP_CODE = model.GetGroup;
            ViewBag.BeforeID = json;
            return View(schedule);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(ScheduleExtended _schedule)
        {
            if (!ModelState.IsValid) return RedirectToAction("Edit");
            try
            {
                _schedule.TEACHER_ID = teacher.TEACHER_ID;
                SCHEDULE BeforeSchedule = JsonConvert.DeserializeObject<SCHEDULE>(_schedule.OldID); ;
                SCHEDULE Schedule = _schedule;

                
                ViewModelSchedule.AddOrUpdate(BeforeSchedule, Schedule, schedules);
                schedules.Save();
                //return View("Index", repoGood.GetAll());
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                if (e.InnerException?.InnerException != null) ViewBag.Message = e.InnerException.InnerException.Message;
                return RedirectToAction("Edit");
            }
        }


        [Authorize]
        [HttpPost]
        public ActionResult Edit2()
        {
            //if (!ModelState.IsValid) return RedirectToAction("Edit");
            //try
            //{
            //    _schedule.TEACHER_ID = teacher.TEACHER_ID;
            //    SCHEDULE BeforeSchedule = JsonConvert.DeserializeObject<SCHEDULE>(_schedule.OldID); ;
            //    SCHEDULE Schedule = _schedule;


            //    ViewModelSchedule.AddOrUpdate(BeforeSchedule, Schedule, schedules);
            //    schedules.Save();
            //    //return View("Index", repoGood.GetAll());
            //    return RedirectToAction("Index");
            //}
            //catch (Exception e)
            //{
            //    if (e.InnerException?.InnerException != null) ViewBag.Message = e.InnerException.InnerException.Message;
            //    return RedirectToAction("Edit");
            //}

            
            //SCHEDULE Schedule = JsonConvert.DeserializeObject<SCHEDULE>(s);

            decimal teacherId = 0; decimal.TryParse(Request.Form["TeacherID"], out teacherId);
            decimal disciplineCode = 0; decimal.TryParse(Request.Form["DisciplineCode"], out disciplineCode);
            DateTime sDate;
            DateTime.TryParse(Request.Form["ScheduleDate"], out sDate);

            SCHEDULE schedule = new SCHEDULE() {TEACHER_ID = teacherId, GROUP_CODE = Request.Form["GroupCode"], DISCIPLINE_CODE = disciplineCode, SCHEDULE_DATE = sDate};

            ViewModelSchedule model = new ViewModelSchedule(schedule, schedules, disciplines, groups);

            string json = JsonConvert.SerializeObject(schedule, Formatting.Indented);


            ViewBag.DISCIPLINE_CODE = model.GetDiscipline;
            ViewBag.GROUP_CODE = model.GetGroup;
            ViewBag.BeforeID = json;
            return View(schedule);


            //return RedirectToAction("Edit2");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {

            schedules.Delete(schedules.Get(id));
            schedules.Save();
            return RedirectToAction("Index");
        }
        //public ActionResult 
    }
}