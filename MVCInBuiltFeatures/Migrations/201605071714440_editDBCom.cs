namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDBCom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SResults", "sid", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SResults", "sid");
        }
    }
}
