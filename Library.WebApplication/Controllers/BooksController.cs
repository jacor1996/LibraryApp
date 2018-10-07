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
        public ActionResult Index()
        {
            return View(bookRepository.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

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

        public ActionResult Edit(int id)
        {
            Book book = bookRepository.GetById(id);
            if (book != null)
            {
                return View(book);
            }

            return HttpNotFound($"Book with specified id = {id} does not exist.");
        }

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