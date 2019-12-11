using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dto;
using System.Data.Entity;
using Vidly.Models;

namespace Vidly.Controllers.api
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
            return _context.movies
                .Include(c=>c.Genre)
                .ToList()
                .Select(Mapper.Map<Movie, MovieDto>);
        }
        public Movie GetMovie(int id)
        {
            var movies = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movies == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            return movies;
        }
        [HttpPost]
        public Movie CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movies = Mapper.Map<MovieDto,Movie>(movieDto);
            _context.movies.Add(movies);
            _context.SaveChanges();
            movieDto.Id =movieDto.Id;
            return movies;
    
        }
        [HttpPut]
       public void UpdateMovie(int id,MovieDto movieDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var movieInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            Mapper.Map(movieDto, movieInDb);
            movieInDb.Name = movieDto.Name;
            movieInDb.ReleaseDate =movieDto.ReleaseDate;
            movieInDb.DateTime = movieDto.DateTime;
            movieInDb.GenreId=movieDto.GenreId;
            _context.SaveChanges();


        }
        [HttpDelete]
        public void DeleteMovie(int id)
        {
            var moviesInDb = _context.movies.SingleOrDefault(c => c.Id == id);
            if (moviesInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.movies.Remove(moviesInDb);

            _context.SaveChanges();
        }


    }
}
