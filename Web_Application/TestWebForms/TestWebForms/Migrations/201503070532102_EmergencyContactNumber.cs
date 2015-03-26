namespace TestWebForms.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EmergencyContactNumber : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.AspNetUsers", "EmergencyContactNumber", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.AspNetUsers", "EmergencyContactNumber", c => c.Int(nullable: false));
        }
    }
}
