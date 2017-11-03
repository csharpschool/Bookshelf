using Bookshelf.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Services
{
    public interface IBookData
    {
        IEnumerable<Book> GetAll();
        Book Get(int id);
        void Add(Book newBook);
        int Commit();
        void Delete(int id);
    }
}
