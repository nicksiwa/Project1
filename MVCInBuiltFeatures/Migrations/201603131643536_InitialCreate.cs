namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sid = c.String(),
                        topic = c.String(),
                        date = c.DateTime(nullable: false),
                        des = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SResults",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sid = c.String(),
                        result = c.String(),
                        medicine = c.String(),
                        present_illness = c.String(),
                        vital_sign = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        sid = c.String(),
                        name = c.String(),
                        sname = c.String(),
                        tel = c.String(),
                        bloodtype = c.String(),
                        weight = c.Single(nullable: false),
                        height = c.Single(nullable: false),
                        email = c.String(),
                        drug = c.String(),
                        con_disease = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Students");
            DropTable("dbo.SResults");
            DropTable("dbo.Appointments");
        }
    }
}
