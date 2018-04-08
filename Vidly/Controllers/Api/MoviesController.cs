using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        
        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        
        public IEnumerable<Movie> GetMovies()
        {
            return _context.Movies.ToList();
        }

        public Movie GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return movie;
        }

        //POST/api/movies
        [HttpPost]
        public Movie CreateMovie(Movie movie)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            movie.AddedDateTime = DateTime.Now;
            _context.Movies.Add(movie);
            
            _context.SaveChanges();
            return movie;
        }

        //POST/api/movies/1
        [HttpPut]
        public void UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw  new HttpResponseException(HttpStatusCode.NotFound);
            }

            
            movieInDb.GenreId = movie.GenreId;
            movieInDb.Name = movie.Name;
            movieInDb.ReleaseDateTime = movie.ReleaseDateTime;
            movieInDb.AddedDateTime = DateTime.Now;
            movieInDb.Numinstock = movie.Numinstock;

            _context.SaveChanges();



        }

        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

        }

    }
}
