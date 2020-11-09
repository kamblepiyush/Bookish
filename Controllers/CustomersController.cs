using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;

namespace Bookish.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            var customers = GetCustomers();
            return View(customers);
        }

        public ActionResult Detail(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);

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