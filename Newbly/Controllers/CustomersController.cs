using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Runtime.Caching;

using Newbly.Models;
using Newbly.ViewModels;

namespace Newbly.Controllers
{
    // [Authorize] Can be placed on individual Actions.. It just depends.
    public class CustomersController : Controller
    {
        // Create and Initialize a disposable DbContext Object to access database
        // _context is a C# Convention?
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // Dispose the DbContext
        // Best practice is to use delegation to instantiate and dispose
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);    
        }

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel()
            {
                Customer = new Customer(), // Initalizes and set default values
                MembershipTypes = membershipTypes
            };

            return View("CustomerForm", viewModel);
        }

        public ViewResult Index()
        {
            /* Example of Data Caching
             * Cache a piece of data for different controllers
             * Here - Caching list of genres, hitting the end point here will trigger the caching of genres
             * 
             * Need to consider when the action references the cached data
             * Entity trieds to do a save with cache data?
             */
            if (MemoryCache.Default["Genres"] == null)
            {
                // if not cached, get it from database.
                MemoryCache.Default["Genres"] = _context.Genres.ToList();
            }
            // Otherwise there is already cached data
            var genres = MemoryCache.Default["Genres"] as IEnumerable<Genre>;

            return View();
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();
            return View(customer);
        }

        // Example[ValidateAntiForgeryToken] and AntiFogeryToken() to prevent CSRF and XSS attacks
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // ModelState changes the flow of the application
            if (!ModelState.IsValid)
            {
                // return whatever the user has entered
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if(customer.Id == 0)
                _context.Customers.Add(customer);
            else
            {   // Throws exception when Single is not found    
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                // Two approaches to updating the entity
                // TryUpdateModel(customerInDb);
                // The properties of the entity are updated base on the Key:Values in the Request data
                // So... if someone decides to pass in bad/new key/value pair?

                // Should use AutoMapper & Dtos
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }
            _context.SaveChanges(); 
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel); // overrides the default Edit
        }

    }
}