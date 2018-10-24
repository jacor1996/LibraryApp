using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class LibraryContext : DbContext
    {
        public LibraryContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new LibraryDbInitializer());
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
