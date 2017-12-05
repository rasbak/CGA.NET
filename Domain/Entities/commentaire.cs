namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.commentaire")]
    public partial class commentaire
    {
        public int id { get; set; }

        [StringLength(255)]
        public string text { get; set; }

        public int? policy_id { get; set; }

        public int? user_id { get; set; }

        public virtual policy policy { get; set; }
    }
}
