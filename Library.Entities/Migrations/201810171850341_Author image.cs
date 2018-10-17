namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Authorimage : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Authors", "ImagePath");
        }
    }
}
