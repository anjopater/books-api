using System;
//Import your EntityFrameworkCore that will be used to have your Context class inherit your DbContext class. using a directive.
using Microsoft.EntityFrameworkCore;
//import your Books.Domain when using your Domain classes.
using Books.Domain.Books;

namespace Books.Data
{
    //Define a context class that will inherit DbContext that will be bridge from your entity/domain classes and your database.
    public class BooksContext : DbContext
    {
        //Define a parameterless constructor that will initialize itself.
        //It will have dbCOntextOptions type which will configure your Database context, then initialize your class using it.
        public BooksContext(DbContextOptions options) : base(options) { }
        //Each table will be type of DbSet for each property and contain a generic type of your entity class.
        //Then the property being name of the table.
        public DbSet<Book> Books { get; set; }
    }
}
