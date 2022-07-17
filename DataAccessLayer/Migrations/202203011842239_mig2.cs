namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Comments", "CommentText", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberName", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberSurname", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberUsername", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberJob", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberAbout", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Members", "MemberPassword", c => c.String(nullable: false));
            AlterColumn("dbo.Writings", "WritingTitle", c => c.String(nullable: false));
            AlterColumn("dbo.Writings", "WritingText", c => c.String(nullable: false));
            AlterColumn("dbo.Subtitles", "SubtitleName", c => c.String(nullable: false));
            AlterColumn("dbo.Titles", "TitleName", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "SenderName", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "SenderSurname", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "SenderEmail", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "MessageSubject", c => c.String(nullable: false));
            AlterColumn("dbo.ContactMessages", "MessageText", c => c.String(nullable: false));
            AlterColumn("dbo.Editors", "EditorName", c => c.String(nullable: false));
            AlterColumn("dbo.Editors", "EditorSurname", c => c.String(nullable: false));
            AlterColumn("dbo.Editors", "EditorUsername", c => c.String(nullable: false));
            AlterColumn("dbo.Editors", "EditorEmail", c => c.String(nullable: false));
            AlterColumn("dbo.Editors", "EditorPassword", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Editors", "EditorPassword", c => c.String());
            AlterColumn("dbo.Editors", "EditorEmail", c => c.String());
            AlterColumn("dbo.Editors", "EditorUsername", c => c.String());
            AlterColumn("dbo.Editors", "EditorSurname", c => c.String());
            AlterColumn("dbo.Editors", "EditorName", c => c.String());
            AlterColumn("dbo.ContactMessages", "MessageText", c => c.String());
            AlterColumn("dbo.ContactMessages", "MessageSubject", c => c.String());
            AlterColumn("dbo.ContactMessages", "SenderEmail", c => c.String());
            AlterColumn("dbo.ContactMessages", "SenderSurname", c => c.String());
            AlterColumn("dbo.ContactMessages", "SenderName", c => c.String());
            AlterColumn("dbo.Titles", "TitleName", c => c.String());
            AlterColumn("dbo.Subtitles", "SubtitleName", c => c.String());
            AlterColumn("dbo.Writings", "WritingText", c => c.String());
            AlterColumn("dbo.Writings", "WritingTitle", c => c.String());
            AlterColumn("dbo.Members", "MemberPassword", c => c.String());
            AlterColumn("dbo.Members", "MemberEmail", c => c.String());
            AlterColumn("dbo.Members", "MemberAbout", c => c.String());
            AlterColumn("dbo.Members", "MemberJob", c => c.String());
            AlterColumn("dbo.Members", "MemberUsername", c => c.String());
            AlterColumn("dbo.Members", "MemberSurname", c => c.String());
            AlterColumn("dbo.Members", "MemberName", c => c.String());
            AlterColumn("dbo.Comments", "CommentText", c => c.String());
        }
    }
}
