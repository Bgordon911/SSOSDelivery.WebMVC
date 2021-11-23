namespace SOSDelivery.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PProducts : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Product", "RestrauntID", "dbo.Restraunt");
            DropIndex("dbo.Product", new[] { "RestrauntID" });
            AlterColumn("dbo.Product", "RestrauntID", c => c.Int());
            CreateIndex("dbo.Product", "RestrauntID");
            AddForeignKey("dbo.Product", "RestrauntID", "dbo.Restraunt", "RestrauntId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Product", "RestrauntID", "dbo.Restraunt");
            DropIndex("dbo.Product", new[] { "RestrauntID" });
            AlterColumn("dbo.Product", "RestrauntID", c => c.Int(nullable: false));
            CreateIndex("dbo.Product", "RestrauntID");
            AddForeignKey("dbo.Product", "RestrauntID", "dbo.Restraunt", "RestrauntId", cascadeDelete: true);
        }
    }
}
