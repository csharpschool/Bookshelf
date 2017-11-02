using Bookshelf.Models;

namespace Bookshelf.ViewModels
{
    public class BookEditViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Genres Genre { get; set; }
    }
}
