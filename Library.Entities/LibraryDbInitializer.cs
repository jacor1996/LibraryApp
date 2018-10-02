using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Library.Entities
{
    public class LibraryDbInitializer : CreateDatabaseIfNotExists<LibraryContext>
    {
        protected override void Seed(LibraryContext context)
        {
            IList<Book> defaultBooks = new List<Book>();
            defaultBooks.Add(new Book { Title = "Miasteczko Salem", Category = "Thriller" });
            defaultBooks.Add(new Book { Title = "Pan Tadeusz", Category = "Literatura piękna" });
            defaultBooks.Add(new Book { Title = "To", Category = "Horror" });

            IList<Author> defaultAuthors = new List<Author>();
            defaultAuthors.Add( new Author { Name = "Stephen", Surname = "King", BookId = defaultBooks.ElementAt(0).Id});
            defaultAuthors.Add( new Author { Name = "Adam", Surname = "Mickiewicz", BookId = defaultBooks.ElementAt(1).Id});

            context.Books.AddRange(defaultBooks);
            context.Authors.AddRange(defaultAuthors);

            base.Seed(context);
        }
    }
}