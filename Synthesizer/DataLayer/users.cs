namespace Synthesizer.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public users()
        {
            factory = new HashSet<factory>();
        }

        [Key]
        [StringLength(20)]
        public string login { get; set; }

        [Required]
        [StringLength(30)]
        public string password { get; set; }

        [Required]
        [StringLength(20)]
        public string name { get; set; }

        public bool? isadmin { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime? date { get; set; }

        [Required]
        [StringLength(30)]
        public string gmail { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<factory> factory { get; set; }
    }
}
