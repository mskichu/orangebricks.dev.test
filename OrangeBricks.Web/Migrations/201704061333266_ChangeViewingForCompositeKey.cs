namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeViewingForCompositeKey : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Viewings", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.Viewings", "BuyerId", "dbo.AspNetUsers");
            DropIndex("dbo.Viewings", new[] { "BuyerId" });
            DropIndex("dbo.Viewings", new[] { "Property_Id" });
            RenameColumn(table: "dbo.Viewings", name: "Property_Id", newName: "PropertyID");
            DropPrimaryKey("dbo.Viewings");
            AlterColumn("dbo.Viewings", "BuyerId", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Viewings", "PropertyID", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Viewings", new[] { "BuyerId", "PropertyID" });
            CreateIndex("dbo.Viewings", "BuyerId");
            CreateIndex("dbo.Viewings", "PropertyID");
            AddForeignKey("dbo.Viewings", "PropertyID", "dbo.Properties", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Viewings", "BuyerId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "BuyerId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Viewings", "PropertyID", "dbo.Properties");
            DropIndex("dbo.Viewings", new[] { "PropertyID" });
            DropIndex("dbo.Viewings", new[] { "BuyerId" });
            DropPrimaryKey("dbo.Viewings");
            AlterColumn("dbo.Viewings", "PropertyID", c => c.Int());
            AlterColumn("dbo.Viewings", "BuyerId", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Viewings", "ViewingId");
            RenameColumn(table: "dbo.Viewings", name: "PropertyID", newName: "Property_Id");
            CreateIndex("dbo.Viewings", "Property_Id");
            CreateIndex("dbo.Viewings", "BuyerId");
            AddForeignKey("dbo.Viewings", "BuyerId", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.Viewings", "Property_Id", "dbo.Properties", "Id");
        }
    }
}
