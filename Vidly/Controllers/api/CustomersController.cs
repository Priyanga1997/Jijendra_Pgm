using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dto;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CustomerDto> GetCustomers()
        {
            return _context.customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>);
        }
        //public Customer GetCustomers(int id)
        public IHttpActionResult GetCustomers(int id)
        {

            var customer = _context.customers.SingleOrDefault(c => c.CustomerId == id);
            if (customer == null)
                //throw new HttpResponseException(HttpStatusCode.NotFound);
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));

        }
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
                //throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customers = Mapper.Map<CustomerDto, Customer>(customerDto);
           
            _context.customers.Add(customers);
            _context.SaveChanges();
            customerDto.CustomerId = customerDto.CustomerId;
            //return customerDto;
            return Created(new Uri(Request.RequestUri + "/" + customers.CustomerId), customerDto);
        }
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var customerInDb = _context.customers.SingleOrDefault(c => c.CustomerId == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(customerDto, customerInDb);
            //customerInDb.CustomerName = customer.CustomerName;
            //customerInDb.BirthDate = customer.BirthDate;
            //customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            //customerInDb.MembershipTypeId = customer.MembershipTypeId;
            _context.SaveChanges();


        }


        [HttpDelete]
        public void DeleteCustomer(int id)
        {

            if (ModelState.IsValid)
            {
                var customerInDb = _context.customers.SingleOrDefault(c => c.CustomerId == id);
                if (customerInDb == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);
                _context.customers.Remove(customerInDb);

                _context.SaveChanges();

            }
        }
    }
}








