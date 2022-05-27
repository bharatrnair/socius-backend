using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace testing_app.Models
{
    public class Like
    {
        public int Id { get; set; }

        public int UsersId { get; set; }

        [ForeignKey("UsersId")]

        public virtual Users Users { get; set; }

        public int PostId { get; set; }

        [ForeignKey("PostId")]

        public virtual Post Post { get; set; }
    }
}