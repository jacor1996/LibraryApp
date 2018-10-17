using Library.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Library.Services
{
    public class BookCoverService
    {
        public Book SaveBookCover(Book book)
        {
            //To Get File Extension  
            string fileExtension = Path.GetExtension(book.ImageFile.FileName);

            string fileName = book.Title + fileExtension;

            //Get Upload path from Web.Config file AppSettings.  
            string uploadPath = Server.MapPath("~/Files/Covers/");
            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            //Its Create complete path to store in server.  
            book.ImagePath = uploadPath + fileName;

            //To copy and save file into server.  
            book.ImageFile.SaveAs(book.ImagePath);

            book.ImagePath = fileName;
        }
    }
}
