namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig4 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Editors", "TitleID");
            AddForeignKey("dbo.Editors", "TitleID", "dbo.Titles", "TitleID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Editors", "TitleID", "dbo.Titles");
            DropIndex("dbo.Editors", new[] { "TitleID" });
        }
    }
}
