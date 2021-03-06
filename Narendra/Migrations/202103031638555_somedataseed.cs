namespace Narendra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class somedataseed : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Registers", "Admin", c => c.String(maxLength: 20));
            AlterColumn("dbo.Registers", "Invigiltor", c => c.String(maxLength: 20));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Registers", "Invigiltor", c => c.String(nullable: true, maxLength: 20));
            AlterColumn("dbo.Registers", "Admin", c => c.String(nullable: true, maxLength: 20));
        }
    }
}
