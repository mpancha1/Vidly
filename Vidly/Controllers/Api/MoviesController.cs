using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dtos;
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

        
        public IEnumerable<MovieDto> GetMovies()
        {
            return _context.Movies.ToList().Select(Mapper.Map<Movie,MovieDto>);
        }

        public MovieDto GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return Mapper.Map<Movie,MovieDto>(movie);
        }

        //POST/api/movies
        [HttpPost]
        public MovieDto CreateMovie(MovieDto movieDto)
        {

            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            
            movieDto.AddedDateTime = DateTime.Now;
            var movie = Mapper.Map<MovieDto, Movie>(movieDto);
            _context.Movies.Add(movie);
            
            _context.SaveChanges();
            return movieDto;
        }

        //POST/api/movies/1
        [HttpPut]
        public void UpdateMovie(int id,MovieDto moviedto)
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

            Mapper.Map(moviedto, movieInDb);
           
            movieInDb.AddedDateTime = DateTime.Now;
            

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
