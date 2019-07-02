namespace Rent_a_Car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTotalPrice : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Rentals", "TotalPrice", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Rentals", "TotalPrice");
        }
    }
}
