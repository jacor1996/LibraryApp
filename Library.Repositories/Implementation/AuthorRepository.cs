using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.Repositories.Implementation
{
    public class AuthorRepository : IAuthorRepository
    {
        private LibraryContext _context;

        public AuthorRepository()
        {
            _context = new LibraryContext();
        }

        public IEnumerable<Author> GetAuthors()
        {
            return _context.Authors.ToList();
        }

        public Author GetAuthorById(int id)
        {
            return _context.Authors.Find(id);
        }

        public void CreateAuthor(Author author)
        {
            _context.Authors.Add(author);
            Save();
        }

        public void UpdateAuthor(Author author)
        {
            _context.Entry(author).State = EntityState.Modified;
        }

        public void DeleteAuthor(int id)
        {
            Author authorToDelete = GetAuthorById(id);
            _context.Authors.Remove(authorToDelete);
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}