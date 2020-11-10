namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAutherInBooks : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "Auther", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "Auther");
        }
    }
}
