namespace WebAPIDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version11_AddedLandline : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDtoes", "LandlineNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "Firstname", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "Lastname", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "MiddleName", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "SuffixName", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "EmployeeNumber", c => c.String(maxLength: 30));
            AlterColumn("dbo.EmployeeDtoes", "MobileNumber", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EmployeeDtoes", "MobileNumber", c => c.String());
            AlterColumn("dbo.EmployeeDtoes", "EmployeeNumber", c => c.String());
            AlterColumn("dbo.EmployeeDtoes", "SuffixName", c => c.String());
            AlterColumn("dbo.EmployeeDtoes", "MiddleName", c => c.String());
            AlterColumn("dbo.EmployeeDtoes", "Lastname", c => c.String());
            AlterColumn("dbo.EmployeeDtoes", "Firstname", c => c.String());
            DropColumn("dbo.EmployeeDtoes", "LandlineNumber");
        }
    }
}
