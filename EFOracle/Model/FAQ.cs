namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.FAQS")]
    public partial class FAQ
    {
        [Key]
        [Column(Order = 0)]
        public decimal STUDENT_ID { get; set; }

        [Key]
        [Column(Order = 1)]
        public decimal TASK_ID { get; set; }

        [Key]
        [Column(Order = 2)]
        public DateTime FAQS_QUESTION_TIME { get; set; }

        [Required]
        [StringLength(500)]
        public string FAQS_QUESTION { get; set; }

        public decimal? TEACHER_ID { get; set; }

        public DateTime? FAQS_ANSWER_TIME { get; set; }

        [StringLength(500)]
        public string FAQS_ANSWER { get; set; }

        public virtual STUDENT STUDENT { get; set; }

        public virtual TASK TASK { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
