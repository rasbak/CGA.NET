namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.messages")]
    public partial class messages
    {
        [Key]
        public int idMessage { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEdit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datePost { get; set; }

        public int? nbLike { get; set; }

        public int? idPosteur { get; set; }

        public int? idTopic { get; set; }
    }
}
