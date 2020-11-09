using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;
using Bookish.ViewModel;

namespace Bookish.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            var books = GetBooks();
            return View(books);
        }

        private IEnumerable<Book> GetBooks()
        {
            return new List<Book>
            {
                new Book{Id = 1,Name = "Let us c"},
                new Book{Id = 2,Name = "Fundamental of machine learning"},
                new Book{Id = 3,Name = "Black book of HTML5"}
            };
        }

        public ActionResult Random()
        {
            var book = new Book(){Name = "Let us C"};

            var customers = new List<Customer>
            {
                new Customer {Name = "Customer 1"},
                new Customer {Name = "Customer 2"}
            };

            var ViewModel = new RandomViewModel
            {
                Book = book,
                Customers = customers
            };

            return View(ViewModel);
            
        }
    }
}