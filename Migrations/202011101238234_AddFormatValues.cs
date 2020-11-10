namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFormatValues : DbMigration
    {
        public override void Up()
        {
            Sql("INSERT INTO Formats (Id, Name) VALUES (1, 'E-Book')");
            Sql("INSERT INTO Formats (Id, Name) VALUES (2, 'AudioBook')");
            Sql("INSERT INTO Formats (Id, Name) VALUES (3, 'Paper Back')");
            Sql("INSERT INTO Formats (Id, Name) VALUES (4, 'Hard Cover')");
            Sql("INSERT INTO Formats (Id, Name) VALUES (5, 'First Copy')");
        }
        
        public override void Down()
        {
        }
    }
}
