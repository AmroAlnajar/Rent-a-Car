namespace Rent_a_Car.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addingsomeattributestosecuretheinput : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Cars", "Make", c => c.String(nullable: false));
            AlterColumn("dbo.Cars", "Mod", c => c.String(nullable: false));
            AlterColumn("dbo.Types", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Types", "Name", c => c.String());
            AlterColumn("dbo.Cars", "Mod", c => c.String());
            AlterColumn("dbo.Cars", "Make", c => c.String());
        }
    }
}
