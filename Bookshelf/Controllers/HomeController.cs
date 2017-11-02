using Bookshelf.Entities;
using Bookshelf.Models;
using Bookshelf.Services;
using Bookshelf.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Controllers
{
    public class HomeController : Controller
    {
        private IBookData _books;
        public HomeController(IBookData books)
        {
            _books = books;
        }

        public ViewResult Index()
        {
            var model = _books.GetAll().Select(book =>
                new BookViewModel
                {
                    Id = book.Id,
                    Title = book.Title,
                    Genre = book.Genre.ToString()
                });

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var model = _books.Get(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(new BookViewModel
                {
                    Id = model.Id,
                    Title = model.Title,
                    Genre = model.Genre.ToString()
                }
            );
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BookEditViewModel model)
        {
            var book = new Book
            {
                Title = model.Title,
                Genre = model.Genre
            };

            _books.Add(book);
            _books.Commit();

            return RedirectToAction("Details", new { id = book.Id });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var book = _books.Get(id);

            if (book == null) return RedirectToAction("Index");

            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, BookEditViewModel model)
        {
            var book = _books.Get(id);

            if (book == null || !ModelState.IsValid) return View(model);

            book.Title = model.Title;
            book.Genre = model.Genre;

            _books.Commit();

            return RedirectToAction("Details", new { id = book.Id });
        }


    }
}
