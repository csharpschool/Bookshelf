using Bookshelf.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Controllers
{
    public class HomeController
    {
        private IBookData _books;
        public HomeController(IBookData books)
        {
            _books = books;
        }

        public string Index()
        {
            return "Hello, from the controller!";
        }
    }
}
