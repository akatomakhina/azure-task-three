namespace ProductProjectAzure.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Production.Product",
                c => new
                    {
                        ProductID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        ProductNumber = c.String(nullable: false),
                        MakeFlag = c.Boolean(nullable: false),
                        FinishedGoodsFlag = c.Boolean(nullable: false),
                        Color = c.String(nullable: false),
                        SafetyStockLevel = c.Short(nullable: false),
                        ReorderPoint = c.Short(nullable: false),
                        StandardCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ListPrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Size = c.String(nullable: false),
                        SizeUnitMeasureCode = c.String(nullable: false),
                        WeightUnitMeasureCode = c.String(nullable: false),
                        Weight = c.Decimal(precision: 18, scale: 2),
                        DaysToManufacture = c.Int(nullable: false),
                        ProductLine = c.String(nullable: false),
                        Class = c.String(nullable: false),
                        Style = c.String(nullable: false),
                        ProductSubcategoryID = c.Int(),
                        ProductModelID = c.Int(),
                        SellStartDate = c.DateTime(nullable: false),
                        SellEndDate = c.DateTime(),
                        DiscontinuedDate = c.DateTime(),
                        rowguid = c.Guid(nullable: false),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ProductID);
            
            CreateTable(
                "Production.TransactionHistory",
                c => new
                    {
                        TransactionID = c.Int(nullable: false, identity: true),
                        ProductID = c.Int(nullable: false),
                        ReferenceOrderID = c.Int(nullable: false),
                        ReferenceOrderLineID = c.Int(nullable: false),
                        TransactionDate = c.DateTime(nullable: false),
                        TransactionType = c.String(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ActualCost = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ModifiedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TransactionID)
                .ForeignKey("Production.Product", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.ProductID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("Production.TransactionHistory", "ProductID", "Production.Product");
            DropIndex("Production.TransactionHistory", new[] { "ProductID" });
            DropTable("Production.TransactionHistory");
            DropTable("Production.Product");
        }
    }
}
