namespace CGA_WEB.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Microsoft.AspNet.Identity;
    using Microsoft.Owin.Security;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("cga.report")]
    public class ReclmationViewModel
    {
        public int id { get; set; }


        [StringLength(255)]
        public string pass { get; set; }
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(255)]
        public string Content { get; set; }

        [StringLength(255)]
        public string subject { get; set; }
        [StringLength(255)]
        public string name { get; set; }
        [StringLength(255)]
        public string lastName { get; set; }
        [StringLength(255)]
        public string role { get; set; }

    }
}
