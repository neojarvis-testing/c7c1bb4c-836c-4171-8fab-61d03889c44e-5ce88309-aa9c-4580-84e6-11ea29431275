using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp.ViewModels;

namespace dotnetapp.Repository
{
    public interface IUserRepository
    {
        Task<User?> GetUserByIdAsync(int userId);

        Task<User?> GetUserByUsernameAsync(string username);

        Task<User?> GetUserByEmailAsync(string email);
        
        Task<User> CreateUserAsync(User user);
    } 
}