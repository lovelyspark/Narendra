namespace Narendra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdataadd1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Registers", "ConfirmPassword", c => c.String());
           
        }
        
        public override void Down()
        {
           
           
        }
    }
}
