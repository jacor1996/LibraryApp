using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.Repositories.Implementation
{
    public class BooksRepository : Repository<Book>
    {
        public BooksRepository(LibraryContext context) : base(context)
        {
            
        }

        public override IEnumerable<Book> GetAll()
        {
            return _context.Books
                .Include(a => a.Author);
        }

        public override void Update(Book book)
        {
            Book updatedBook = _context.Books.FirstOrDefault(x => x.Id == book.Id);

            if (updatedBook != null)
            {
                //updatedBook.Author = book.Author;
                updatedBook.AuthorId = book.AuthorId;
                updatedBook.Category = book.Category;
                updatedBook.ImageFile = book.ImageFile;
                updatedBook.ImagePath = book.ImagePath;
                updatedBook.Title = book.Title;
            }
        }
         

        
    }
}
