using System;
using System.Collections.Generic;
using System.Linq;
using Books.Data.Repositories.Books;
using Books.Services.Factory;
using Books.Services.ViewModels;
using Books.Domain.Books;

namespace Books.Services.Services.Books.Impl
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _repository;
        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<BookViewModel> GetBooks()
        {
            IEnumerable<BookViewModel> booksReturned = _repository.GetBooks().Select(book => ModelFactory.CreateViewModel(book));
            return booksReturned;
        }

        public BookViewModel GetBook(Guid id)
        {
            BookViewModel bookToReturn = ModelFactory.CreateViewModel(_repository.GetBook(id));
            return bookToReturn;
        }

        public BookViewModel CreateBook(BookViewModel bookToCreate)
        {

            Book newBook = ModelFactory.CreateDomainModel(bookToCreate);
            _repository.CreateBook(newBook);
            return bookToCreate;
        }

        public void UpdateBook(BookViewModel bookToUpdate)
        {
            Book updatedBook = ModelFactory.CreateDomainModel(bookToUpdate);
            _repository.UpdateBook(updatedBook);
            return;
        }

        public void DeleteBook(Guid bookId)
        {
            _repository.DeleteBook(bookId);
            return;
        }
    }
}
