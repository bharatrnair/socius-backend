using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testing_app.Models
{
    public class Signup
    {
        public int Id { get; set; }


        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        public string password { get; set; }

        [Compare("password")]
        public string Confirmpassword { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }


        public string Email { get; set; }

        [Required]
        [Range(1000000000, 999999999999, ErrorMessage = "Please enter a phone number")]
        public long phone { get; set; }

        [MaxLength(20, ErrorMessage = "City name cannot be more than 20 char")]
        public string city { get; set; }

        [MaxLength(20,ErrorMessage ="State cannot be empty")]
        public string state { get; set; }
    }
}