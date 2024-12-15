using MovieApplicationSprint.Entities;
using System.Collections.Generic;

namespace MovieApplicationSprint.Repositories
{
    public interface IUserRepository
    {
        void AddUser(User user); // Register new user
        User ValidateUser(string email, string password); // Login validation
        void UpdateUser(User user); // Update profile
        User GetUserById(string userId); // Get user by ID
        List<User> GetAllUsers(); // Retrieve all users (Admin only)
       
    }
}
