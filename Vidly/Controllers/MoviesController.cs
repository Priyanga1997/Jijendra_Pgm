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
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Shrek!" };
        //    return View(movie);
        //    //return HttpNotFound();
        //    //return RedirectToAction("Index", "Home");
        //}
        //public ActionResult Edit(int id)
        //{
        //    return Content("id=" +id);
        //}
        //public ActionResult Index(int? pageIndex,string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //        pageIndex = 1;
        //    if(String.I)
        //}
        //public ActionResult ByReleaseDate(int year,int month)
        //{
        //    return Content()
        //}
        private ApplicationDbContext _context;
        public MoviesController()
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
        [Authorize]
        public ActionResult Index()
        {
            //var Movies = _context.movies.Include(c => c.Genre).ToList();
            if (User.IsInRole(RoleName.CanManageMovies))
                return View("Index");

            return View("ReadOnlyList");

        }
        [Authorize(Roles =RoleName.CanManageMovies)]
        public ActionResult New()
        {
            var genres = _context.genres.ToList();
            var viewModel = new NewMovieViewModel
            {
                //Movie=new Movie(),
               Genres=genres
        };
            

            return View("New",viewModel);

        }
        //[HttpPost]
        //public ActionResult Create(Movie movie)

        //{
        //    _context.movies.Add(movie);
        //    movie.DateTime = DateTime.Now;
        //    _context.SaveChanges();
        //    return RedirectToAction("Index", "Movies");
        //}
        public ActionResult Edit(int id)
        {
            var movie = _context.movies.Single(c => c.Id == id);
            if (movie == null)
                return HttpNotFound();
            var viewModel = new NewMovieViewModel
            {
                Movie = movie,
                Genres = _context.genres.ToList()

            };
            return View("New", viewModel);
        }
        [HttpPost]
       [ValidateAntiForgeryToken]
        public ActionResult Update(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewMovieViewModel()
                {
                    Movie = movie,
                    Genres = _context.genres.ToList()
                };
                return View("New", viewModel);
            }
            else
            {

                if (movie.Id == 0)
                {
                    _context.movies.Add(movie);
                }
                else
                {

                    var Movies = _context.movies.FirstOrDefault(c => c.Id == movie.Id);
                    Movies.Name = movie.Name;
                    Movies.ReleaseDate = movie.ReleaseDate;
                    Movies.Genre = movie.Genre;
                    Movies.AvailableInStock = movie.AvailableInStock;



                }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
            }
        }
        

//public List<Movie> GetMovies()
//{
//    var movies = new List<Movie>
//    {
//        new Movie {Id=1,Name="KGF" },
//         new Movie {Id=2,Name="NVP" },
//          new Movie {Id=3,Name="Pattalam" }

//    };
//    return movies;
//}
public ActionResult Details(int id)
        {
            var movies = _context.movies.Include(c => c.Genre).FirstOrDefault(a => a.Id == id);
            return View(movies);
        }


    }
}

