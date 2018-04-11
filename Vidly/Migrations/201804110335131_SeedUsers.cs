namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'6c960c9a-4028-4b29-9c97-114f80286c0a', N'manavpanchal1223@gmail.com', 0, N'ACXxc1U+CQjZ+1Ck0fL7c9CXEQWmZGjgF99LFvuZ6pX/1aTf+URQdcF+I0aaNrMLnA==', N'80309470-7dbf-471e-8172-8265c93fb662', NULL, 0, 0, NULL, 1, 0, N'manavpanchal1223@gmail.com')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9caf6c26-2037-45fb-bbbf-5544e7a23e43', N'admin@vidly.com', 0, N'ACBQvAh6SEA8t4iSd9EMXqCK3f1vuxh/wFGgd78U57XOGEfsoSegyhYnYG+af3zygg==', N'f076ba17-6c31-4b53-819d-7c769c0ce82b', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'eb4d295d-f727-4933-bca8-74901f3d6b76', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9caf6c26-2037-45fb-bbbf-5544e7a23e43', N'eb4d295d-f727-4933-bca8-74901f3d6b76')

            ");
        }
        
        public override void Down()
        {
        }
    }
}
