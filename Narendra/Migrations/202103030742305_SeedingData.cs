namespace Narendra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedingData : DbMigration
    {
        public override void Up()
        {
            Sql("insert into Roles(Title) values('Administrator')");
            Sql("insert into Roles(Title) values('Invigilator')");
            Sql("insert into Roles(Title) values('Student')");
        }
        
        public override void Down()
        {
        }
    }
}
