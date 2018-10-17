using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Library.Entities;

namespace Library.WebApplication.Services
{
    public class BookCoverService
    {
        public void UpdateBookCoverData(ref Book book, string uploadPath)
        {
            string fileExtension = Path.GetExtension(book.ImageFile.FileName);

            string fileName = book.Title + fileExtension;

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            book.ImagePath = uploadPath + fileName;

            book.ImageFile.SaveAs(book.ImagePath);

            book.ImagePath = fileName;
        }
    }
}