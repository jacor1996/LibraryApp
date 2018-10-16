namespace Library.Entities.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using System.Collections.Generic;

    internal sealed class Configuration : DbMigrationsConfiguration<Library.Entities.LibraryContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Library.Entities.LibraryContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
            context.Books.AddOrUpdate(
                x => x.Id,
                new Book { Id = 1, Title = "Miasteczko Salem", Category = "Thriller" },
                new Book { Id = 2, Title = "Pan Tadeusz", Category = "Literatura piękna" },
                new Book { Id = 3, Title = "To", Category = "Horror" }
                );
            

            context.Authors.AddOrUpdate(
                x => x.Id,
                new Author { Id = 1, Name = "Stephen", Surname = "King" },
                new Author { Id = 2, Name = "Adam", Surname = "Mickiewicz" }
                );

            base.Seed(context);
        }
    }
}
