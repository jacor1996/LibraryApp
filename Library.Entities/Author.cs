using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Author : DataObject
    {
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(256)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Surname is required.")]
        [StringLength(256)]
        public string Surname { get; set; }

        public ICollection<Book> Books { get; set; }
    }
}
