using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;

namespace Library.WebApplication.Models
{
    public class BookViewModel
    {
        [Required]
        public Book Book { get; set; }
        [Required]
        public int SelectedAuthorId { get; set; }
    }
}