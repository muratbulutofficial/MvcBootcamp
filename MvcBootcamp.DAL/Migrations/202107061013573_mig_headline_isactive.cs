namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headline_isactive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headlines", "isActive", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headlines", "isActive");
        }
    }
}
