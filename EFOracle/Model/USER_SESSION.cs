namespace EFOracle.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("C##INSTUDY.USER_SESSION")]
    public partial class USER_SESSION
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string USER_PHONE_FK { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime SESSION_DATETIME { get; set; }

        [Required]
        [StringLength(512)]
        public string SESSION_HASH { get; set; }

        public DateTime? SESSION_EXPIRE { get; set; }

        public virtual USER USER { get; set; }
    }
}
