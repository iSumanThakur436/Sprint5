using MovieApplicationSprint.Entities;
using MovieApplicationSprint.Entities;
using System.Collections.Generic;

namespace MovieApplicationSprint.Repositories
{
    internal interface ITheaterRepository
    {
        void AddTheater(Theater theater);
        void UpdateTheater(Theater theater);
        void DeleteTheater(int theaterId);
        Theater GetTheaterById(int theaterId);
        List<Theater> GetAllTheaters();
    }
}