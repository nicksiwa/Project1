namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newMed : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Medicines", "MedTrade", c => c.String());
            AddColumn("dbo.Medicines", "MedType", c => c.String());
            AddColumn("dbo.Medicines", "MedGroup", c => c.String());
            AddColumn("dbo.Medicines", "GrouList", c => c.String());
            AddColumn("dbo.Medicines", "GrouCon", c => c.String());
            DropColumn("dbo.Medicines", "Size");
            DropColumn("dbo.Medicines", "Description");
            DropColumn("dbo.Medicines", "EXP");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "EXP", c => c.DateTime(nullable: false));
            AddColumn("dbo.Medicines", "Description", c => c.String());
            AddColumn("dbo.Medicines", "Size", c => c.String());
            DropColumn("dbo.Medicines", "GrouCon");
            DropColumn("dbo.Medicines", "GrouList");
            DropColumn("dbo.Medicines", "MedGroup");
            DropColumn("dbo.Medicines", "MedType");
            DropColumn("dbo.Medicines", "MedTrade");
        }
    }
}
