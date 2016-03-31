namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editSResultID : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "sid", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "sid");
            DropColumn("dbo.Students", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ID", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "ID");
            AlterColumn("dbo.Students", "sid", c => c.String());
        }
    }
}
