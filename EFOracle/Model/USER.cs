namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INSTUDY.USER")]
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            STUDENTs = new HashSet<STUDENT>();
            TEACHERs = new HashSet<TEACHER>();
            USER_SESSION = new HashSet<USER_SESSION>();
        }

        [Key]
        [StringLength(20)]
        public string USER_PHONE { get; set; }

        [Required]
        [StringLength(256)]
        public string USER_PASSWORD { get; set; }

        [Required]
        [StringLength(50)]
        public string USER_EMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_FIRSTNAME { get; set; }

        [Required]
        [StringLength(20)]
        public string USER_LASTNAME { get; set; }

        public DateTime USER_BIRTHDAY { get; set; }

        public byte[] USER_AVATAR { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<STUDENT> STUDENTs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TEACHER> TEACHERs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<USER_SESSION> USER_SESSION { get; set; }
    }
}
