namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Secondmigration : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Books", name: "Author_Id", newName: "AuthorId");
            RenameIndex(table: "dbo.Books", name: "IX_Author_Id", newName: "IX_AuthorId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Books", name: "IX_AuthorId", newName: "IX_Author_Id");
            RenameColumn(table: "dbo.Books", name: "AuthorId", newName: "Author_Id");
        }
    }
}
