namespace WhosAtDinner.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Presences",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        IsPresent = c.Boolean(nullable: false),
                        Group_UID = c.Guid(),
                        User_UID = c.Guid(),
                    })
                .PrimaryKey(t => t.UID)
                .ForeignKey("dbo.Groups", t => t.Group_UID)
                .ForeignKey("dbo.Users", t => t.User_UID)
                .Index(t => t.Group_UID)
                .Index(t => t.User_UID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Presences", "User_UID", "dbo.Users");
            DropForeignKey("dbo.Presences", "Group_UID", "dbo.Groups");
            DropIndex("dbo.Presences", new[] { "User_UID" });
            DropIndex("dbo.Presences", new[] { "Group_UID" });
            DropTable("dbo.Presences");
        }
    }
}
