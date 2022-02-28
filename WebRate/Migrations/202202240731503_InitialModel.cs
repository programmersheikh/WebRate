namespace WebRate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TopicComments",
                c => new
                    {
                        TopcComntId = c.Int(nullable: false, identity: true),
                        TopicID = c.Int(nullable: false),
                        DetailComment = c.String(),
                    })
                .PrimaryKey(t => t.TopcComntId)
                .ForeignKey("dbo.Topics", t => t.TopicID, cascadeDelete: true)
                .Index(t => t.TopicID);
            
            CreateTable(
                "dbo.WebComments",
                c => new
                    {
                        WebComntId = c.Int(nullable: false, identity: true),
                        WebID = c.Int(nullable: false),
                        DetailComment = c.String(),
                    })
                .PrimaryKey(t => t.WebComntId)
                .ForeignKey("dbo.Websites", t => t.WebID, cascadeDelete: true)
                .Index(t => t.WebID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.WebComments", "WebID", "dbo.Websites");
            DropForeignKey("dbo.TopicComments", "TopicID", "dbo.Topics");
            DropIndex("dbo.WebComments", new[] { "WebID" });
            DropIndex("dbo.TopicComments", new[] { "TopicID" });
            DropTable("dbo.WebComments");
            DropTable("dbo.TopicComments");
        }
    }
}
