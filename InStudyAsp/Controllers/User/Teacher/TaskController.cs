using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using EFOracle.Model;
using InStudyAsp.Models.User.Teacher;
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

        public TaskController(IGenericRepository<TEACHER> _teachers, IGenericRepository<GROUP> _groups, IGenericRepository<SCHEDULE> _schedules, IGenericRepository<DISCIPLINE> _disciplines)
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
            
            ViewBag.DISCIPLINE_CODE = model.GetDiscipline;
            ViewBag.GROUP_CODE = model.GetGroup;
            return View(schedule);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Edit(SCHEDULE _schedule)
        {
            _schedule.TEACHER_ID = teacher.TEACHER_ID;


            if (!ModelState.IsValid) return RedirectToAction("Edit");
            try
            {
                schedules.AddOrUpdate(_schedule);
                schedules.Save();
                //return View("Index", repoGood.GetAll());
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                if (e.InnerException?.InnerException != null) ViewBag.Message = e.InnerException.InnerException.Message;
                return RedirectToAction("Edit");
            }
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