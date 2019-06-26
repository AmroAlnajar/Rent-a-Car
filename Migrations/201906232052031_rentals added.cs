namespace Rent_a_Car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class rentalsadded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RentalsModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateRented = c.DateTime(nullable: false),
                        DateReturned = c.DateTime(nullable: false),
                        Car_Id = c.Int(),
                        Customer_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.Car_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.Customer_Id)
                .Index(t => t.Car_Id)
                .Index(t => t.Customer_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RentalsModels", "Customer_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.RentalsModels", "Car_Id", "dbo.Cars");
            DropIndex("dbo.RentalsModels", new[] { "Customer_Id" });
            DropIndex("dbo.RentalsModels", new[] { "Car_Id" });
            DropTable("dbo.RentalsModels");
        }
    }
}
