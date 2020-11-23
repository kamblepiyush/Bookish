using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;
using Bookish.ViewModel;
using System.Data.Entity;

namespace Bookish.Dtos
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
            //var books = _context.Books.Include(b => b.Genre).ToList();
            //return View(books);

            if (User.IsInRole(RoleName.CanManageBooks))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Detail(int id)
        {
            var book = _context.Books.Include(b => b.Genre).Include(b => b.Format).SingleOrDefault(b => b.Id == id);
            return View(book);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var viewmodel = new BookFormViewModel
            {
                Genres = _context.Genres.ToList(),
                Formats = _context.Formats.ToList(),
            };
            return View("BookForm", viewmodel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Book book)
        {
            if (!ModelState.IsValid)
            {
                var viewmodel =new BookFormViewModel(book)
                {
                    Genres = _context.Genres.ToList(),
                    Formats = _context.Formats.ToList()
                };

                return View("BookForm", viewmodel);
            }

            if (book.Id == 0)
                _context.Books.Add(book);
            else
            {
                var bookInDb = _context.Books.Single(b => b.Id == book.Id);

                bookInDb.Name = book.Name;
                bookInDb.Author = book.Author;
                bookInDb.GenreId = book.GenreId;
                bookInDb.ReleaseDate = book.ReleaseDate;
                bookInDb.FormatId = book.FormatId;
                bookInDb.NumberInStock = book.NumberInStock;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Books");
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var book = _context.Books.SingleOrDefault(b => b.Id == id);

            if (book == null)
                return HttpNotFound();

            var viewmodel = new BookFormViewModel(book)
            {
                Genres = _context.Genres.ToList(),
                Formats = _context.Formats.ToList()
            };

            return View("BookForm", viewmodel);
        }
    }
}