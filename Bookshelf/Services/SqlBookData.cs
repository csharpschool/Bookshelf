using Bookshelf.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookshelf.Entities;

namespace Bookshelf.Services
{
    public class SqlBookData : IBookData
    {
        private BookDbContext _db;

        public SqlBookData(BookDbContext db)
        {
            _db = db;
        }

        public void Add(Book newBook)
        {
            _db.Add(newBook);
        }

        public int Commit()
        {
            return _db.SaveChanges();
        }

        public Book Get(int id)
        {
            return _db.Find<Book>(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return _db.Books;
        }

        public void Delete(int id)
        {
            var book = Get(id);

            if (book == null) return;

            _db.Remove(book);
        }

    }
}
