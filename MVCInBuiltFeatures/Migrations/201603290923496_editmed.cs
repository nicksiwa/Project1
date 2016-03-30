namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editmed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Medicines", "EXP", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Medicines", "EXP", c => c.String());
        }
    }
}
