namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservations2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reservations", "UserName", c => c.String());
            DropColumn("dbo.Reservations", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reservations", "UserId", c => c.Int(nullable: false));
            DropColumn("dbo.Reservations", "UserName");
        }
    }
}
