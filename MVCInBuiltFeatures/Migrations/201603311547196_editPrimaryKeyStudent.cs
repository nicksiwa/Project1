namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPrimaryKeyStudent : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "Id", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Students", "Id");
        }
    }
}
