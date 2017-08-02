namespace EFOracle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.SCHEDULE")]
    public partial class SCHEDULE
    {
        [Key]
        [Column(Order = 0)]
        public decimal TEACHER_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string GROUP_CODE { get; set; }

        [Key]
        [Column(Order = 2)]
        public decimal DISCIPLINE_CODE { get; set; }

        [Key]
        [Column(Order = 3)]
        public DateTime SCHEDULE_DATE { get; set; }

        public decimal SCHEDULE_ROOM { get; set; }

        public virtual DISCIPLINE DISCIPLINE { get; set; }

        public virtual GROUP GROUP { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
