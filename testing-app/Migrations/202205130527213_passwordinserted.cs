namespace testing_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordinserted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "password", c => c.String());
            AddColumn("dbo.Users", "Confirmpassword", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "Confirmpassword");
            DropColumn("dbo.Users", "password");
        }
    }
}
