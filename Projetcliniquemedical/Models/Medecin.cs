using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Projetcliniquemedical.Models
{
    public class Medecin
    {
        [Key]
        public int MedecinID { get; set; }

        public string MedecinNom { get; set; }

        public string MedecinPrenom { get; set; }



        [Required]
        public int? UserID { get; set; }
        [ForeignKey("UserID")]
        public virtual User UserAccount { get; set; }

        public int? ServiceID { get; set; }
        [ForeignKey("ServiceID")]
        public virtual Service ServicesAccount { get; set; }
    }
}