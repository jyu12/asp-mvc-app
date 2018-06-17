using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Newbly.Models
{
    public class Customer
    {
        public int Id { get; set; }
        /* Example of Entity Data Annotation
         * Simple conventions to modify default database properties
         * A better way is to use Fluent API?
         * Example of overridding validation message
         * Required(ErrorMessage = "Your own validation message")]
         * 
         * ASP.NET uses Annotations to do client & server side validations
         * jqueryval will only work on Standard .NET Annonated properties
         * custom jQuery will need to be written for the custom server-side validation
         * */
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        [Min18YearsIfAMember] // example of custom validation
        public DateTime? Birthdate { get; set; }

        // Example of a Navigation Property in Entity
        public MembershipType MembershipType { get; set; }

        //  public virtual type methodNmae {} to lazyload... but why?

        /*
         * Example Data Tier Optimization
         * if the entity SQL is too slow A stored procedure can be written and called from the AppDbContext
        */

        [Display(Name = "Membership Type")]
        // By Convention: EntityFramework will treat this as a foreign Key for the related entity
        [Required(ErrorMessage = "The Membership Type Field is required.")]
        public byte MembershipTypeId { get; set; }
    }

}