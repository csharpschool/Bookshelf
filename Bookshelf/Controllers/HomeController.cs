using Bookshelf.Services;
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
            var model = _books.Get(1);
            return View(model);
        }
    }
}
