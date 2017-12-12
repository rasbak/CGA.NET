using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CGA.Models
{
    public class ClaimModel
    {
        public int id { get; set; }
        [DataType(DataType.Date)]

       
  public DateTime? accidentDate { get; set; }

        [Required(ErrorMessage = "Name: You must enter a value")]
       
        public string localisation { get; set; }

        [Required(ErrorMessage = "Name: You must enter a value")]
        
        public string namesAddressesPhonesWitnesses { get; set; }
      //  [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]

      
        public string cinInsured2 { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]

      
        public string lang { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]

        
        public string lat { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]

       
        public string etat { get; set; }
        public int? contract_id { get; set; }

        public int injured { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]

       
        public string otherObjectDamage { get; set; }
        [Required(ErrorMessage = "Name: You must enter a value")]
        public int vehiclesDamage { get; set; }
    }
}
