using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CGA_WEB.Models
{
    public class UserViewModal
    {
        [Required]
        [StringLength(31)]
        public string DTYPE { get; set; }

        public int id { get; set; }

        [Required(ErrorMessage = "Vous devez entrer un email")]
        [StringLength(255)]
        public string email { get; set; }

        [StringLength(255)]
        public string firstName { get; set; }

        [StringLength(255)]
        public string lastName { get; set; }

        [StringLength(255)]
        public string password { get; set; }

        [StringLength(255)]
        public string role { get; set; }

        public int? driverLN { get; set; }
        [StringLength(255)]
        public string expertiseLevel { get; set; }


        [StringLength(255)]
        public string phoneNumber { get; set; }

        [StringLength(255)]
        public string cin1 { get; set; }

        [StringLength(255)]
        public string cin2 { get; set; }
    }
}