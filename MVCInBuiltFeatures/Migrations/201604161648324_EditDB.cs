namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.LoginStatus",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.SResults", "Student_ID", c => c.Int());
            CreateIndex("dbo.SResults", "Student_ID");
            AddForeignKey("dbo.SResults", "Student_ID", "dbo.Students", "ID");
            DropColumn("dbo.SResults", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SResults", "sid", c => c.String());
            DropForeignKey("dbo.SResults", "Student_ID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_ID" });
            DropColumn("dbo.SResults", "Student_ID");
            DropTable("dbo.LoginStatus");
        }
    }
}
