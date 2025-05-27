using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using Microsoft.EntityFrameworkCore;
using CommonLibrary.Lib;

namespace dotnetapp.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<User?> GetUserByIdAsync(int userId)
        {
            var user = await _dbContext.Users
                .Where(a => a.UserId == userId)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserByUsernameAsync(string username)
        {
            var user = await _dbContext.Users
                .Where(a => a.Username == username)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User?> GetUserByEmailAsync(string email)
        {
            var user = await _dbContext.Users
                .Where(a => a.Email == email)
                .FirstOrDefaultAsync();
            return user;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            user.Password = CryptoLib.Hash(user.Password);

            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }
    }
}