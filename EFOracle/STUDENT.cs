namespace EFOracle
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.STUDENT")]
    public partial class STUDENT
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public STUDENT()
        {
            FAQS = new HashSet<FAQ>();
            STUDENTWORKs = new HashSet<STUDENTWORK>();
        }

        [Key]
        public decimal STUDENT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string GROUP_CODE { get; set; }

        public DateTime STUDENT_START { get; set; }

        [StringLength(20)]
        public string USER_PHONE { get; set; }

        public DateTime? STUDENT_END { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAQ> FAQS { get; set; }

        public virtual GROUP GROUP { get; set; }

        public virtual USER USER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENTWORK> STUDENTWORKs { get; set; }
    }
}
