namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_author_edit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "About", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Authors", "Status", c => c.String(nullable: false));
            AlterColumn("dbo.Authors", "EMail", c => c.String(nullable: false, maxLength: 150));
            AlterColumn("dbo.Authors", "Password", c => c.String(nullable: false, maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Authors", "Password", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Authors", "EMail", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.Authors", "About");
            DropColumn("dbo.Authors", "Status");
        }
    }
}
