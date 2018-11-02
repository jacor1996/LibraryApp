namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Reservation3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Books", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.Books", new[] { "Reservation_Id" });
            CreateTable(
                "dbo.ReservationBooks",
                c => new
                    {
                        Reservation_Id = c.Int(nullable: false),
                        Book_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_Id, t.Book_Id })
                .ForeignKey("dbo.Reservations", t => t.Reservation_Id, cascadeDelete: true)
                .ForeignKey("dbo.Books", t => t.Book_Id, cascadeDelete: true)
                .Index(t => t.Reservation_Id)
                .Index(t => t.Book_Id);
            
            DropColumn("dbo.Books", "Reservation_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "Reservation_Id", c => c.Int());
            DropForeignKey("dbo.ReservationBooks", "Book_Id", "dbo.Books");
            DropForeignKey("dbo.ReservationBooks", "Reservation_Id", "dbo.Reservations");
            DropIndex("dbo.ReservationBooks", new[] { "Book_Id" });
            DropIndex("dbo.ReservationBooks", new[] { "Reservation_Id" });
            DropTable("dbo.ReservationBooks");
            CreateIndex("dbo.Books", "Reservation_Id");
            AddForeignKey("dbo.Books", "Reservation_Id", "dbo.Reservations", "Id");
        }
    }
}
