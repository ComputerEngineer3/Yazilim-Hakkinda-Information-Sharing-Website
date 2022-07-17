namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EditorialApplications",
                c => new
                    {
                        EditorialApplicationID = c.Int(nullable: false, identity: true),
                        NameSurname = c.String(nullable: false),
                        Age = c.Int(nullable: false),
                        City = c.String(nullable: false),
                        PhoneNumber = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        GraduationStatus = c.String(nullable: false),
                        RelatedTitle = c.String(nullable: false),
                        RelatedTitleExperiences = c.String(nullable: false),
                        WeeklyMinStudyTime = c.Int(nullable: false),
                        ShortResume = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.EditorialApplicationID);
            
            AddColumn("dbo.Editors", "TitleID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Editors", "TitleID");
            DropTable("dbo.EditorialApplications");
        }
    }
}
