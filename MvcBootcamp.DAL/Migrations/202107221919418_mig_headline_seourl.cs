namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_headline_seourl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Headlines", "SeoUrl", c => c.String(nullable: false, maxLength: 300));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Headlines", "SeoUrl");
        }
    }
}
