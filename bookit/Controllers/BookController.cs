﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using bookit.Data;
using bookit.Models;
using Microsoft.AspNetCore.Authorization;

namespace bookit.Controllers
{
    [Authorize(Roles ="Admin")]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;
        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }
       
        public IActionResult Index()
        {
            var model = _db.Books;
            return View(model);
        }

        [AllowAnonymous]
        [Route("book/gallery/{term?}")]
        public IActionResult Gallery( string term="")
        {
            IEnumerable<Book> model;
            if (string.IsNullOrEmpty(term))
            {
                model = _db.Books;
            }
            else
            {
                model = _db.Books.Where(b => b.Name.Contains(term));
            }
           
            return View(model);
        }

        [AllowAnonymous]

        public IActionResult More(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Book model)
        {
            _db.Books.Add(model);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int id)
        {
            var model = _db.Books.Find(id);
                return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(Book model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _db.SaveChanges();
            
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var model = _db.Books.Find(id);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete(Book model)
        {
            _db.Entry(model).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            _db.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}