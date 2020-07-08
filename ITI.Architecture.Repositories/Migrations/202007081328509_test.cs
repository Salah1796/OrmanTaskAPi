namespace ITI.Architecture.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customer ",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Email = c.String(nullable: false, maxLength: 500),
                        Phone = c.String(nullable: false),
                        GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Group ", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
            CreateTable(
                "dbo.Group ",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Invoice Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        InvoiceID = c.Int(nullable: false),
                        ItemID = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Invoice ", t => t.InvoiceID, cascadeDelete: true)
                .ForeignKey("dbo.Item", t => t.ItemID, cascadeDelete: true)
                .Index(t => t.InvoiceID)
                .Index(t => t.ItemID);
            
            CreateTable(
                "dbo.Invoice ",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        CustomerID = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        TotalPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customer ", t => t.CustomerID, cascadeDelete: true)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Item",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 500),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Invoice Item", "ItemID", "dbo.Item");
            DropForeignKey("dbo.Invoice Item", "InvoiceID", "dbo.Invoice ");
            DropForeignKey("dbo.Invoice ", "CustomerID", "dbo.Customer ");
            DropForeignKey("dbo.Customer ", "GroupID", "dbo.Group ");
            DropIndex("dbo.Invoice ", new[] { "CustomerID" });
            DropIndex("dbo.Invoice Item", new[] { "ItemID" });
            DropIndex("dbo.Invoice Item", new[] { "InvoiceID" });
            DropIndex("dbo.Customer ", new[] { "GroupID" });
            DropTable("dbo.Item");
            DropTable("dbo.Invoice ");
            DropTable("dbo.Invoice Item");
            DropTable("dbo.Group ");
            DropTable("dbo.Customer ");
        }
    }
}
