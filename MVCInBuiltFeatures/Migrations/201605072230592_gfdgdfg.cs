namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class gfdgdfg : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        MedicineID = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        MedTrade = c.String(),
                        MedType = c.String(),
                        MedGroup = c.String(),
                        Rem = c.String(),
                        Unit = c.String(),
                    })
                .PrimaryKey(t => t.MedicineID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
        }
    }
}
