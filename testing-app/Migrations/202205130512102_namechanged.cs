namespace testing_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class namechanged : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String());
            AddColumn("dbo.Users", "LastName", c => c.String());
            DropColumn("dbo.Users", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Name", c => c.String());
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
