namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class med : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medicines",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        MedName = c.String(),
                        Rem = c.String(),
                        Size = c.String(),
                        Unit = c.String(),
                        Description = c.String(),
                        EXP = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medicines");
        }
    }
}
