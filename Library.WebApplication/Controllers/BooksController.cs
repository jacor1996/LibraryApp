using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private IRepository<Book> bookRepository;

        public BooksController(IRepository<Book> repository)
        {
            bookRepository = repository;
        }

        // GET: Books
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(bookRepository.GetAll());
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                //To Get File Extension  
                string FileExtension = Path.GetExtension(book.ImageFile.FileName);

                string FileName = book.Title + FileExtension;

                //Get Upload path from Web.Config file AppSettings.  
                string UploadPath = Server.MapPath("~/Files/Covers/");
                if (!Directory.Exists(UploadPath))
                {
                    Directory.CreateDirectory(UploadPath);
                }

                //Its Create complete path to store in server.  
                book.ImagePath = UploadPath + FileName;

                //To copy and save file into server.  
                book.ImageFile.SaveAs(book.ImagePath);

                book.ImagePath = FileName;

                bookRepository.Create(book);

                bookRepository.Save();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Book book = bookRepository.GetById(id);
            if (book != null)
            {
                return View(book);
            }

            return HttpNotFound($"Book with specified id = {id} does not exist.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                bookRepository.Update(book);
                bookRepository.Save();

                return RedirectToAction("Index");
            }

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int id)
        {
            Book book = bookRepository.GetById(id);

            if (book != null)
            {
                bookRepository.Delete(id);
                bookRepository.Save();

                return RedirectToAction("Index");
            }

            return HttpNotFound($"Book with specified id = {id} does not exist.");
        }

        [AllowAnonymous]
        public ActionResult Details(int id)
        {
            Book book = bookRepository.GetById(id);

            if (book != null)
            {
                return View(book);
            }

            return HttpNotFound($"Book with specified id = {id} does not exist.");
        }
    }
}