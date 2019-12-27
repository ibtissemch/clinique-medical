using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projetcliniquemedical.Models
{
    public class Patient
    {
        [Key]
        public int PatientID { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Adresse { get; set; }


        [Required]
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User UserAccount { get; set; }





    }
}