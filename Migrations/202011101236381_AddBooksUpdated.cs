namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddBooksUpdated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Formats",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "GenreId", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "FormatId", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "NumberInStock", c => c.Byte(nullable: false));
            AddColumn("dbo.Books", "ReleaseDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Books", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.Books", "FormatId");
            AddForeignKey("dbo.Books", "FormatId", "dbo.Formats", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "FormatId", "dbo.Formats");
            DropIndex("dbo.Books", new[] { "FormatId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            AlterColumn("dbo.Books", "Name", c => c.String());
            DropColumn("dbo.Books", "ReleaseDate");
            DropColumn("dbo.Books", "NumberInStock");
            DropColumn("dbo.Books", "FormatId");
            DropColumn("dbo.Books", "GenreId");
            DropTable("dbo.Formats");
        }
    }
}
