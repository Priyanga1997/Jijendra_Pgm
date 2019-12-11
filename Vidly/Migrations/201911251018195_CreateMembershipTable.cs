namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMembershipTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MembershipTypes",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        SignUpFree = c.Short(nullable: false),
                        DurationInMonths = c.Byte(nullable: false),
                        DiscountRate = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.Customers", "MembershipTypeId");
            AddForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes", "Id", cascadeDelete: true);
            DropColumn("dbo.Customers", "MembershipType_SignUpFree");
            DropColumn("dbo.Customers", "MembershipType_DurationInMonths");
            DropColumn("dbo.Customers", "MembershipType_DiscountRate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "MembershipType_DiscountRate", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_DurationInMonths", c => c.Byte(nullable: false));
            AddColumn("dbo.Customers", "MembershipType_SignUpFree", c => c.Short(nullable: false));
            DropForeignKey("dbo.Customers", "MembershipTypeId", "dbo.MembershipTypes");
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            DropTable("dbo.MembershipTypes");
        }
    }
}
