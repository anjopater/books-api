using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Books.Services.Services.Books;
using Books.Services.ViewModels;

namespace Books.Web.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private IBooksService _booksService;
   
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
   
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<BookViewModel> books = _booksService.GetBooks();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            BookViewModel book = _booksService.GetBook(id);
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post([FromBody] BookViewModel bookForm)
        {
            BookViewModel bookToReturn = _booksService.CreateBook(bookForm);
            return Created("createbook", bookToReturn);
        }

        // PUT api/books/update-book
        [HttpPatch("update-book")]
        public IActionResult Update([FromBody] BookViewModel bookForm)
        {
            _booksService.UpdateBook(bookForm);
            return NoContent();
        }

        // DELETE api//books/delete-book/Guid
        [HttpDelete("delete-book/{id}")]
        public IActionResult Delete(Guid id)
        {
            _booksService.DeleteBook(id);
            return NoContent();
        }
    }
}
