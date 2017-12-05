namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.vehicleswreck")]
    public partial class vehicleswreck
    {
        public int id { get; set; }

        [StringLength(255)]
        public string couleur { get; set; }

        [StringLength(255)]
        public string description { get; set; }

        [StringLength(255)]
        public string modele { get; set; }

        [StringLength(255)]
        public string numchassis { get; set; }
    }
}
