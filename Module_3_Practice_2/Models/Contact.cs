using System;
using System.Collections.Generic;
using System.Text;

namespace Module_3_Practice_2.Models
{
    public class Contact
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName => $@"{FirstName} {LastName}";

        public DateTime BirthDay { get; set; }

        public string PhoneNumber { get; set; }

        public List<Call> Calls { get; set; }
    }
}
