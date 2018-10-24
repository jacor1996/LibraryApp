namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Books", "Reservation_Id", c => c.Int());
            CreateIndex("dbo.Books", "Reservation_Id");
            AddForeignKey("dbo.Books", "Reservation_Id", "dbo.Reservations", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.Books", new[] { "Reservation_Id" });
            DropColumn("dbo.Books", "Reservation_Id");
            DropTable("dbo.Reservations");
        }
    }
}
