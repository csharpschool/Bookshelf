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

        public IActionResult Create()
        {
            return View();
        }

    }
}
