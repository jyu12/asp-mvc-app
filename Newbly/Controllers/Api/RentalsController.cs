using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Newbly.Models;
using Newbly.Dtos;
using AutoMapper;

namespace Newbly.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult AddRentals(RentalDto dto)
        {
            /* Defensive Styling - when API is public
             * Validations everywhere.
            if (dto.MovieIds.Count() == 0)
                return BadRequest("No Movie Ids supplied.");

            var customer = _context.Customers.SingleOrDefault(c => c.Id == dto.CustomerId);

            if (customer == null)
                return BadRequest("Customer Id not found.");
            var movieList = _context.Movies.Where(m => dto.MovieIds.Contains(m.Id)); // select * form movies where Id in (1,2,3)

            foreach (var movie in movieList)
            {
                if (movie.NumberAvailable > 0)
                {
                    var rental = new Rental()
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Today,
                        DateReturned = null
                    };
                    _context.Rentals.Add(rental);
                    movie.NumberAvailable--;
                }
                else
                    return BadRequest(movie.Name + " not Available.");
            }
            _context.SaveChanges(); 
            
            return Ok(); // not a single new obj. Multiple Objs. Can't return one single URI
            */

            var customer = _context.Customers.Single(c => c.Id == dto.CustomerId);

            var movieList = _context.Movies.Where(m => dto.MovieIds.Contains(m.Id)).ToList(); 

            foreach (var movie in movieList)
            {
                if (movie.NumberAvailable > 0)
                {
                    var rental = new Rental()
                    {
                        Customer = customer,
                        Movie = movie,
                        DateRented = DateTime.Today,
                        DateReturned = null
                    };
                    _context.Rentals.Add(rental);
                    movie.NumberAvailable--;
                }
                else
                    return BadRequest(movie.Name + " not Available.");
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
