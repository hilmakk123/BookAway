using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookAway.Models
{
    public class Search
    {
        [Required]
        public string Detsination { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime CheckIn { get; set; }
        //[DataType(DataType.Date)]
        //public DateTime CheckOut { get; set; }
        [Required]
       
        public int Rooms { get; set; }
    }
}