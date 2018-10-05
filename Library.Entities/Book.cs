using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Book : DataObject
    {
        [Required(ErrorMessage = "Title is required.")]
        [StringLength(256)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Category is required.")]
        [StringLength(256)]
        public string Category { get; set; }

        public Author Author { get; set; }
    }
}
