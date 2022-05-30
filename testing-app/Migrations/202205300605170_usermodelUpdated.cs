namespace testing_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class usermodelUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "DpUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "DpUrl");
        }
    }
}
