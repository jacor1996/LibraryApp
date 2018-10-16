namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AuthorPictures", "FileId", "dbo.Authors");
            DropForeignKey("dbo.BookCovers", "FileId", "dbo.Books");
            DropIndex("dbo.AuthorPictures", new[] { "FileId" });
            DropIndex("dbo.BookCovers", new[] { "FileId" });
            DropColumn("dbo.AuthorPictures", "AuthorId");
            DropColumn("dbo.BookCovers", "BookId");
            RenameColumn(table: "dbo.AuthorPictures", name: "FileId", newName: "AuthorId");
            RenameColumn(table: "dbo.BookCovers", name: "FileId", newName: "BookId");
            DropPrimaryKey("dbo.AuthorPictures");
            DropPrimaryKey("dbo.BookCovers");
            AlterColumn("dbo.AuthorPictures", "FileId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.AuthorPictures", "AuthorId", c => c.Int(nullable: false));
            AlterColumn("dbo.BookCovers", "FileId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.BookCovers", "BookId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.AuthorPictures", "FileId");
            AddPrimaryKey("dbo.BookCovers", "FileId");
            CreateIndex("dbo.AuthorPictures", "AuthorId");
            CreateIndex("dbo.BookCovers", "BookId");
            AddForeignKey("dbo.AuthorPictures", "AuthorId", "dbo.Authors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.BookCovers", "BookId", "dbo.Books", "Id", cascadeDelete: true);
            DropColumn("dbo.Authors", "AuthorPictureId");
            DropColumn("dbo.Books", "BookCoverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "BookCoverId", c => c.Int());
            AddColumn("dbo.Authors", "AuthorPictureId", c => c.Int());
            DropForeignKey("dbo.BookCovers", "BookId", "dbo.Books");
            DropForeignKey("dbo.AuthorPictures", "AuthorId", "dbo.Authors");
            DropIndex("dbo.BookCovers", new[] { "BookId" });
            DropIndex("dbo.AuthorPictures", new[] { "AuthorId" });
            DropPrimaryKey("dbo.BookCovers");
            DropPrimaryKey("dbo.AuthorPictures");
            AlterColumn("dbo.BookCovers", "BookId", c => c.Int());
            AlterColumn("dbo.BookCovers", "FileId", c => c.Int(nullable: false));
            AlterColumn("dbo.AuthorPictures", "AuthorId", c => c.Int());
            AlterColumn("dbo.AuthorPictures", "FileId", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.BookCovers", "FileId");
            AddPrimaryKey("dbo.AuthorPictures", "FileId");
            RenameColumn(table: "dbo.BookCovers", name: "BookId", newName: "FileId");
            RenameColumn(table: "dbo.AuthorPictures", name: "AuthorId", newName: "FileId");
            AddColumn("dbo.BookCovers", "BookId", c => c.Int());
            AddColumn("dbo.AuthorPictures", "AuthorId", c => c.Int());
            CreateIndex("dbo.BookCovers", "FileId");
            CreateIndex("dbo.AuthorPictures", "FileId");
            AddForeignKey("dbo.BookCovers", "FileId", "dbo.Books", "Id");
            AddForeignKey("dbo.AuthorPictures", "FileId", "dbo.Authors", "Id");
        }
    }
}
