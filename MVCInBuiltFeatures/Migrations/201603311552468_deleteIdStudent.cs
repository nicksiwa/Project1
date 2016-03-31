namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteIdStudent : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Students", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false));
        }
    }
}
