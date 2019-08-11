using System;
using System.Collections.Generic;
using System.Linq;
using Books.Domain.Books;

namespace Books.Data.Repositories.Books.Impl
{
    public class BooksRepository : IBooksRepository
    {
        private BooksContext _context;
        public BooksRepository(BooksContext context)
        {
            _context = context;
        }
        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = _context.Books.ToList();
            return books;
        }
        public Book GetBook(Guid bookId)
        {
            Book bookToReturn = _context.Books.FirstOrDefault(book => book.Id == bookId);
            return bookToReturn;
        }
        public Book CreateBook(Book createdBook)
        {
            _context.Books.Add(createdBook);
            _context.SaveChanges();
            return createdBook;
        }
        public void UpdateBook(Book updatedBook)
        {
            _context.Books.Update(updatedBook);
            _context.SaveChanges();
            return;
        }
        public void DeleteBook(Guid bookId)
        {
            Book bookToDelete = _context.Books.FirstOrDefault(book => book.Id == bookId);
            if (bookToDelete != null) _context.Books.Remove(bookToDelete);
            _context.SaveChanges();
            return;
        }
    }
}
