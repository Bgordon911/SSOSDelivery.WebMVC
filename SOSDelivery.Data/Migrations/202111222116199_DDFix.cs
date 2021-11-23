namespace SOSDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DDFix : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Product_ProductId", c => c.Int());
            CreateIndex("dbo.Order", "Product_ProductId");
            AddForeignKey("dbo.Order", "Product_ProductId", "dbo.Product", "ProductId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "Product_ProductId", "dbo.Product");
            DropIndex("dbo.Order", new[] { "Product_ProductId" });
            DropColumn("dbo.Order", "Product_ProductId");
        }
    }
}
