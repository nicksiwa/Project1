namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editPrimatyKeyStudent2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Students", "sid", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Students", "sid", c => c.Int(nullable: false));
        }
    }
}
