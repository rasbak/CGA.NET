namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.address")]
    public partial class address
    {
        public int id { get; set; }

        [Column("address")]
        [StringLength(255)]
        public string address1 { get; set; }

        [StringLength(255)]
        public string city { get; set; }

        [StringLength(255)]
        public string government { get; set; }

        public int? postalCode { get; set; }

        public int? insured_id { get; set; }

        public virtual user user { get; set; }
    }
}
