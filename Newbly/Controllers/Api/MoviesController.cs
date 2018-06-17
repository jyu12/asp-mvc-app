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
    public class MoviesController : ApiController
    {

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        // GET/api/Movies
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQueryable = _context.Movies.Include(m => m.Genre);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQueryable = moviesQueryable.Where(m => m.Name.Contains(query) && m.NumberAvailable > 0);

            var dtos = moviesQueryable.ToList().Select(Mapper.Map<Movie, MovieDto>);
      
            return Ok(dtos);
        }

        // GET/api/movies/1
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();
            return Ok(Mapper.Map<Movie, MovieDto>(movie));
        }

        // POST/api/movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto dto)
        {
            //var existing = _context.Movies.SingleOrDefault(m => m.Id == dto.Id);
            if (!ModelState.IsValid)
                return BadRequest();
            var movie = Mapper.Map<MovieDto, Movie>(dto);

            _context.Movies.Add(movie);
            _context.SaveChanges();

            dto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), dto);
        }

        // PUT/api/movies
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existing = _context.Movies.Single(m => m.Id == id);
            if (existing == null)
                return NotFound();

            Mapper.Map(dto, existing);
            _context.SaveChanges();

            return Ok();
        }

        // DELETE/api/movies/1
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var existing = _context.Movies.Single(m => m.Id == id);
            if (existing == null)
                return NotFound();

            _context.Movies.Remove(existing);
            _context.SaveChanges();
            return Ok();
        }
    }
}
