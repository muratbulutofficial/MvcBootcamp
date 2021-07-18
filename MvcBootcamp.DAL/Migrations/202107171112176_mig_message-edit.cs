namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_messageedit : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Messages", "Name", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.Messages", "Surname", c => c.String(nullable: false, maxLength: 150));
            AddColumn("dbo.Messages", "DateTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "EMail", c => c.String(nullable: false, maxLength: 200));
            AlterColumn("dbo.Messages", "Subject", c => c.String(nullable: false, maxLength: 150));
            DropColumn("dbo.Messages", "Sender");
            DropColumn("dbo.Messages", "Receiver");
            DropColumn("dbo.Messages", "SendDate");
            DropColumn("dbo.Messages", "ReadDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Messages", "ReadDate", c => c.DateTime());
            AddColumn("dbo.Messages", "SendDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Messages", "Receiver", c => c.Int(nullable: false));
            AddColumn("dbo.Messages", "Sender", c => c.Int(nullable: false));
            AlterColumn("dbo.Messages", "Subject", c => c.String(maxLength: 150));
            DropColumn("dbo.Messages", "DateTime");
            DropColumn("dbo.Messages", "EMail");
            DropColumn("dbo.Messages", "Surname");
            DropColumn("dbo.Messages", "Name");
        }
    }
}
