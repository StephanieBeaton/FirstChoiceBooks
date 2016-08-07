namespace FirstChoiceBooks.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FKChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PaymentOrderAmounts", "Order_Id", "dbo.Orders");
            DropForeignKey("dbo.PaymentOrderAmounts", "Payment_Id", "dbo.Payments");
            DropIndex("dbo.PaymentOrderAmounts", new[] { "Order_Id" });
            DropIndex("dbo.PaymentOrderAmounts", new[] { "Payment_Id" });
            RenameColumn(table: "dbo.PaymentOrderAmounts", name: "Order_Id", newName: "OrderId");
            RenameColumn(table: "dbo.PaymentOrderAmounts", name: "Payment_Id", newName: "PaymentId");
            RenameColumn(table: "dbo.Payments", name: "Customer_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.Payments", name: "IX_Customer_Id", newName: "IX_CustomerId");
            AlterColumn("dbo.PaymentOrderAmounts", "OrderId", c => c.Int(nullable: false));
            AlterColumn("dbo.PaymentOrderAmounts", "PaymentId", c => c.Int(nullable: false));
            CreateIndex("dbo.PaymentOrderAmounts", "OrderId");
            CreateIndex("dbo.PaymentOrderAmounts", "PaymentId");
            AddForeignKey("dbo.PaymentOrderAmounts", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PaymentOrderAmounts", "PaymentId", "dbo.Payments", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PaymentOrderAmounts", "PaymentId", "dbo.Payments");
            DropForeignKey("dbo.PaymentOrderAmounts", "OrderId", "dbo.Orders");
            DropIndex("dbo.PaymentOrderAmounts", new[] { "PaymentId" });
            DropIndex("dbo.PaymentOrderAmounts", new[] { "OrderId" });
            AlterColumn("dbo.PaymentOrderAmounts", "PaymentId", c => c.Int());
            AlterColumn("dbo.PaymentOrderAmounts", "OrderId", c => c.Int());
            RenameIndex(table: "dbo.Payments", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Payments", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.PaymentOrderAmounts", name: "PaymentId", newName: "Payment_Id");
            RenameColumn(table: "dbo.PaymentOrderAmounts", name: "OrderId", newName: "Order_Id");
            CreateIndex("dbo.PaymentOrderAmounts", "Payment_Id");
            CreateIndex("dbo.PaymentOrderAmounts", "Order_Id");
            AddForeignKey("dbo.PaymentOrderAmounts", "Payment_Id", "dbo.Payments", "Id");
            AddForeignKey("dbo.PaymentOrderAmounts", "Order_Id", "dbo.Orders", "Id");
        }
    }
}
