namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateAccounts : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Username", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Accounts", "Username");
            DropColumn("dbo.Accounts", "Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Accounts", "Id", c => c.Int(nullable: false, identity: true));
            DropPrimaryKey("dbo.Accounts");
            AlterColumn("dbo.Accounts", "Username", c => c.String());
            AddPrimaryKey("dbo.Accounts", "Id");
        }
    }
}
