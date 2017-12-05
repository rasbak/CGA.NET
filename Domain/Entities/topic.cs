namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.topic")]
    public partial class topic
    {
        [Key]
        public int idTopic { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateCreation { get; set; }

        public DateTime? lastpost { get; set; }

        [StringLength(255)]
        public string sujet { get; set; }

        public int? idCreateur { get; set; }
    }
}
