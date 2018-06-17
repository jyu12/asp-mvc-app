using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Newbly.Models
{
    /*Example of Server-Side Validation*/
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // This validation method gives access to the object.. but need to cast it first
            var customer = (Customer)validationContext.ObjectInstance;

            /*
             * Return a default SUccess
             * or return a new ValidationResult("Your own")
             * */

            // Or use Enum Type, but not a good solution in this case
            if (customer.MembershipTypeId == MembershipType.PayAsYouGo ||
                customer.MembershipTypeId == MembershipType.UnknownType)
                return ValidationResult.Success;
            if (customer.Birthdate == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            return (age >= 18) ? ValidationResult.Success : new ValidationResult("Need to be 18 or older for this type of membership");
        }
    }
}