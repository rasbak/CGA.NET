namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.notification")]
    public partial class notification
    {
        public int id { get; set; }

        [StringLength(255)]
        public string content { get; set; }

        public int user { get; set; }
    }
}
