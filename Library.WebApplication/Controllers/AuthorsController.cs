﻿using System;
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
        private IAuthorRepository authorRepository;
        public AuthorsController(IAuthorRepository repository)
        {
            authorRepository = repository;
        }
        // GET: Authors
        public ActionResult Index()
        {
            return View(authorRepository.GetAuthors());
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
                authorRepository.CreateAuthor(author);
                authorRepository.Save();

                return RedirectToAction("Index");
            }

            return View(author);
        }
    }
}