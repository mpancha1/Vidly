using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;

namespace Vidly.Controllers
{
    
    public class MoviesController : Controller
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Movies/Random
      /*  public ActionResult Random()
        {
            var movies = new Movie() {Name = "Shrek!"};
            
            //return new ViewResult();
            // return HttpNotFound();
          //  ViewData["Movie"] = movies;
           
            return Content(movies.Name);
            // return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        }*/

        [Route("movies/ViewMovies")]
        public ActionResult ViewMovies()
        {
           // var movies = _context.Movies.Include(c => c.Genre).ToList();
            //var viewmodel = new RandomMovieViewModel() { movies = movies };
            return View();

        }

        public ActionResult MovieDetails(int id)
        {
            var movie = _context.Movies.Include(c => c.Genre).SingleOrDefault(c => c.Id == id);


            return View(movie);
        }




        /* public ActionResult Edit(int id)
         {
 
             return Content("Id : " + id);
         }*/

        //movies
        /* public ActionResult Index(int? pageindex,string sortby)
         {
             if (!pageindex.HasValue)
                 pageindex = 1;

             if (String.IsNullOrWhiteSpace(sortby))
                 sortby = "name";


             return Content(String.Format("pageindex={0} & sortby={1}",pageindex,sortby));


         }*/

        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByReleaseDate(int year,int month)
        {

            return Content(year + "/" + month);
        }
        [HttpPost]
        [ValidateAntiForgeryToken] 
       public ActionResult Save(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                var model = new NewMovieViewModel(movie)
                {
                    
                  
                    Genres = _context.Genres.ToList()
                    
                };
                return View("MovieForm", model);
            }
            if (movie.Id == 0)
            {
                movie.AddedDateTime = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.AddedDateTime = movie.AddedDateTime;
                movieInDb.ReleaseDateTime = movie.ReleaseDateTime;
                movieInDb.Numinstock = movie.Numinstock;
                movieInDb.GenreId = movie.GenreId;
            }


            _context.SaveChanges();
            return RedirectToAction("ViewMovies", "Movies");
        }

        public ActionResult Add()
        {
            var genre = _context.Genres.ToList();
            var model = new NewMovieViewModel()
            {
                
                Genres = genre
            };
            return View("MovieForm",model);
        }
        public ActionResult Edit(int id)
        {
            /*_context.Movies.Add(movie);
            _context.SaveChanges();*/

          

            var foundMovieovie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (foundMovieovie == null)
            {
                return HttpNotFound();

            }

            var genre = _context.Genres.ToList();
            var viewModel = new NewMovieViewModel(foundMovieovie)
            {
                
                
               
                Genres = genre




            };
            return View("MovieForm",viewModel);
        }
    }  
}


