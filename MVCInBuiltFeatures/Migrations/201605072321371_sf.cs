namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sf : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SResults", "Medicine_MedicineID", c => c.Int());
            CreateIndex("dbo.SResults", "Medicine_MedicineID");
            AddForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines", "MedicineID");
            DropColumn("dbo.SResults", "medicine");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SResults", "medicine", c => c.String());
            DropForeignKey("dbo.SResults", "Medicine_MedicineID", "dbo.Medicines");
            DropIndex("dbo.SResults", new[] { "Medicine_MedicineID" });
            DropColumn("dbo.SResults", "Medicine_MedicineID");
        }
    }
}
