namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asfff : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "Medicine_MedicineID" });
            AddColumn("dbo.SResults", "Medicine_MedicineID1", c => c.Int());
            AlterColumn("dbo.SResults", "Medicine_MedicineID", c => c.Int(nullable: true));
            CreateIndex("dbo.SResults", "Medicine_MedicineID1");
            AddForeignKey("dbo.SResults", "Medicine_MedicineID1", "dbo.Medicines", "MedicineID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SResults", "Medicine_MedicineID1", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "Medicine_MedicineID1" });
            AlterColumn("dbo.SResults", "Medicine_MedicineID", c => c.Int());
            DropColumn("dbo.SResults", "Medicine_MedicineID1");
            CreateIndex("dbo.SResults", "Medicine_MedicineID");
            AddForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines", "MedicineID");
        }
    }
}
