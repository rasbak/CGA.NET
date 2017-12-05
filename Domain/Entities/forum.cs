namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.forum")]
    public partial class forum
    {
        public int id { get; set; }

        [StringLength(255)]
        public string subject { get; set; }
    }
}
