namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##INSTUDY.TEACHER")]
    public partial class TEACHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TEACHER()
        {
            FAQS = new HashSet<FAQ>();
            SCHEDULEs = new HashSet<SCHEDULE>();
            TASKs = new HashSet<TASK>();
        }

        [Key]
        public decimal TEACHER_ID { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_PHONE { get; set; }

        public DateTime TEACHER_START { get; set; }

        public DateTime? TEACHER_END { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FAQ> FAQS { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SCHEDULE> SCHEDULEs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TASK> TASKs { get; set; }

        public virtual USER USER { get; set; }
    }
}
