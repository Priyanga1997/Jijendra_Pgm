namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dce04a2f-61dd-4358-a989-152306dcd4ec', N'manage@gmail.com', 0, N'AOsB6k+sj0akFcn311i3AxP4Gj7XXtLhzmkMDqeEuiamM9XpGS0qiblgrcnACwBi0w==', N'373bf688-81df-44f6-bd43-f57735df52b9', NULL, 0, 0, NULL, 1, 0, N'manage@gmail.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8d6c1a28-3769-433e-a33b-a00acdc3f76a', N'CanManageMovies')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dce04a2f-61dd-4358-a989-152306dcd4ec', N'8d6c1a28-3769-433e-a33b-a00acdc3f76a')


");

        }

    public override void Down()
        {
        }
    }
}
