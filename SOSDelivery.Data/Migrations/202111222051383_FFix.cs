namespace SOSDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            AlterColumn("dbo.Order", "CustomerID", c => c.Int(nullable: false));
            CreateIndex("dbo.Order", "CustomerID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            AlterColumn("dbo.Order", "CustomerID", c => c.Int());
            CreateIndex("dbo.Order", "CustomerID");
            AddForeignKey("dbo.Order", "CustomerID", "dbo.Customer", "CustomerID");
        }
    }
}
