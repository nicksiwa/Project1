namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "sid", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "sid" });
            AddColumn("dbo.SResults", "Student_StudentID", c => c.Int());
            AddColumn("dbo.Students", "StudentID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "StudentID");
            CreateIndex("dbo.SResults", "Student_StudentID");
            AddForeignKey("dbo.SResults", "Student_StudentID", "dbo.Students", "StudentID");
            DropColumn("dbo.Students", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "sid", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.SResults", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_StudentID" });
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "sid");
            DropColumn("dbo.Students", "StudentID");
            DropColumn("dbo.SResults", "Student_StudentID");
            CreateIndex("dbo.SResults", "sid");
            AddForeignKey("dbo.SResults", "sid", "dbo.Students", "sid", cascadeDelete: true);
        }
    }
}
