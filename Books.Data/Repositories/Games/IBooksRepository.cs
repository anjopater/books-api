using System;
using System.Collections.Generic;
using System.Text;
//import your Books.Domain to use your book entity classes.
using Books.Domain.Books;

namespace Books.Data.Repositories.Books
{
    //Define your interface that will be used as a contract or requirements for your Repositorys.
    //We will use our interface instead of our class itself, since we can't initialize class upon creation of a service.
    //Will pass a interface instance into a constructor of a service which will define the signature of the repository.
    public interface IBooksRepository
    {
        //Define your method that will get the Books from the context, 
        //Have your return type of your method be iterable of type IEnumerable, and let it have a generic type of Book
        IEnumerable<Book> GetBooks();
        //Define another method that will get one Book which will not IEnumerable will return type of Book Domain model.
        Book GetBook(Guid bookId);
        //Define a method creating a book by passing a book domain model as a argument which would convert in our services. 
        Book CreateBook(Book createdBook);
        //Define a method for updating a book by passing a book domain model as a argument which would be converted in our services.
        void UpdateBook(Book updatedBook);
        //Define a method for deleting a Book by passing a Guid as a argument, which would retrieve a model from our context then remove it.
        void DeleteBook(Guid bookId);
    }
}
