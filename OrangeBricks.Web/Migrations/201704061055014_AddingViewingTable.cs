namespace OrangeBricks.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingViewingTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Viewings",
                c => new
                    {
                        ViewingId = c.Int(nullable: false, identity: true),
                        ViewingtDateTime = c.DateTime(nullable: false),
                        ViewStatusId = c.Int(nullable: false),
                        BuyerId = c.String(maxLength: 128),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(nullable: false),
                        ViewStatus_StatusId = c.Int(),
                        Property_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ViewingId)
                .ForeignKey("dbo.AspNetUsers", t => t.BuyerId)
                .ForeignKey("dbo.ViewStatus", t => t.ViewStatus_StatusId)
                .ForeignKey("dbo.Properties", t => t.Property_Id)
                .Index(t => t.BuyerId)
                .Index(t => t.ViewStatus_StatusId)
                .Index(t => t.Property_Id);
            
            CreateTable(
                "dbo.ViewStatus",
                c => new
                    {
                        StatusId = c.Int(nullable: false, identity: true),
                        StatusName = c.String(),
                    })
                .PrimaryKey(t => t.StatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Viewings", "Property_Id", "dbo.Properties");
            DropForeignKey("dbo.Viewings", "ViewStatus_StatusId", "dbo.ViewStatus");
            DropForeignKey("dbo.Viewings", "BuyerId", "dbo.AspNetUsers");
            DropIndex("dbo.Viewings", new[] { "Property_Id" });
            DropIndex("dbo.Viewings", new[] { "ViewStatus_StatusId" });
            DropIndex("dbo.Viewings", new[] { "BuyerId" });
            DropTable("dbo.ViewStatus");
            DropTable("dbo.Viewings");
        }
    }
}
