using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAway.Models
{
    public class LoginHotelOwner
    {
        [Required(ErrorMessage = "Enter Your Username")]
        public string HOwnerUsername { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string HOwnerPassword { get; set; }
    }
    public class LoginAdmin
    {
        [Required(ErrorMessage = "Enter Your Username")]
        public string AdminUsername { get; set; }
        [Required(ErrorMessage = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string AdminPassword { get; set; }
    }
}