namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "Student_StudentID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_StudentID" });
            RenameColumn(table: "dbo.SResults", name: "Student_StudentID", newName: "StudentID");
            AlterColumn("dbo.SResults", "StudentID", c => c.Int(nullable: false));
            CreateIndex("dbo.SResults", "StudentID");
            AddForeignKey("dbo.SResults", "StudentID", "dbo.Students", "StudentID", cascadeDelete: true);
            DropColumn("dbo.SResults", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SResults", "sid", c => c.Int(nullable: false));
            DropForeignKey("dbo.SResults", "StudentID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "StudentID" });
            AlterColumn("dbo.SResults", "StudentID", c => c.Int());
            RenameColumn(table: "dbo.SResults", name: "StudentID", newName: "Student_StudentID");
            CreateIndex("dbo.SResults", "Student_StudentID");
            AddForeignKey("dbo.SResults", "Student_StudentID", "dbo.Students", "StudentID");
        }
    }
}
