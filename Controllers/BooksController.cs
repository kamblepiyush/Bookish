using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;
using Bookish.ViewModel;
using System.Data.Entity;

namespace Bookish.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext _context;

        public BooksController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Books
        public ActionResult Index()
        {
            var books = _context.Books.Include(b => b.Genre).ToList();
            return View(books);
        }

        public ActionResult Detail(int id)
        {
            var book = _context.Books.Include(b => b.Genre).Include(b => b.Format).SingleOrDefault(b=>b.Id==id);
            return View(book);
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
            var book = new Book() { Name = "Let us C" };

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