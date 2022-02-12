namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedAccountTable : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AddColumn("dbo.Accounts", "Email", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Accounts", "FName", c => c.String());
            AddColumn("dbo.Accounts", "LName", c => c.String());
            AddPrimaryKey("dbo.Accounts", "Email");
            DropColumn("dbo.Accounts", "Username");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Username", c => c.String(nullable: false, maxLength: 128));
            DropPrimaryKey("dbo.Accounts");
            DropColumn("dbo.Accounts", "LName");
            DropColumn("dbo.Accounts", "FName");
            DropColumn("dbo.Accounts", "Email");
            AddPrimaryKey("dbo.Accounts", "Username");
        }
    }
}
