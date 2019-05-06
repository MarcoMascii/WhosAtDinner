namespace WhosAtDinner.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SecondMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        UID = c.Guid(nullable: false),
                        Name = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        CreationUser_UID = c.Guid(),
                        User_UID = c.Guid(),
                    })
                .PrimaryKey(t => t.UID)
                .ForeignKey("dbo.Users", t => t.CreationUser_UID)
                .ForeignKey("dbo.Users", t => t.User_UID)
                .Index(t => t.CreationUser_UID)
                .Index(t => t.User_UID);
            
            AddColumn("dbo.Users", "Password", c => c.String());
            AddColumn("dbo.Users", "Group_UID", c => c.Guid());
            CreateIndex("dbo.Users", "Group_UID");
            AddForeignKey("dbo.Users", "Group_UID", "dbo.Groups", "UID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Groups", "User_UID", "dbo.Users");
            DropForeignKey("dbo.Users", "Group_UID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "CreationUser_UID", "dbo.Users");
            DropIndex("dbo.Groups", new[] { "User_UID" });
            DropIndex("dbo.Groups", new[] { "CreationUser_UID" });
            DropIndex("dbo.Users", new[] { "Group_UID" });
            DropColumn("dbo.Users", "Group_UID");
            DropColumn("dbo.Users", "Password");
            DropTable("dbo.Groups");
        }
    }
}
