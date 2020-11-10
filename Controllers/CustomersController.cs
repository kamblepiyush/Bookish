using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;
using System.Data.Entity;

namespace Bookish.Controllers
{
    public class CustomersController : Controller
    {
        //Querying objects
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context=new ApplicationDbContext();;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Include is used for eager loading, because Entity Framework doesnt load related objects
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c=> c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new  Customer{ Id = 1, Name = "Piyush" },
                new Customer{ Id = 2, Name = "Ajinkya" },
                new Customer{ Id=3, Name = "Neelam" },
                new Customer{ Id = 4, Name = "Prasanna" }
            };
        }
    }
}