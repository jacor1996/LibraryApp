namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Bookcover : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Books", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "ImagePath");
        }
    }
}
