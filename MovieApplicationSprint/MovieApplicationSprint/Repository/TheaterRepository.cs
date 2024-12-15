using MovieApplicationSprint.Entities;
using MovieApplicationSprint.Entities;
using MovieApplicationSprint.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HandsOnAPIUsingEF.Repositories
{
    public class TheaterRepository : ITheaterRepository
    {
        private MovieAppContext context;

        public TheaterRepository()
        {
            context = new MovieAppContext();
        }

        public void AddTheater(Theater theater)
        {
            try
            {
                context.Theaters.Add(theater);
                context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateTheater(Theater theater)
        {
            try
            {
                var existingTheater = context.Theaters.Find(theater.TheaterId);
                if (existingTheater != null)
                {
                    existingTheater.TheaterName = theater.TheaterName;
                    existingTheater.Location = theater.Location;
                    existingTheater.TheaterType = theater.TheaterType;
                    existingTheater.City = theater.City;
                    existingTheater.SeatCount = theater.SeatCount;
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteTheater(int theaterId)
        {
            try
            {
                var theater = context.Theaters.Find(theaterId);
                if (theater != null)
                {
                    context.Theaters.Remove(theater);
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Theater GetTheaterById(int theaterId)
        {
            try
            {
                return context.Theaters.Find(theaterId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Theater> GetAllTheaters()
        {
            try
            {
                return context.Theaters.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}