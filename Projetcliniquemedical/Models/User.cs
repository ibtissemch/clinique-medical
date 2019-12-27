using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projetcliniquemedical.Models
{
    public class User
    {

        [Key]
        public int UserID { get; set; }
        [Required(ErrorMessage = "Entrer votre Email SVP")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Entrer votre Mot de pass SVP")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string Type { get; set; }
    }
}