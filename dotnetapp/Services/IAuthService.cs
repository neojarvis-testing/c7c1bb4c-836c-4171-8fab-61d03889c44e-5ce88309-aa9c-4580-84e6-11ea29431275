using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Models;

namespace dotnetapp.Services
{
    public interface IAuthService
    {
        Task<User> GetUserByUsernameAsync(string username);
    }
}