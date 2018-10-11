using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class AuthorPicture : File
    {
        public int? AuthorId { get; set; }
        [Required]
        public virtual Author Author { get; set; }
    }
}
