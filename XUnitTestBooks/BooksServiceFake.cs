using Books.Data.Repositories.Books;
using Books.Domain.Books;
using Books.Services.Services.Books;
using System;
using System.Collections.Generic;
using System.Text;

namespace XUnitTestBooks
{
    public class BooksServiceFake : IBooksService
    {
        private readonly List<Book> _books;
        public BooksServiceFake()
        {
            Book newBook1 = new Book(
                title: "Cien Anos de Soledad",
                genre: "Drama",
                releaseYear: 1990,
                autor: "Gabriel Gacia Marquez",
                imgUrl: "https://images-na.ssl-images-amazon.com/images/I/51egIZUl88L._SX336_BO1,204,203,200_.jpg"
            );

            _books = new List<Book>();
            _books.Add(newBook1);
        }

        public IEnumerable<Book> GetBooks()
        {
            IEnumerable<Book> books = _books;
            return books;
        }
        public Book GetBook(Guid bookId)
        {
            Book bookToReturn = _books.Find(book => book.Id == bookId);
            return bookToReturn;
        }
        public Book CreateBook(Book createdBook)
        {
            _books.Add(createdBook);
            return createdBook;
        }
        public void UpdateBook(Book updatedBook)
        {
            Book oldBook = _books.Find(book => book.Id == updatedBook.Id);
            int index = _books.IndexOf(oldBook);
            if (index != -1)
                _books[index] = updatedBook;
        }
        public void DeleteBook(Guid bookId)
        {
            Book bookToDelete = _books.Find(book => book.Id == bookId);
            _books.Remove(bookToDelete);
        }
    }
}
