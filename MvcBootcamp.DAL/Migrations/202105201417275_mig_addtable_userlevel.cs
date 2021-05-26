namespace MvcBootcamp.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_addtable_userlevel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserLevels",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Level = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserLevels");
        }
    }
}
