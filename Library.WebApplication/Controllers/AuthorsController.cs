﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library.Entities;
using Library.Repositories.Interfaces;
using Library.WebApplication.Services;

namespace Library.WebApplication.Controllers
{
    public class AuthorsController : Controller
    {
        private IRepository<Author> authorRepository;
        private AuthorImageService authorImageService;

        public AuthorsController(IRepository<Author> repository)
        {
            authorRepository = repository;
            authorImageService = new AuthorImageService();
        }
        // GET: Authors
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(authorRepository.GetAll());
        }

        // Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.ImageFile != null && author.ImageFile.ContentLength > 0)
                {
                    string uploadPath = Server.MapPath("~/Files/Images/");
                    authorImageService.UpdateAuthorImageData(ref author, uploadPath);
                }

                authorRepository.Create(author);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return View(author);
        }

        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(Author author)
        {
            if (ModelState.IsValid)
            {
                if (author.ImageFile != null && author.ImageFile.ContentLength > 0)
                {
                    string uploadPath = Server.MapPath("~/Files/Images/");
                    authorImageService.UpdateAuthorImageData(ref author, uploadPath);
                }

                authorRepository.Update(author);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return View(author);
        }

        [Authorize(Roles = "Admin")]
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

        [AllowAnonymous]
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