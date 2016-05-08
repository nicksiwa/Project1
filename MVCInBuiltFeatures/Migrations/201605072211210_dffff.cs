namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dffff : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Appointments");
        }
        
        public override void Down()
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
            
        }
    }
}
