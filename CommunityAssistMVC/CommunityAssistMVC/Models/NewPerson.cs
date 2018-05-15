using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CommunityAssistMVC.Models;

namespace CommunityAssistMVC.Models
{
    public class NewPerson
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string PlainPassword { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }

    }
}