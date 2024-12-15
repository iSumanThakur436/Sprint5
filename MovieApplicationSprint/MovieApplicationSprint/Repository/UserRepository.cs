using MovieApplicationSprint.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieApplicationSprint.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MovieAppContext _context;

        public UserRepository()
        {
            _context = new MovieAppContext();
        }

        public void AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User ValidateUser(string email, string password)
        {
            try
            {
                return _context.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateUser(User user)
        {
            try
            {
                var existingUser = _context.Users.Find(user.UserId);
                if (existingUser != null)
                {
                    existingUser.UserName = user.UserName;
                    existingUser.Email = user.Email;
                    existingUser.Mobile = user.Mobile;
                    existingUser.Age = user.Age;
                    existingUser.Gender = user.Gender;
                    _context.SaveChanges();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public User GetUserById(string userId)
        {
            try
            {
                return _context.Users.Find(userId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<User> GetAllUsers()
        {
            try
            {
                return _context.Users.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }

       
    }
}
