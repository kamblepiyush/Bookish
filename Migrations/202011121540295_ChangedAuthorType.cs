namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedAuthorType : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Author", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Auther");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Auther", c => c.String(nullable: false));
            DropColumn("dbo.Books", "Author");
        }
    }
}
