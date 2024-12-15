using MovieApplicationSprint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApplicationSprint.Repositories
{
    internal interface IMovieRepository
    {
        
            void AddMovie(Movies movie);
            void UpdateMovie(Movies movie);
            void DeleteMovie(string movieId);

            List<Movies> GetMoviesByGenre(string genre);
            List<Movies> GetMoviesByName(string name);
            List<Movies> GetMoviesByActor(string actor);
            List<Movies> GetMoviesByDirector(string director);
            List<Movies> GetAllMovies();

    }

      
    }
}
