namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.vehicle")]
    public partial class vehicle
    {
        public int id { get; set; }

        [StringLength(255)]
        public string color { get; set; }

        public DateTime? dateachat { get; set; }

        public int horsepower { get; set; }

        [StringLength(255)]
        public string immatriculation { get; set; }

        [StringLength(255)]
        public string marque { get; set; }

        [StringLength(255)]
        public string model { get; set; }

        [StringLength(255)]
        public string numchassis { get; set; }

        public int? type { get; set; }

        public int? contract_id { get; set; }

        public int? insured_id { get; set; }
    }
}
