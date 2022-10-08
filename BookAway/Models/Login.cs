using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAway.Models
{
    public class Login
    {
        [Required(ErrorMessage = "Enter Your Username")]
        public string CustUsername { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string CustPassword { get; set; }
    }
}