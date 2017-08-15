namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.STUDENTWORK")]
    public partial class STUDENTWORK
    {
        [Key]
        [Column(Order = 0)]
        public decimal STUDENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal TASK_ID { get; set; }

        public byte[] STUDENT_WORK_FILE { get; set; }

        [Required]
        [StringLength(500)]
        public string STUDENT_WORK_TEXT { get; set; }

        public decimal? STUDENT_WORK_MARK { get; set; }

        public DateTime STUDENT_WORK_DATE { get; set; }

        public virtual STUDENT STUDENT { get; set; }

        public virtual TASK TASK { get; set; }
    }
}
