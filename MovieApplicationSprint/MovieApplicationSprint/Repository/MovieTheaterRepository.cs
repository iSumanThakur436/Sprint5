using MovieApplicationSprint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieWebApplication.Repository
{
    public class MovieTheaterRepository : IMovieTheaterRepository
    {
        private MovieAppContext _appContext;

        public MovieTheaterRepository()
        {
            _appContext = new MovieAppContext();
        }

        public List<MovieTheater> GetAllMovieTheater()
        {
            return _appContext.MovieTheaters.ToList();
        }

        public MovieTheater GetTheaterByMovieId(string Movieid)
        {
            var movietheater = _appContext.MovieTheaters.SingleOrDefault(mt => mt.MovieId == Movieid);
            return movietheater;
        }
    }
}