namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_category_seourl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Categories", "SeoUrl", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Categories", "SeoUrl");
        }
    }
}
