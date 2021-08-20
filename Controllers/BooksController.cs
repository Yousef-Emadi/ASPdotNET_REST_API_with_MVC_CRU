using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using LibraryServices.Data.Repositories;
using LibraryServices.Models;

namespace LibraryServices.Controllers
{
    public class BooksController : ApiController
    {

        // private IBookRepository books = new BookRepository();  //method No1

        private IBookRepository books; //method No2 (better)

        public BooksController(IBookRepository _book)
        {
            this.books = _book;
        }

        // GET api/books
        [HttpGet] //default is get but it's a good practice to put it   
        public IEnumerable<Book> Get()
        {
            return books.GetAllBooks();
        }

        // GET api/books/5
        [HttpGet] //default is get but it's a good practice to put it
        public IHttpActionResult Get(int id)
        {
            var book = books.GetBook(id);
            if (book == null) return NotFound();
            else return Ok(book);

        }

        //model binding
        // POST 
        [HttpPost]
        public IHttpActionResult PostBook(Book book)
        {
            bool result = books.AddNewBook(book);
            if (result) return Ok(books);
            return BadRequest();
        }


        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            if (books.remove(id)) return Ok(books.GetAllBooks());
            return NotFound();
        }


        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            var ubook = books.UpdateBook(id, book);
            if (ubook != null) return Ok(ubook);
            return NotFound();

        }


    }
}
