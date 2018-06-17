namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'2724ac5f-428d-411d-8cfb-51737a3e3577', N'Admin@nowhere.com', 0, N'AGSe7Fd5q9nqJBABP/MqcVp/dOsIm+b9ztRZLQZdtOLB5aqul6s85LgMPhLvqQ/c3w==', N'58108a6e-7fa1-4e42-bbd1-9a71e041a4ff', NULL, 0, 0, NULL, 1, 0, N'Admin@nowhere.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f907b2d3-f460-48d5-b5cb-aff6ae2f5521', N'guest@nowhere.com', 0, N'AMvqEdm4OZsC2cv3FidZ1HitGReXr8NMeUdVSb6kLTuncxjlkk84asrF6ZMmaol5uA==', N'5b4d7ef2-f83a-4c94-b955-7e17739287f4', NULL, 0, 0, NULL, 1, 0, N'guest@nowhere.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'58444165-2216-4600-96b4-4cd3a5012002', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'2724ac5f-428d-411d-8cfb-51737a3e3577', N'58444165-2216-4600-96b4-4cd3a5012002')
");
        }
        
        public override void Down()
        {
        }
    }
}
