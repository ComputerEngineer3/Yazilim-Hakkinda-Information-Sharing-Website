namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Writings", "MemberID", c => c.Int());
            AddColumn("dbo.Subtitles", "TitleID", c => c.Int());
            AlterColumn("dbo.Admins", "AdminName", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminSurname", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String(nullable: false));
            CreateIndex("dbo.Writings", "MemberID");
            CreateIndex("dbo.Subtitles", "TitleID");
            AddForeignKey("dbo.Writings", "MemberID", "dbo.Members", "MemberID");
            AddForeignKey("dbo.Subtitles", "TitleID", "dbo.Titles", "TitleID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Subtitles", "TitleID", "dbo.Titles");
            DropForeignKey("dbo.Writings", "MemberID", "dbo.Members");
            DropIndex("dbo.Subtitles", new[] { "TitleID" });
            DropIndex("dbo.Writings", new[] { "MemberID" });
            AlterColumn("dbo.Admins", "AdminPassword", c => c.String());
            AlterColumn("dbo.Admins", "AdminEmail", c => c.String());
            AlterColumn("dbo.Admins", "AdminUsername", c => c.String());
            AlterColumn("dbo.Admins", "AdminSurname", c => c.String());
            AlterColumn("dbo.Admins", "AdminName", c => c.String());
            DropColumn("dbo.Subtitles", "TitleID");
            DropColumn("dbo.Writings", "MemberID");
        }
    }
}
