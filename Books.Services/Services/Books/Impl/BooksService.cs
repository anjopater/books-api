using System;
using System.Collections.Generic;
using System.Text;
//import LInq for performing database methods.
using System.Linq;
//import your Repository class for retrieving data from your context class.
using Books.Data.Repositories.Books;
//import your Factory for converting domain models to view models.
using Books.Services.Factory;
//import your view models to display data for the user.
using Books.Services.ViewModels;
using Books.Domain.Books;

namespace Books.Services.Services.Books.Impl
{
    //Have your BooksService class follow the IBooksService signature.
    public class BooksService : IBooksService
    {
        //Define a private variable that will hold your repository that will be responsible for retrieving data from context class.
        private IBooksRepository _repository;
        //Define a constructor that will take your Repository interface as an argument, and assign it to a private variable.
        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }
        //Define methods that you will use to get data from your repository
        public IEnumerable<BookViewModel> GetBooks()
        {
            //Now assign the data your get from the repository to variable of your return type, and loop over the data returned.
            //Have a lambda that convert each value to a view model.
            IEnumerable<BookViewModel> booksReturned = _repository.GetBooks().Select(book => ModelFactory.CreateViewModel(book));
            //NOw return the books 
            return booksReturned;
        }
        //Define a method that will reponsible for retrieving just one books based on the title 
        //and we will convert the returned value as a view model
        public BookViewModel GetBook(Guid id)
        {
            //Now assign the data your are getting from the repository, and convert it to a data presentable to user.
            BookViewModel bookToReturn = ModelFactory.CreateViewModel(_repository.GetBook(id));
            //now return the data.
            return bookToReturn;
        }
        //Now define a method responsible for creating a new book.
        public BookViewModel CreateBook(BookViewModel bookToCreate)
        {
            //Convert the argument suitable to be created using the ModelFactory.CreateDomainModel.
            Book newBook = ModelFactory.CreateDomainModel(bookToCreate);
            //Create the book
            _repository.CreateBook(newBook);
            //Once successful return the argument.
            return bookToCreate;
        }
        //NOw define a method responsible for update a book
        public void UpdateBook(BookViewModel bookToUpdate)
        {
            //Convert the argument suitable to be updated using the ModelFactory.CreateDomainModel
            Book updatedBook = ModelFactory.CreateDomainModel(bookToUpdate);
            //Update the book using the repository UpdateBook method.
            _repository.UpdateBook(updatedBook);
            //If the method is successful return out of the function.
            return;
        }
        //Now define a method responsible for deleting a book.
        public void DeleteBook(Guid bookId)
        {
            //Pass the id to the repository.
            _repository.DeleteBook(bookId);
            //If successful return out of the method.
            return;
        }
    }
}
