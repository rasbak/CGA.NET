namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.policy")]
    public partial class policy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public policy()
        {
            commentaire = new HashSet<commentaire>();
        }

        public int id { get; set; }

        public float cost { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string wording { get; set; }

        public int? insurance_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<commentaire> commentaire { get; set; }
    }
}
