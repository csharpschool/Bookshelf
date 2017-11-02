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
    }
}
