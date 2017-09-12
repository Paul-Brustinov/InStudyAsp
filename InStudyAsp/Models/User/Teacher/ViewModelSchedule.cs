using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFOracle.Model;
using Repo.Common;

namespace InStudyAsp.Models.User.Teacher
{
    public class ViewModelSchedule
    {
        private IGenericRepository<DISCIPLINE> repoDiscipline;
        private IGenericRepository<GROUP> repoGroup;
        private IGenericRepository<SCHEDULE> repoSchedule;
        private string id;

        public ViewModelSchedule(string _id, IGenericRepository<SCHEDULE> _repoSchedule, IGenericRepository<DISCIPLINE> _repoDiscipline, IGenericRepository<GROUP> _repoGroup)
        {
            id = _id;
            repoSchedule = _repoSchedule;
            repoDiscipline = _repoDiscipline;
            repoGroup = _repoGroup;
        }

        public SCHEDULE Schedule
        {
            get
            {
                if (id == "") return new SCHEDULE();

                string[] ids = id.Split('-');

                decimal teacherId; decimal.TryParse(ids[0], out teacherId);
                string groupCode = ids[1];
                decimal disciplineCode; decimal.TryParse(ids[2], out disciplineCode);
                int year; int.TryParse(ids[3], out year);
                int month; int.TryParse(ids[4], out month);
                int day; int.TryParse(ids[5], out day);
                int hour; int.TryParse(ids[6], out hour);
                int min; int.TryParse(ids[7], out min);
                int sec; int.TryParse(ids[8], out sec);

                var schedule = repoSchedule.FindBy(x => x.TEACHER_ID == teacherId && x.GROUP_CODE == groupCode 
                    && x.DISCIPLINE_CODE == disciplineCode
                    && x.SCHEDULE_DATE.Year == year && x.SCHEDULE_DATE.Month == month && x.SCHEDULE_DATE.Day == day
                    && x.SCHEDULE_DATE.Hour == hour && x.SCHEDULE_DATE.Minute == min && x.SCHEDULE_DATE.Second == sec
                 ).FirstOrDefault();

                schedule.DISCIPLINE =
                    repoDiscipline.FindBy(x => x.DISCIPLINE_CODE == schedule.DISCIPLINE_CODE).FirstOrDefault();
                schedule.GROUP =
                    repoGroup.FindBy(x => x.GROUP_CODE == schedule.GROUP_CODE).FirstOrDefault();

                return schedule;
            }
        }

        private IEnumerable<DISCIPLINE> disciplines
        {
            get
            {
                yield return new DISCIPLINE() {DISCIPLINE_CODE = 0, DISCIPLINE_NAME = "Select Discipline"};
            }
        }

        private IEnumerable<GROUP> groups
        {
            get { yield return new GROUP() {GROUP_CODE = "Select group"}; }
        }

        public SelectList GetDiscipline => new SelectList( disciplines.Union(repoDiscipline.GetAll()), "DISCIPLINE_CODE", "DISCIPLINE_NAME", Schedule.DISCIPLINE_CODE);
        public SelectList GetGroup => new SelectList(groups.Union(repoGroup.GetAll()), "GROUP_CODE", "GROUP_CODE", Schedule.GROUP_CODE);
    }
}