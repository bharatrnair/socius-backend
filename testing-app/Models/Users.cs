using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace testing_app.Models
{
    public class Users
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string password { get; set; }

        public DateTime dob { get; set; }

        public string Email { get; set; }

        public long phone { get; set; }

        public string city { get; set; }

        public string state { get; set; }
    }
}