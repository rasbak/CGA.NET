namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.claim")]
    public partial class claim
    {
        public int id { get; set; }

        [StringLength(255)]
        public string ImageUrl { get; set; }

        public DateTime? accidentDate { get; set; }

        [StringLength(255)]
        public string cinInsured2 { get; set; }

        [StringLength(255)]
        public string etat { get; set; }

        [Column(TypeName = "bit")]
        public bool injured { get; set; }

        [StringLength(255)]
        public string lang { get; set; }

        [StringLength(255)]
        public string lat { get; set; }

        [StringLength(255)]
        public string localisation { get; set; }

        [StringLength(255)]
        public string namesAddressesPhonesWitnesses { get; set; }

        [Column(TypeName = "bit")]
        public bool otherObjectDamage { get; set; }

        [Column(TypeName = "bit")]
        public bool vehiclesDamage { get; set; }

        public int? contract_id { get; set; }

        public virtual contract contract { get; set; }
    }
}
