namespace testing_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class confirmPasswordChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Users", "Confirmpassword");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "Confirmpassword", c => c.String());
        }
    }
}
