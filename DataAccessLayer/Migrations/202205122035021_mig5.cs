namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "MemberID", "dbo.Members");
            DropForeignKey("dbo.Comments", "WritingID", "dbo.Writings");
            DropIndex("dbo.Comments", new[] { "MemberID" });
            DropIndex("dbo.Comments", new[] { "WritingID" });
            AddColumn("dbo.ContactMessages", "ContactMessageStatus", c => c.Boolean(nullable: false));
            DropTable("dbo.Comments");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentID = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        CommentDate = c.DateTime(nullable: false),
                        MemberID = c.Int(nullable: false),
                        WritingID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CommentID);
            
            DropColumn("dbo.ContactMessages", "ContactMessageStatus");
            CreateIndex("dbo.Comments", "WritingID");
            CreateIndex("dbo.Comments", "MemberID");
            AddForeignKey("dbo.Comments", "WritingID", "dbo.Writings", "WritingID", cascadeDelete: true);
            AddForeignKey("dbo.Comments", "MemberID", "dbo.Members", "MemberID", cascadeDelete: true);
        }
    }
}
