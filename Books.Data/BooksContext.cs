using Microsoft.EntityFrameworkCore;
using Books.Domain.Books;

namespace Books.Data
{
    public class BooksContext : DbContext
    {
        public BooksContext(DbContextOptions options) : base(options) { }
        public DbSet<Book> Books { get; set; }
    }
}
