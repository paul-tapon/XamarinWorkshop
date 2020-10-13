namespace WebAPIDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version12 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeeDtoes", "Department", c => c.String(maxLength: 30));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EmployeeDtoes", "Department");
        }
    }
}
