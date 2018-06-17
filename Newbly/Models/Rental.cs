﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newbly.Models
{
    public class Rental
    {
        public int Id { get; set; }

        [Display(Name = "Date Returned")]
        public DateTime? DateReturned { get; set; }

        [Display(Name = "Date Rented")]
        public DateTime DateRented { get; set; }

        [Required]
        public Customer Customer { get; set; }

        [Required]
        public Movie Movie { get; set; }
    }
}