using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Projetcliniquemedical.Models
{
    public class UserAccount
    {
        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage ="Entrer votre Email SVP")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Entrer votre Mot de pass SVP")]
        public string Password { get; set; }

        public string Type { get; set; }


    }
}