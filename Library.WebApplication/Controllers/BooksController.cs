using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Implementation;
using Library.Repositories.Interfaces;
using Library.WebApplication.Models;
using Library.WebApplication.Services;

namespace Library.WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private IRepository<Book> bookRepository;
        private IRepository<Author> authorRepository;
        private BookCoverService bookCoverService;

        public BooksController(IRepository<Book> repository, IRepository<Author> authorRepository)
        {
            bookRepository = repository;
            this.authorRepository = authorRepository;
            bookCoverService = new BookCoverService();
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
            ViewBag.Authors = PopulateAuthorsDropDownList();
            return View();
        }
        
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Create(BookViewModel model, HttpPostedFileBase ImageFile)
        {
            ViewBag.Authors = PopulateAuthorsDropDownList();

            if (ModelState.IsValid)
            {
                Book bookToCreate = model.Book;
                Author author = authorRepository.GetById(model.SelectedAuthorId);

                bookToCreate.AuthorId = author.Id;
                bookToCreate.Author = author;

                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    bookToCreate.ImageFile = ImageFile;
                    string uploadPath = Server.MapPath("~/Files/Covers/");
                    bookCoverService.UpdateBookCoverData(ref bookToCreate, uploadPath);
                }

                bookRepository.Create(bookToCreate);
                bookRepository.Save();

                return RedirectToAction("Index");
            }

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            ViewBag.Authors = PopulateAuthorsDropDownList();
            BookViewModel model = new BookViewModel();
            Book book = bookRepository.GetById(id);
            model.Book = book;
            model.SelectedAuthorId =  book.AuthorId.GetValueOrDefault(1);

            if (model.Book != null)
            {
                return View(model);
            }

            return HttpNotFound($"Book with specified id = {id} does not exist.");
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Edit(BookViewModel model, HttpPostedFileBase ImageFile, int id)
        {
            ViewBag.Authors = PopulateAuthorsDropDownList();
            if (ModelState.IsValid)
            {
                Book bookToCreate = bookRepository.GetById(id);
                
                Author author = authorRepository.GetById(model.SelectedAuthorId);

                bookToCreate.AuthorId = author.Id;
                //bookToCreate.Author = author;
                

                if (ImageFile != null && ImageFile.ContentLength > 0)
                {
                    bookToCreate.ImageFile = ImageFile;
                    string uploadPath = Server.MapPath("~/Files/Covers/");
                    bookCoverService.UpdateBookCoverData(ref bookToCreate, uploadPath);
                }

                //string uploadPath = Server.MapPath("~/Files/Covers/");
                //bookCoverService.UpdateBookCoverData(ref book, uploadPath);
                //bookRepository.Update(bookToCreate);
               // bookRepository.Save();
                bookRepository.Update(bookToCreate);
                bookRepository.Save();

                return RedirectToAction("Index");
            }

            return View(model);
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

         private IEnumerable<SelectListItem> PopulateAuthorsDropDownList()
        {
            var authors = authorRepository.GetAll()
                .Select(n =>
                    new SelectListItem()
                    {
                        Value = n.Id.ToString(),
                        Text = $"{n.Name} {n.Surname}"
                    }).ToList();

            return new SelectList(authors, "Value", "Text");
        }
    }
}