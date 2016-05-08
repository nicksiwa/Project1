namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sg : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "Medicine_MedicineID" });
            RenameColumn(table: "dbo.SResults", name: "Medicine_MedicineID", newName: "MedicineID");
            AlterColumn("dbo.SResults", "MedicineID", c => c.Int(nullable: true));
            CreateIndex("dbo.SResults", "MedicineID");
            AddForeignKey("dbo.SResults", "MedicineID", "dbo.Medicines", "MedicineID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SResults", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "MedicineID" });
            AlterColumn("dbo.SResults", "MedicineID", c => c.Int());
            RenameColumn(table: "dbo.SResults", name: "MedicineID", newName: "Medicine_MedicineID");
            CreateIndex("dbo.SResults", "Medicine_MedicineID");
            AddForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines", "MedicineID");
        }
    }
}
