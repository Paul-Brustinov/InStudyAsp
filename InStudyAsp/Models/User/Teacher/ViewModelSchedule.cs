using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFOracle.Model;
using Repo.Common;

namespace InStudyAsp.Models.User.Teacher
{
    /*************************************************************************************//**
    * \brief  ViewModel for ScheduleController 
    *****************************************************************************************/
    public class ViewModelSchedule : SCHEDULE
    {
        private IGenericRepository<DISCIPLINE> repoDiscipline;
        private IGenericRepository<GROUP> repoGroup;
        private IGenericRepository<SCHEDULE> repoSchedule;

        /*************************************************************************************//**
        * \brief  CTOR Initialization from SCHEDULE
        *****************************************************************************************/
        public ViewModelSchedule(SCHEDULE _schedule, IGenericRepository<SCHEDULE> _repoSchedule, IGenericRepository<DISCIPLINE> _repoDiscipline, IGenericRepository<GROUP> _repoGroup)
        {
            if (_schedule != null) { 
                TEACHER_ID = _schedule.TEACHER_ID;
                GROUP_CODE = _schedule.GROUP_CODE;
                DISCIPLINE_CODE = _schedule.DISCIPLINE_CODE;
                SCHEDULE_DATE = _schedule.SCHEDULE_DATE;
                SCHEDULE_ROOM = _schedule.SCHEDULE_ROOM;
            }
            repoSchedule = _repoSchedule;
            repoDiscipline = _repoDiscipline;
            repoGroup = _repoGroup;
        }

        public ViewModelSchedule()
        {
        }

        /*************************************************************************************//**
        * \brief  AddOrUpdate - if SCHEDULE exist then Add else Update
        *****************************************************************************************/
        public static SCHEDULE AddOrUpdate(SCHEDULE _oldS, SCHEDULE _newS, IGenericRepository<SCHEDULE> schedules)
        {
            SCHEDULE oldS = schedules.FindBy(x => x.TEACHER_ID == _oldS.TEACHER_ID && x.GROUP_CODE == _oldS.GROUP_CODE && x.DISCIPLINE_CODE == _oldS.DISCIPLINE_CODE && x.SCHEDULE_DATE == _oldS.SCHEDULE_DATE).FirstOrDefault();
            SCHEDULE newS = new SCHEDULE()
            {
                TEACHER_ID = _newS.TEACHER_ID,
                GROUP_CODE = _newS.GROUP_CODE,
                DISCIPLINE_CODE = _newS.DISCIPLINE_CODE,
                SCHEDULE_DATE = _newS.SCHEDULE_DATE,
                SCHEDULE_ROOM = _newS.SCHEDULE_ROOM
            };
                
                schedules.FindBy(x => x.TEACHER_ID == _newS.TEACHER_ID && x.GROUP_CODE == _newS.GROUP_CODE && x.DISCIPLINE_CODE == _newS.DISCIPLINE_CODE && x.SCHEDULE_DATE == _newS.SCHEDULE_DATE).FirstOrDefault();


            if (oldS != null)
            {
                if (oldS.TEACHER_ID != newS.TEACHER_ID||oldS.GROUP_CODE != newS.GROUP_CODE || oldS.DISCIPLINE_CODE != newS.DISCIPLINE_CODE || oldS.SCHEDULE_DATE != newS.SCHEDULE_DATE) schedules.Delete(oldS);
            }
            schedules.AddOrUpdate(newS);
            return newS;
        }

        /*************************************************************************************//**
        * \brief To convert decimal SCHEDULE_ROOM to int for view
        *****************************************************************************************/
        public int ScheduleRoom
        {
            get
            {
                int i = 0;
                int.TryParse(SCHEDULE_ROOM.ToString(CultureInfo.InvariantCulture), out i);
                return i;
            }
            set {SCHEDULE_ROOM = value; }
        }

        /*************************************************************************************//**
         * \brief Store json of unchanged SCHEDULE
        *****************************************************************************************/
        public string OldID { get; set; }


        /*************************************************************************************//**
         * \brief To prevent hand edit of main field
        *****************************************************************************************/
        public string SCHEDULE_DATE2 { get; set; }


        /*************************************************************************************//**
         * \brief Parse DateTime from string dd.MM.YYYY hh:mm
        *****************************************************************************************/
        public DateTime GetDateTime()
        {
            int year = 0;
            int day = 0;
            int month = 0;
            int hr = 0;
            int mn = 0;
            int.TryParse(SCHEDULE_DATE2.Substring(6, 4), out year);
            int.TryParse(SCHEDULE_DATE2.Substring(0, 2), out day);
            int.TryParse(SCHEDULE_DATE2.Substring(3, 2), out month);
            int.TryParse(SCHEDULE_DATE2.Substring(11, 2), out hr);
            int.TryParse(SCHEDULE_DATE2.Substring(14, 2), out mn);

            //if (int.TryParse(SCHEDULE_DATE2.Substring(0, 4), out year))
            //{
            //    int.TryParse(SCHEDULE_DATE2.Substring(5, 2), out day);
            //    int.TryParse(SCHEDULE_DATE2.Substring(8, 2), out month);
            //    int.TryParse(SCHEDULE_DATE2.Substring(11, 2), out hr);
            //    int.TryParse(SCHEDULE_DATE2.Substring(14, 2), out mn);
            //}

            return new DateTime(year, month, day, hr, mn, 0);
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

        /*!
        * \brief Provide selection Discipline from SelectList in View
        */
        public SelectList GetDiscipline => new SelectList( disciplines.Union(repoDiscipline.GetAll()), "DISCIPLINE_CODE", "DISCIPLINE_NAME", DISCIPLINE_CODE);

        /*!
         * \brief Provide selection Group from SelectList in View
        */
        public SelectList GetGroup => new SelectList(groups.Union(repoGroup.GetAll()), "GROUP_CODE", "GROUP_CODE", GROUP_CODE);
    }
}