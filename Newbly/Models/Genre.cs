using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Newbly.Models
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Type { get; set; }

        public static readonly int UnknownGenre = 0;

    }
}