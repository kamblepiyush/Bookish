using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bookish.Models;
using System.Data.Entity;
using Bookish.ViewModel;

namespace Bookish.Dtos
{
    public class CustomersController : Controller
    {
        //Querying objects
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext(); ;
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult New()
        {
            var membershiptypes = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershiptypes
            };
            return View("CustomerForm", viewmodel);
        }

        [HttpPost] //If ur actions modify data, they should never be accessible via HttpGet.
        [ValidateAntiForgeryToken] //Compares Forgery Token With its encrypted cookie for CSRF.
        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Save(Customer customer)
        {
            // Adding validation which uses data annotations from model
            if (!ModelState.IsValid)
            {
                var viewmodel=new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes
                };
                return View("CustomerForm", viewmodel);
            }

            if (customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        // GET: Customers
        public ActionResult Index()
        {
            //Include is used for eager loading, because Entity Framework doesn't load related objects
            //var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            //return View(customers);

            if(User.IsInRole(RoleName.CanManageBooks))
                return View("List");

            return View("ReadOnlyList");
        }

        public ActionResult Detail(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        [Authorize(Roles = RoleName.CanManageBooks)]
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewmodel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewmodel);
        }
    }
}