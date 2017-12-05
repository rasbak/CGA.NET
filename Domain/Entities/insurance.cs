namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.insurance")]
    public partial class insurance
    {
        public int id { get; set; }

        [StringLength(255)]
        public string adresse { get; set; }

        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string nom { get; set; }

        public int? telephone { get; set; }
    }
}
