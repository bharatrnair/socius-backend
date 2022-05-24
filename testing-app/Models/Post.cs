using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testing_app.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Caption { get; set; }

        public DateTime Time { get; set; }

        public int UsersId { get; set; }

        [ForeignKey("UsersId")]
        public virtual Users Users { get; set; }



    }
}