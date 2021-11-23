namespace SOSDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SDFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "Product_ProductId" });
            RenameColumn(table: "dbo.Order", name: "Product_ProductId", newName: "ProductId");
            AlterColumn("dbo.Order", "ProductId", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "ProductId");
            AddForeignKey("dbo.Order", "ProductId", "dbo.Product", "ProductId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "ProductId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "ProductId" });
            AlterColumn("dbo.Order", "ProductId", c => c.Int());
            RenameColumn(table: "dbo.Order", name: "ProductId", newName: "Product_ProductId");
            CreateIndex("dbo.Order", "Product_ProductId");
            AddForeignKey("dbo.Order", "Product_ProductId", "dbo.Product", "ProductId");
        }
    }
}
