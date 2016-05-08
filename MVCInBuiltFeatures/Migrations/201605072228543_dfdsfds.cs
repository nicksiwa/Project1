namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dfdsfds : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Medicines");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        MedTrade = c.String(),
                        MedType = c.String(),
                        MedGroup = c.String(),
                        Rem = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
    }
}
