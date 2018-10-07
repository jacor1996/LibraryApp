using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Interfaces;

namespace Library.WebApplication.Controllers
{
    public class AuthorsController : Controller
    {
        private IRepository<Author> authorRepository;
        public AuthorsController(IRepository<Author> repository)
        {
            authorRepository = repository;
        }
        // GET: Authors
        public ActionResult Index()
        {
            return View(authorRepository.GetAll());
        }

        // Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepository.Create(author);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return View(author);
        }

        public ActionResult Edit(int id)
        {
            Author author = authorRepository.GetById(id);

            if (author != null)
            {
                return View(author);
            }

            return HttpNotFound($"Author with id = {id} does not exist.");
        }

        [HttpPost]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                authorRepository.Update(author);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return View(author);
        }


        public ActionResult Delete(int id)
        {
            Author author = authorRepository.GetById(id);

            if (author != null)
            {
                authorRepository.Delete(id);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return HttpNotFound($"Author with id = {id} does not exist.");
        }

        public ActionResult Details(int id)
        {
            Author author = authorRepository.GetById(id);

            if (author != null)
            {
                return View(author);
            }

            return HttpNotFound($"Author with id = {id} does not exist.");
        }
    }
}