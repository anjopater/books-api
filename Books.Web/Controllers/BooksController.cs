using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//import your Services to access your repository which therefore will access your context, then will access your database.
using Books.Services.Services.Books;
using Books.Services.ViewModels;

namespace Books.Web.Controllers
{
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        //Now assign a private variable to a signature of your BooksService.
        private IBooksService _booksService;
        //NOw assign the value passed in via the Startup cs file to your books service.
        public BooksController(IBooksService booksService)
        {
            _booksService = booksService;
        }
        // GET api/books
        //Return a 200 status code, with your data.
        //Have all your methods return the Signature of ActionResult called IActionResult
        //Have a data annotation or decorate your method indicating it is a get http request.
        [HttpGet]
        public IActionResult Get()
        {
            //Assign the data you are getting from the service to variable.
            IEnumerable<BookViewModel> books = _booksService.GetBooks();
            //Now return a 200 status code via the Ok method and the data you would want to return.
            return Ok(books);
        }

        // GET api/books/Guid
        //Return a 200 status code with your data.
        //Have a data annotation or decorate your method indicating it is a get http request.
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            //Assign the single book you are getting from the service to variable.
            BookViewModel book = _booksService.GetBook(id);
            //Now return a 200 status code via the Ok method and the data you would want to return.  
            return Ok(book);
        }

        // POST api/books
        //Have a data annotation or decorate your method indicating your method is http post request.
        [HttpPost]
        //Have your argument be your view model, since it will be a object.
        //Have your method return a IActionResult.
        public IActionResult Post([FromBody] BookViewModel bookForm)
        {
            //Assign the result of creating your book.
            BookViewModel bookToReturn = _booksService.CreateBook(bookForm);
            //REturn a 201 status in the form of Created which is type of IACtionResult.
            //With a return url as first argument, and your data as a second argument.
            return Created("createbook", bookToReturn);
        }

        // PUT api/books/update-book
        //Have a data annotation or decorate your method indicating your method is a http patch request.
        [HttpPatch("update-book")]
        //Have your argument be your view model since it will be a object.
        //Have it return a IActionREsult
        public IActionResult Update([FromBody] BookViewModel bookForm)
        {
            //Update your book.
            _booksService.UpdateBook(bookForm);
            //Then return a 204 status code which will return noCOntent.
            return NoContent();
        }

        // DELETE api//books/delete-book/Guid
        //Have a data annotation or decorate your method indicating your method is a http delete request.
        [HttpDelete("delete-book/{id}")]
        //Have your argument be a id
        //Have it return a IActionResult
        public IActionResult Delete(Guid id)
        {
            //Delete your book.
            _booksService.DeleteBook(id);
            //Now return a 204 status code which will be NoCOntent.
            return NoContent();
        }
    }
}
