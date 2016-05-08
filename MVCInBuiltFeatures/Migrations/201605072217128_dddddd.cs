namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dddddd : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Appointments", "sid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Appointments", "sid", c => c.String());
        }
    }
}
