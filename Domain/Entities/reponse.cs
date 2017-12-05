namespace Domain.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cga.reponse")]
    public partial class reponse
    {
        [Key]
        public int idReponse { get; set; }

        [StringLength(255)]
        public string contenu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateEdit { get; set; }

        [Column(TypeName = "date")]
        public DateTime? datePost { get; set; }

        public int? idUser { get; set; }

        public int? idMessage { get; set; }
    }
}
