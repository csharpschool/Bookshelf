using Bookshelf.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookshelf.Data
{
    public class BookDbContext : DbContext 
    {
        public DbSet<Book> Books { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
