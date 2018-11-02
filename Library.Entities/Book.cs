using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

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

        public int? AuthorId { get; set; }
        public virtual Author Author { get; set; }

        [DisplayName("Book cover")]
        public string ImagePath { get; set; }
        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
