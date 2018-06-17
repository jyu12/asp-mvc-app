using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Web.Mvc;
using Newbly.Models;
using Newbly.ViewModels;

using System.Data.Entity;


namespace Newbly.Controllers
{
    public class MoviesController : Controller
    {

        /* example of using Attribute Routing
         * contraint funtion also can int, float, etc
         * [Route("movies/released/{year}/{month}")]
         * public ActionResult ByReleaseDate(int year, int month)
         * {
         *    return Content(year + "/" + month);
         * }
         */

        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        // Example of authorization at role level
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.Genres.ToList();
            var viewModel = new MovieFormViewModel()
            {
                Genres = genres,
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            if (movie.Id == 0)
            {
                movie.DateAdded = DateTime.Today;
                _context.Movies.Add(movie);
            }
            else
            {
                // user AutoMapper
                var existingMovie = _context.Movies.Single(m => m.Id == movie.Id);
                existingMovie.Name = movie.Name;
                existingMovie.ReleaseDate = movie.ReleaseDate;
                existingMovie.Stock = movie.Stock;
                existingMovie.GenreId = movie.GenreId;
                //existingMovie.DateAdded = movie.DateAdded;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        [Authorize(Roles = RoleName.CanManageMovies)]
        public ActionResult Edit(int Id)
        {
            var movie = _context.Movies.Single(m => m.Id == Id);

            if (movie == null)
                return HttpNotFound();

            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = _context.Genres.ToList()
            };

            return View("MovieForm", viewModel);
        }

        public ActionResult Details(int Id)
        {
            var detail = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == Id);

            if (detail == null)
                return HttpNotFound();
            return View(detail);
        }
        
        public ActionResult Index()
        {
            // .IsInRole access the current user
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("List");
            return View("ReadOnlyList");
        }
    }
}