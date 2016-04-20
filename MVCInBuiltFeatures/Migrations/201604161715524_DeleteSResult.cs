namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeleteSResult : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "Student_ID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_ID" });
            DropTable("dbo.SResults");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        result = c.String(),
                        medicine = c.String(),
                        present_illness = c.String(),
                        vital_sign = c.String(),
                        date = c.DateTime(nullable: false),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateIndex("dbo.SResults", "Student_ID");
            AddForeignKey("dbo.SResults", "Student_ID", "dbo.Students", "ID");
        }
    }
}
