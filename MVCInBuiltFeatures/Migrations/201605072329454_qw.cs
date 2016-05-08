namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class qw : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "MedicineID" });
            RenameColumn(table: "dbo.SResults", name: "MedicineID", newName: "Medicine_MedicineID");
            AlterColumn("dbo.SResults", "Medicine_MedicineID", c => c.Int());
            CreateIndex("dbo.SResults", "Medicine_MedicineID");
            AddForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines", "MedicineID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "Medicine_MedicineID" });
            AlterColumn("dbo.SResults", "Medicine_MedicineID", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.SResults", name: "Medicine_MedicineID", newName: "MedicineID");
            CreateIndex("dbo.SResults", "MedicineID");
            AddForeignKey("dbo.SResults", "MedicineID", "dbo.Medicines", "MedicineID", cascadeDelete: true);
        }
    }
}
