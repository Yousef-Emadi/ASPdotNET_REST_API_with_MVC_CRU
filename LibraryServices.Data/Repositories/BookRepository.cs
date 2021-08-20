using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Repositories
{
    public class BookRepository : IBookRepository
    {

        public List<Book> books = new List<Book>()
        {
            new Book() {Id = 1, Title = "Thinking fast slow", Author = "Daniel Kahneman", PublicationYear = 2011, IsAvailable = false, CallNumber = "ABC123"},
            new Book() {Id = 2, Title = "Becoming", Author = "Michelle Obama", PublicationYear = 2018, IsAvailable = false, CallNumber = "DEF567"},
            new Book() {Id = 3, Title = "Paradox of Choice", Author = "Barry Schwartz", PublicationYear = 2004, IsAvailable = false, CallNumber = "QWERTY963"},
            new Book() {Id = 4, Title = "Homodeus", Author = "Noah Harari", PublicationYear = 2015, IsAvailable = false, CallNumber = "LKJHI987"},
            new Book() {Id = 5, Title = "The art of problem solving", Author = "Russel Ackoff", PublicationYear = 1978, IsAvailable = false, CallNumber = "ZORO963"}

        };

      

        public List<Book> GetAllBooks()
        {
            return books;
        }

        public Book GetBook(int id)
        {
            {
                var book = books.FirstOrDefault(i => i.Id == id);
                return book;

            }
        }

        public bool AddNewBook(Book book)
        {
            books.Add(book);
            return true;
        }

        public bool remove(int id)
        {
            var book = GetBook(id);
            if (book == null) return false;
            books.Remove(book);
            return true;
        }

        public List<Book> UpdateBook(int id, Book book)
        {
            if (this.remove(id))
            {
                AddNewBook(book);
                return books;
            }

            return books;


        }
    }
}
