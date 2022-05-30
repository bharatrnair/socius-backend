using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace testing_app.Models
{
    public class PostValidation
    {
        public int Id { get; set; }

        public string Caption { get; set; }

        [MaxLength(100, ErrorMessage = "Maximum characters reached")]
        public string ImageUrl { get; set; }
    }
}