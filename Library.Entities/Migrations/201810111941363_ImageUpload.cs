namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUpload : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AuthorPictures",
                c => new
                    {
                        FileId = c.Int(nullable: false),
                        AuthorId = c.Int(),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Authors", t => t.FileId)
                .Index(t => t.FileId);
            
            CreateTable(
                "dbo.BookCovers",
                c => new
                    {
                        FileId = c.Int(nullable: false),
                        BookId = c.Int(),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Books", t => t.FileId)
                .Index(t => t.FileId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AuthorPictures", "FileId", "dbo.Authors");
            DropForeignKey("dbo.BookCovers", "FileId", "dbo.Books");
            DropIndex("dbo.BookCovers", new[] { "FileId" });
            DropIndex("dbo.AuthorPictures", new[] { "FileId" });
            DropTable("dbo.BookCovers");
            DropTable("dbo.AuthorPictures");
        }
    }
}
