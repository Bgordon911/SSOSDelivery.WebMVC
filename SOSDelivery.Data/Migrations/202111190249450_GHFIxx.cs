namespace SOSDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GHFIxx : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(),
                        OwnerId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.OrderID)
                .ForeignKey("dbo.Customer", t => t.CustomerID)
                .Index(t => t.CustomerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Order", "CustomerID", "dbo.Customer");
            DropIndex("dbo.Order", new[] { "CustomerID" });
            DropTable("dbo.Order");
        }
    }
}
