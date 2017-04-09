namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingViewStatusForiegnKeyRelations : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viewings", "ViewStatus_StatusId", "dbo.ViewStatus");
            DropIndex("dbo.Viewings", new[] { "ViewStatus_StatusId" });
            DropColumn("dbo.Viewings", "ViewStatusId");
            RenameColumn(table: "dbo.Viewings", name: "ViewStatus_StatusId", newName: "ViewStatusId");
            AlterColumn("dbo.Viewings", "ViewStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Viewings", "ViewStatusId");
            AddForeignKey("dbo.Viewings", "ViewStatusId", "dbo.ViewStatus", "StatusId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "ViewStatusId", "dbo.ViewStatus");
            DropIndex("dbo.Viewings", new[] { "ViewStatusId" });
            AlterColumn("dbo.Viewings", "ViewStatusId", c => c.Int());
            RenameColumn(table: "dbo.Viewings", name: "ViewStatusId", newName: "ViewStatus_StatusId");
            AddColumn("dbo.Viewings", "ViewStatusId", c => c.Int(nullable: false));
            CreateIndex("dbo.Viewings", "ViewStatus_StatusId");
            AddForeignKey("dbo.Viewings", "ViewStatus_StatusId", "dbo.ViewStatus", "StatusId");
        }
    }
}
