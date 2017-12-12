using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CGA.Models
{
    public class ContractModel
    {
        public int id { get; set; }

        public float costContract { get; set; }

        public DateTime? dateSending { get; set; }

        public DateTime? endDate { get; set; }

        public string etat { get; set; }

        public DateTime? startDate { get; set; }

        public int? insured_id { get; set; }

        public int? policy_id { get; set; }
    }
}