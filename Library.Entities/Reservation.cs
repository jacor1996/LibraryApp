using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Entities
{
    public class Reservation : DataObject
    {
        public string UserName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        public virtual ICollection<Book> ReservedBooks { get; set; }
    }
}
