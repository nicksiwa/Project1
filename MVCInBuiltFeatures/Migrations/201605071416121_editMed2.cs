namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editMed2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Medicines", "GrouList");
            DropColumn("dbo.Medicines", "GrouCon");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Medicines", "GrouCon", c => c.String());
            AddColumn("dbo.Medicines", "GrouList", c => c.String());
        }
    }
}
