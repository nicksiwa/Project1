namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class info : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Infoes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Header = c.String(),
                        Detail = c.String(),
                        Image = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Infoes");
        }
    }
}
