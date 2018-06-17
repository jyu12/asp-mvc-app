using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;

using Newbly.Models;
using Newbly.Dtos;

namespace Newbly.Controllers.Api
{
    /*
     * Example of a Web API in ASP.NET
     * 
     * The response are by default XMLs and in PascalNotation
     * Configured in App_Start/WebApiConfig
     * 
     * IHttpActionResult - Helpers for writing Restful APIs
     * return BadRequest vs throw new HttpResponseException(HttpStatusCode.BadRequest)
     * */
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers
        // string query optional params for Typeahead
        public IHttpActionResult GetCustomers(string query = null)
        {
            var customersQueryable = _context.Customers
                .Include(c => c.MembershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customersQueryable = customersQueryable.Where(c => c.Name.Contains(query));

            var customerDtos = customersQueryable
                .ToList()
                .Select(Mapper.Map<Customer, CustomerDto>);

            return Ok(customerDtos);
        }

        // GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.Single(c => c.Id == id);

            if (customer == null)
                return NotFound();
            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customers
        [HttpPost]
        // Or use ASP's convention naming like PostCustomer(Customer customer)
        public IHttpActionResult CreateCustomer(CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(); 
            var customer = Mapper.Map<CustomerDto, Customer>(dto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            dto.Id = customer.Id;
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), dto);
        }

        // PUT /api/customers/1
        // Update a customer - return void or the DTO
        [HttpPut]
        public IHttpActionResult UpdateCustmer(int id, CustomerDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (existingCustomer == null)
                return NotFound();
            Mapper.Map(dto, existingCustomer);

            // Without using something like AutoMapper..
            // existingCustomer.Name = dto.Name;
            // existingCustomer.Birthdate = dto.Birthdate;
            // existingCustomer.MembershipTypeId= dto.MembershipTypeId;
            // existingCustomer.IsSubscribedToNewsletter = dto.IsSubscribedToNewsletter;

            _context.SaveChanges();
            return Ok();
        }

        // DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();
            var existingCustomer = _context.Customers.SingleOrDefault(c => c.Id == id);

            _context.Customers.Remove(existingCustomer);
            _context.SaveChanges();

            return Ok();
        }
    }
}
