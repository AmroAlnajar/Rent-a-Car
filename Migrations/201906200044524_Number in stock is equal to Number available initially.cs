namespace Rent_a_Car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NumberinstockisequaltoNumberavailableinitially : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Cars SET NumberAvailable = NumberInStock ");
        }
        
        public override void Down()
        {
        }
    }
}
