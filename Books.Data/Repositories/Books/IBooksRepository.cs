using System;
using System.Collections.Generic;
using Books.Domain.Books;

namespace Books.Data.Repositories.Books
{
    public interface IBooksRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBook(Guid bookId);
        Book CreateBook(Book createdBook);
        void UpdateBook(Book updatedBook);
        void DeleteBook(Guid bookId);
    }
}
