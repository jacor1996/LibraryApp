using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Book : DataObject
    {
        public string Title { get; set; }
        public string Category { get; set; }

        public ICollection<Author> Authors { get; set; }
    }
}
