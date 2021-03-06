namespace Narendra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingregisterEntity : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "IsActive", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Registers", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Registers", "Username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Registers", "Password", c => c.String(nullable: false, maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Password", c => c.String());
            AlterColumn("dbo.Registers", "Username", c => c.String());
            AlterColumn("dbo.Registers", "Email", c => c.String());
            DropColumn("dbo.Registers", "IsActive");
        }
    }
}
