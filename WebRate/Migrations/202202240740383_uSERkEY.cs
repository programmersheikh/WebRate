namespace WebRate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class uSERkEY : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TopicComments", "UserID", c => c.String());
            AddColumn("dbo.WebComments", "UserID", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WebComments", "UserID");
            DropColumn("dbo.TopicComments", "UserID");
        }
    }
}
