namespace MVCInBuiltFeatures.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editDBCom2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SResults", "Student_ID", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "Student_ID" });
            DropColumn("dbo.SResults", "sid");
            RenameColumn(table: "dbo.SResults", name: "Student_ID", newName: "sid");
            AddColumn("dbo.Students", "sid_t", c => c.String());
            AlterColumn("dbo.SResults", "sid", c => c.Int(nullable: false));
            AlterColumn("dbo.Students", "sid", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "sid");
            CreateIndex("dbo.SResults", "sid");
            AddForeignKey("dbo.SResults", "sid", "dbo.Students", "sid", cascadeDelete: true);
            DropColumn("dbo.Students", "ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Students", "ID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.SResults", "sid", "dbo.Students");
            DropIndex("dbo.SResults", new[] { "sid" });
            DropPrimaryKey("dbo.Students");
            AddPrimaryKey("dbo.Students", "ID");
            AlterColumn("dbo.Students", "sid", c => c.String());
            AlterColumn("dbo.SResults", "sid", c => c.Int());
            DropColumn("dbo.Students", "sid_t");
            RenameColumn(table: "dbo.SResults", name: "sid", newName: "Student_ID");
            AddColumn("dbo.SResults", "sid", c => c.Int(nullable: false));
            CreateIndex("dbo.SResults", "Student_ID");
            AddForeignKey("dbo.SResults", "Student_ID", "dbo.Students", "ID");
        }
    }
}
