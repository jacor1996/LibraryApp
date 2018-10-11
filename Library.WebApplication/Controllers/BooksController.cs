using System;
using System.Collections.Generic;
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