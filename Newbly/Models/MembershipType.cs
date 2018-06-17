using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace Newbly.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        [Required]
        public string Name { get; set; }

        // The reference data here so that it's clear in the code.
        public static readonly byte UnknownType = 0;
        public static readonly byte PayAsYouGo = 1;
    }
}