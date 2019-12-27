using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projetcliniquemedical.Models
{
    public class Service
    {
        [Key]
        public int ServiceID { get; set; }

        public string ServiceNom { get; set; }

        public ICollection<Medecin> Medecin { get; set; }

    }
}