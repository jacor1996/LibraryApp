namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImageUpload2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Authors", "AuthorPictureId", c => c.Int());
            AddColumn("dbo.Books", "BookCoverId", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Books", "BookCoverId");
            DropColumn("dbo.Authors", "AuthorPictureId");
        }
    }
}
