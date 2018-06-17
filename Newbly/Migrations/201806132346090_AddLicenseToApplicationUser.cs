namespace Newbly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLicenseToApplicationUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "DrivingLicense", c => c.String(nullable: false, maxLength: 225));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "DrivingLicense");
        }
    }
}
