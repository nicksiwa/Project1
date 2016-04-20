namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EditMoreComplex : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SResults", "SResultID", c => c.Int(nullable: false));
            DropColumn("dbo.SResults", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.SResults", "sid", c => c.String());
            DropColumn("dbo.SResults", "SResultID");
        }
    }
}
