namespace Rent_a_Car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class smallchange : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RentalsModels", newName: "Rentals");
            DropIndex("dbo.Rentals", new[] { "Car_Id" });
            RenameColumn(table: "dbo.Rentals", name: "Car_Id", newName: "CarId");
            RenameColumn(table: "dbo.Rentals", name: "Customer_Id", newName: "CustomerId");
            RenameIndex(table: "dbo.Rentals", name: "IX_Customer_Id", newName: "IX_CustomerId");
            AlterColumn("dbo.Rentals", "CarId", c => c.Int(nullable: false));
            CreateIndex("dbo.Rentals", "CarId");
            AddForeignKey("dbo.Rentals", "CarId", "dbo.Cars", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Rentals", "CarId", "dbo.Cars");
            DropIndex("dbo.Rentals", new[] { "CarId" });
            AlterColumn("dbo.Rentals", "CarId", c => c.Int());
            RenameIndex(table: "dbo.Rentals", name: "IX_CustomerId", newName: "IX_Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "CustomerId", newName: "Customer_Id");
            RenameColumn(table: "dbo.Rentals", name: "CarId", newName: "Car_Id");
            CreateIndex("dbo.Rentals", "Car_Id");
            AddForeignKey("dbo.RentalsModels", "Car_Id", "dbo.Cars", "Id");
            RenameTable(name: "dbo.Rentals", newName: "RentalsModels");
        }
    }
}
