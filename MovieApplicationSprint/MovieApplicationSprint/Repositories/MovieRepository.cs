using MovieApplicationSprint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieApplicationSprint.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private MovieAppContext context;

        public MovieRepository()
        {
            context = new MovieAppContext();
        }

        public void AddMovie(Movies movie)
        {
            try
            {
                context.Movies.Add(movie);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateMovie(Movies movie)
        {
            try
            {
                var existingMovie = context.Movies.Find(movie.MovieId);
                if (existingMovie != null)
                {
                    existingMovie.Title = movie.Title;
                    existingMovie.Actor = movie.Actor;
                    existingMovie.Director = movie.Director;
                    existingMovie.ReleaseDate = movie.ReleaseDate;
                    existingMovie.Genre = movie.Genre;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteMovie(string movieId)
        {
            try
            {
                var movie = context.Movies.Find(movieId);
                if (movie != null)
                {
                    context.Movies.Remove(movie);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Movies GetMovieById(string movieId)
        {
            try
            {
                return context.Movies.Find(movieId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movies> GetMoviesByGenre(string genre)
        {
            try
            {
                return context.Movies.Where(m => m.Genre == genre).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movies> GetAllMovies()
        {
            try
            {
                return context.Movies.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movies> GetMoviesByName(string name)
        {
            try
            {
                return context.Movies
                    .Where(m => m.Title.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movies> GetMoviesByActor(string actor)
        {
            try
            {
                return context.Movies
                    .Where(m => m.Actor.IndexOf(actor, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Movies> GetMoviesByDirector(string director)
        {
            try
            {
                return context.Movies
                    .Where(m => m.Director.IndexOf(director, StringComparison.OrdinalIgnoreCase) >= 0)
                    .ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}