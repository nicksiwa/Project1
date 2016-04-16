namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSResult : DbMigration
    {
        public override void Up()
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
                        sid = c.String(),
                        Student_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_ID)
                .Index(t => t.Student_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SResults", "Student_ID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_ID" });
            DropTable("dbo.SResults");
        }
    }
}
