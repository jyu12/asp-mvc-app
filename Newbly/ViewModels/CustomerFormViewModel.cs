using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using Newbly.Models;

namespace Newbly.ViewModels
{

    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
        public string Title {
            get
            {
                return Customer == null ? "New Customer" : "Edit Customer";
            }
        }
    }
}