using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer

        private ApplicationDbContext _context;

        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var membershiptype = _context.MembershipTypes.ToList();
            var viewmodel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershiptype
            };
            return View("CustomerForm",viewmodel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)

        {
                if (!ModelState.IsValid)
            {
                var model = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",model);
            }

            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedtoNewsletter = customer.IsSubscribedtoNewsletter;
            }

            _context.SaveChanges();
            return RedirectToAction("ViewCustomers","Customer");
        }

        public ActionResult ViewCustomers()
        {
           
           // var view = new RandomMovieViewModel() { Customers = customers};
            return View();
        }

        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

           
            //var view = new Customer(){Id = customer.Id,Name = customer.Name};

            return View(customer);

        }

        public ActionResult Edit(int id)
        {
            var customerr = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerr == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = _context.MembershipTypes.ToList(),
                Customer = customerr
                
            };
            
           

            return View("CustomerForm", viewModel);
        }
    }
}