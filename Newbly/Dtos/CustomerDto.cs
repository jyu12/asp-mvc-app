using Newbly.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Newbly.Dtos
{
    /*
     * Example of a DTO
     * Use AutoMapper -- see App_Start/MappingProfile
     * */
    public class CustomerDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public string Details { get; set; }
        public bool IsSubscribedToNewsletter { get; set; }

        public DateTime? Birthdate { get; set; }

        // Don't forget to create mapping for Automapper
        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeId { get; set; }
    }
}