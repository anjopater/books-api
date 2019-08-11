using System;
using System.Collections.Generic;
using Books.Services.ViewModels;

namespace Books.Services.Services.Books
{
    public interface IBooksService
    {
        IEnumerable<BookViewModel> GetBooks();
        BookViewModel GetBook(Guid bookId);
        BookViewModel CreateBook(BookViewModel bookToCreate);
        void UpdateBook(BookViewModel bookToUpdate);
        void DeleteBook(Guid bookId);
    }
}
