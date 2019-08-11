using Books.Services.Services.Books;
using Books.Services.Services.Books.Impl;
using Books.Web.Controllers;
using System;
using Xunit;

namespace XUnitTestBooks
{
    public class BookControllerTest
    {
        BooksService _service;
        BooksController _controller;
        
        public BookControllerTest() {
            _service = new BooksServiceFake();
            _controller = new BooksController(_service);
        }

        [Fact]
        public void Test1()
        {

        }
    }
}
