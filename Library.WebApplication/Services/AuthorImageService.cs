using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Library.Entities;

namespace Library.WebApplication.Services
{
    public class AuthorImageService
    {
        public void UpdateAuthorImageData(ref Author author, string uploadPath)
        {
            string fileExtension = Path.GetExtension(author.ImageFile.FileName);

            string fileName = author.Name + "_" + author.Surname + fileExtension;

            if (!Directory.Exists(uploadPath))
            {
                Directory.CreateDirectory(uploadPath);
            }

            author.ImagePath = uploadPath + fileName;
    
            author.ImageFile.SaveAs(author.ImagePath);
            
            author.ImagePath = fileName;
        }
    }
}