using System;
using System.Collections.Generic;
using System.Text;
//import Linq for performing database methods to retrieve/create/update and delete data from your context class.
using System.Linq;
//import your Domain class library for using your Entity classes.
using Books.Domain.Books;

namespace Books.Data.Repositories.Books.Impl
{
    //Have your Books Repository class follow your IBooksRepository interface signature.
    public class BooksRepository : IBooksRepository
    {
        //Define a private variable of type BooksCOntext used to retrieve data from database.
        //Have it private since you are not using it outside this class.
        private BooksContext _context;
        //Define a constructor that will pass a context variable as a argument.
        public BooksRepository(BooksContext context)
        {
            //Have your private variable which will be responsible retrieving data from database.
            _context = context;
        }
        //Now define your methods that will be responsible for retrieving data..
        public IEnumerable<Book> GetBooks()
        {
            //Assign a variable of your return type. 
            //The toList method will convert your Books returned to a IEnumerable instead of List.
            IEnumerable<Book> books = _context.Books.ToList();
            //Now return the books 
            return books;
        }
        //Now define a method that will responsible for retrieving one book by using a id as a argument.
        public Book GetBook(Guid bookId)
        {
            //Assign a variable of your return type.
            //Have it find a specific books based on a id via argument.
            Book bookToReturn = _context.Books.FirstOrDefault(book => book.Id == bookId);
            //Return the book retrieved.
            return bookToReturn;
        }
        //Now define a method that will be responsible for creating a new book via argument.
        public Book CreateBook(Book createdBook)
        {
            //We will add our created book to our Books property in our context which will insert it into our database.
            _context.Books.Add(createdBook);
            //Then we will save our changes in our context classes.
            _context.SaveChanges();
            //Now just return the created book.
            return createdBook;
        }
        //Now define a method that will be responsible for updating a book via argument, our service will return void .
        public void UpdateBook(Book updatedBook)
        {
            //Now update the book using your argument.
            _context.Books.Update(updatedBook);
            //Now save your changes to your context classes.
            _context.SaveChanges();
            return;
        }
        //Now define a method that will be responsible for deleting a book via a Guid argument, and will return void since our service is returning void.
        public void DeleteBook(Guid bookId)
        {
            //Find the book your are gonna delete using linq first or default method that will return the first element if it exists.
            //Compare each book's id to your bookId argument.
            Book bookToDelete = _context.Books.FirstOrDefault(book => book.Id == bookId);
            //Then if your book is not null delete that book.
            if (bookToDelete != null) _context.Books.Remove(bookToDelete);
            //Then save changes.
            _context.SaveChanges();
            //Return out of the function.
            return;
        }
    }
}
