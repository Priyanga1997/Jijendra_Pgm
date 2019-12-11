using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModel;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
        public ViewResult Index()
        {
            var customer = _context.customers.Include(c => c.MembershipType).ToList();
            return View(customer);
        }
        //public ActionResult Index()
        //{
        //    var Customer = GetCustomers();
        //    return View(Customer);
        //}
        //public List<Customer> GetCustomers()
        //{

        //    var customers = new List<Customer>
        //    {
        //        new Customer{CustomerId=1,CustomerName="Priya"},
        //        new Customer{CustomerId=2,CustomerName="Sara"},
        //        new Customer{CustomerId=3,CustomerName="Joe"}
        //    };
        //    return (customers);



        public ActionResult Details(int id)
        {
            var Customer = _context.customers.Include(c => c.MembershipType).ToList().FirstOrDefault(a => a.CustomerId == id);
            return View(Customer);
        }
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormviewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };

            return View(viewModel);
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormviewModel()
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("New",viewModel);
            }
            else
            {
                if (customer.CustomerId == 0)
                {
                    _context.customers.Add(customer);
                }
                else
                {

                    var customers = _context.customers.FirstOrDefault(c => c.CustomerId == customer.CustomerId);
                    customers.CustomerName = customer.CustomerName;
                    customers.BirthDate = customer.BirthDate;
                    customers.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
                    customers.MembershipTypeId = customer.MembershipTypeId;
                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        }



        //[HttpPost]
        //public ActionResult Create(Customer customer)

        //{
        //    _context.customers.Add(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index","Customers");
        //}
        public ActionResult Edit(int id)
        {
            var customer = _context.customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                return HttpNotFound();
            var viewModel = new CustomerFormviewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };
            return View("New", viewModel);
        }
    }
}
       


