namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.contract")]
    public partial class contract
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public contract()
        {
            claim = new HashSet<claim>();
        }

        public int id { get; set; }

        public float costContract { get; set; }

        public DateTime? dateSending { get; set; }

        public DateTime? endDate { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        public DateTime? startDate { get; set; }

        public int? insured_id { get; set; }

        public int? policy_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<claim> claim { get; set; }
    }
}
