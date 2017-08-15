namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.TASK")]
    public partial class TASK
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TASK()
        {
            FAQS = new HashSet<FAQ>();
            STUDENTWORKs = new HashSet<STUDENTWORK>();
            TASK1 = new HashSet<TASK>();
        }

        [Key]
        public decimal TASK_ID { get; set; }

        public decimal? PARENT_TASK_ID { get; set; }

        public decimal DISCIPLINE_CODE { get; set; }

        public DateTime TASK_DATE { get; set; }

        public decimal TASK_TYPE_CODE { get; set; }

        [StringLength(500)]
        public string TASK_DESCRIPTION { get; set; }

        public decimal TEACHER_ID_FK { get; set; }

        public virtual DISCIPLINE DISCIPLINE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAQ> FAQS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENTWORK> STUDENTWORKs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASK1 { get; set; }

        public virtual TASK TASK2 { get; set; }

        public virtual TASKTYPE TASKTYPE { get; set; }

        public virtual TEACHER TEACHER { get; set; }
    }
}
