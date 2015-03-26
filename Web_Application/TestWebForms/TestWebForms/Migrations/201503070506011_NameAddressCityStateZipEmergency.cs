namespace TestWebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameAddressCityStateZipEmergency : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "LastName", c => c.String());
            AddColumn("dbo.AspNetUsers", "Address", c => c.String());
            AddColumn("dbo.AspNetUsers", "City", c => c.String());
            AddColumn("dbo.AspNetUsers", "State", c => c.String());
            AddColumn("dbo.AspNetUsers", "Zip", c => c.Int(nullable: false));
            AddColumn("dbo.AspNetUsers", "EmergencyContactName", c => c.String());
            AddColumn("dbo.AspNetUsers", "EmergencyContactNumber", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "EmergencyContactNumber");
            DropColumn("dbo.AspNetUsers", "EmergencyContactName");
            DropColumn("dbo.AspNetUsers", "Zip");
            DropColumn("dbo.AspNetUsers", "State");
            DropColumn("dbo.AspNetUsers", "City");
            DropColumn("dbo.AspNetUsers", "Address");
            DropColumn("dbo.AspNetUsers", "LastName");
        }
    }
}
