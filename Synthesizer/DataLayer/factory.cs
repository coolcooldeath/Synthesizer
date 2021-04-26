namespace Synthesizer.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("factory")]
    public partial class factory
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public factory()
        {
            Syntheses = new HashSet<Syntheses>();
        }

        public string factory_name { get; set; }

        [Key]
        public int id_factory { get; set; }

        [Required]
        [StringLength(20)]
        public string login { get; set; }

        public virtual users users { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Syntheses> Syntheses { get; set; }
    }
}
