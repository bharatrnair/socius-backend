namespace testing_app.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dbchanged : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Caption = c.String(),
                        Time = c.DateTime(nullable: false),
                        UsersId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UsersId, cascadeDelete: true)
                .Index(t => t.UsersId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UsersId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UsersId" });
            DropTable("dbo.Posts");
        }
    }
}
