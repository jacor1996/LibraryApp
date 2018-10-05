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
            IList<Book> defaultBooks = new List<Book>();
            defaultBooks.Add(new Book { Title = "Miasteczko Salem", Category = "Thriller" });
            defaultBooks.Add(new Book { Title = "Pan Tadeusz", Category = "Literatura piękna" });
            defaultBooks.Add(new Book { Title = "To", Category = "Horror" });

            IList<Author> defaultAuthors = new List<Author>();
            defaultAuthors.Add(new Author { Name = "Stephen", Surname = "King" });
            defaultAuthors.Add(new Author { Name = "Adam", Surname = "Mickiewicz" });

            defaultBooks[0].Author = defaultAuthors[0];
            defaultBooks[1].Author = defaultAuthors[1];

            context.Books.AddRange(defaultBooks);
            context.Authors.AddRange(defaultAuthors);

            base.Seed(context);
        }
    }
}
