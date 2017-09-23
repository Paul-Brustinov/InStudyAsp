using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace EFOracle.Model
{

    /*************************************************************************************//**
    * \brief Specifying view metadata for SCHEDULE class
    *****************************************************************************************/
    [MetadataType(typeof(ScheduleMetadata))]
    public partial class SCHEDULE{}

    public class ScheduleMetadata
    {
        public decimal TEACHER_ID { get; set; }

        [Display(Name = "Group code")]
        public string GROUP_CODE { get; set; }

        [Display(Name = "Discipline code")]
        public decimal DISCIPLINE_CODE { get; set; }

        [Display(Name = "Schedule date")]
        [DataType(DataType.DateTime)]
        //[DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime SCHEDULE_DATE { get; set; }

        [Display(Name = "Room")]
        public decimal SCHEDULE_ROOM { get; set; }

        [JsonIgnore]
        [Display(Name = "Discipline")]
        public virtual DISCIPLINE DISCIPLINE { get; set; }

        [JsonIgnore]
        public virtual GROUP GROUP { get; set; }

        [JsonIgnore]
        public virtual TEACHER TEACHER { get; set; }

    }
}
