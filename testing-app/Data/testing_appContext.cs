using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace testing_app.Data
{
    public class testing_appContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public testing_appContext() : base("name=testing_appContext")
        {
        }

        public System.Data.Entity.DbSet<testing_app.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<testing_app.Models.Post> Posts { get; set; }

        public System.Data.Entity.DbSet<testing_app.Models.Like> Likes { get; set; }

        public System.Data.Entity.DbSet<testing_app.Models.Comment> Comments { get; set; }
    }
}
