using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Newbly.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public DateTime DateAdded { get; set; }

        [MinNumberOfStocks]
        [Display(Name = "Number of Stocks")]
        public short Stock { get; set; }

        [Display(Name = "Number Available")]
        public short NumberAvailable { get; set; }

        public Genre Genre { get; set; }
        [Required(ErrorMessage = "Genre Field is Required.")]
        public int GenreId { get; set; }

    }
}