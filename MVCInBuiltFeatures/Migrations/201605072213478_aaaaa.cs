namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class aaaaa : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Appointments", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.Appointments", "StudentID");
            AddForeignKey("dbo.Appointments", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Appointments", "StudentID", "dbo.Students");
            DropIndex("dbo.Appointments", new[] { "StudentID" });
            DropColumn("dbo.Appointments", "StudentID");
        }
    }
}
