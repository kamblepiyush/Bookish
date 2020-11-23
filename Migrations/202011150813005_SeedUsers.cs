namespace Bookish.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'0ede85c9-9858-4be0-8cf3-87d87fa70842', N'admin@bookish.com', 0, N'ANeuOAnxzdtEoAO45ZCV+1x9lWN4cOre+TRR3v2sYDo+35ly88bBsbJmoaIqOmQLdQ==', N'f7f83ed1-e263-495e-84b2-7d23fae6d7dc', NULL, 0, 0, NULL, 1, 0, N'admin@bookish.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2c3ba0e6-35c6-4190-9831-172daf50c078', N'guest@bookish.com', 0, N'AEBiK71uQbTXCmr1MsrAJa428w5N+lTZbM8XTbIFkIAMk2NzAXdzYjJXAXXH3G+NdA==', N'd94e678d-0ebb-4bf8-884f-e5f9b6433fdb', NULL, 0, 0, NULL, 1, 0, N'guest@bookish.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'1841b1b3-ea1a-42cf-92b1-bf8772719c9e', N'CanManageBooks')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'0ede85c9-9858-4be0-8cf3-87d87fa70842', N'1841b1b3-ea1a-42cf-92b1-bf8772719c9e')
");
        }
        
        public override void Down()
        {
        }
    }
}
