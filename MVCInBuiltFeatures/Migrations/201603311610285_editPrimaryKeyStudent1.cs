namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPrimaryKeyStudent1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Students", "ID", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Students", "sid", c => c.Int(nullable: false));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "ID");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "sid");
            AlterColumn("dbo.Students", "sid", c => c.Int(nullable: false, identity: true));
            DropColumn("dbo.Students", "ID");
        }
    }
}
