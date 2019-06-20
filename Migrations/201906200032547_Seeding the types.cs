namespace Rent_a_Car.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Seedingthetypes : DbMigration
    {
        public override void Up()
        {
            Sql(@"

SET IDENTITY_INSERT Types ON


INSERT INTO Types (Id, Name) VALUES (1, 'Economy');
INSERT INTO Types (Id, Name) VALUES (2, 'Compact');
INSERT INTO Types (Id, Name) VALUES (3, 'Standard');
INSERT INTO Types (Id, Name) VALUES (4, 'Midsize');
INSERT INTO Types (Id, Name) VALUES (5, 'Full Size');
INSERT INTO Types (Id, Name) VALUES (6, 'Special Car');




");
        }

        public override void Down()
        {
        }
    }
}
