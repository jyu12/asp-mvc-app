using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newbly.Models
{
    /*Example of Server-Side Validation*/
    public class MinNumberOfStocks : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var movie = (Movie)validationContext.ObjectInstance;
            if (movie.GenreId == Genre.UnknownGenre)
                return ValidationResult.Success;
            return (movie.Stock >= 0) ? ValidationResult.Success :
                new ValidationResult("Number of stocks must be greater or equal to 0.");
        }
    }
}