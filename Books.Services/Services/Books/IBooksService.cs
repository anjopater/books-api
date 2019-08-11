using System;
using System.Collections.Generic;
using System.Text;
//Import your view models which will be your domain model convert to view model
//which will be what we want to display to the user, in this case we do not them seeing the id of our data.
using Books.Services.ViewModels;

namespace Books.Services.Services.Books
{
    //Define your signature which will be passed into your controller file 
    //that will be responsible for retrieving data for your api from your repositories 
    public interface IBooksService
    {
        //Define a method requirement that will be responsible for retrieving data.
        IEnumerable<BookViewModel> GetBooks();
        //Define a method requirement that will be responsible for retrieving one book using the books id.
        BookViewModel GetBook(Guid bookId);
        //Define a method that will create a book using the BookViewModel that is passed via argument.
        BookViewModel CreateBook(BookViewModel bookToCreate);
        //Define a method that will update a book using the GaemViewModel that is passed via argument, but will return a 204 status code which will be void.
        void UpdateBook(BookViewModel bookToUpdate);
        //Define a method that will delete a book using a bookId via argument since it will return a 204 status code.
        void DeleteBook(Guid bookId);
    }
}
