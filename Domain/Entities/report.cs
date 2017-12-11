namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.report")]
    public partial class report
    {
        public int id { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string subject { get; set; }

        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string lastName { get; set; }


        public int vu { get; set; }

        public int? insured_id { get; set; }
    }
}
