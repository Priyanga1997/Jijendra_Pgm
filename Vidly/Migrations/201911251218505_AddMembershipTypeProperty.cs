namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddMembershipTypeProperty : DbMigration
    {
        public override void Up()
        {
            Sql("Update MembershipType set MembershipTypeName='yearly' where id=1");
            Sql("Update MembershipType set MembershipTypeName='Half yearly' where id=2");
            Sql("Update MembershipType set MembershipTypeName='Quarterly' where id=3");
            Sql("Update MembershipType set MembershipTypeName='yearly' where id=4");

        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "MembershipTypeName");
        }
    }
}
