namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenreTypesModified : DbMigration
    {
        public override void Up()
        {
            Sql("SET IDENTITY_INSERT Genres ON");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (1, 'Action & Adventure')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (2, 'Comics & Mangas')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (3, 'Computing, Internet & Digital Media')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (4, 'Fiction')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (5, 'Horror')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (6, 'Humour')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (7, 'Science & Technology')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (8, 'Romance')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (9, 'History')");
            Sql("INSERT INTO Genres (Id, GenreType) VALUES (10, 'Crime & Mystery')");
            Sql("SET IDENTITY_INSERT Genres OFF");
        }
        
        public override void Down()
        {
        }
    }
}
