using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using dotnetapp.Repository;
using dotnetapp.Exceptions;

namespace dotnetapp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            return await _userRepository.GetUserByUsernameAsync(username);
        }
        
        public async Task<User> RegisterUser(User user)
        {
            if (user == null)
            {
                throw new UserPayloadInvalidException("Invalid Payload");
            }

            if (!user.UserRole.IsValidEnumValue<UserRoleEnum>())
            {
                throw new UserPayloadInvalidException($"Invalid UserRole: {user.UserRole}");
            }

            if (string.IsNullOrEmpty(user.Email))
            {
                throw new UserPayloadInvalidException("Invalid Email");
            }

            if (string.IsNullOrEmpty(user.Username))
            {
                throw new UserPayloadInvalidException("Invalid Username");
            }

            if (string.IsNullOrEmpty(user.Password))
            {
                throw new UserPayloadInvalidException("Invalid Password");
            }

            if (string.IsNullOrEmpty(user.MobileNumber))
            {
                throw new UserPayloadInvalidException("Invalid MobileNumber");
            }

            var existingUser = await _userRepository.GetUserByUsernameAsync(user.Username);
            if (existingUser != null)
            {
                throw UserAlreadyExistsException.WithUsername(user.Username);
            }

            existingUser = await _userRepository.GetUserByEmailAsync(user.Email);
            if (existingUser != null)
            {
                throw UserAlreadyExistsException.WithEmail(user.Email);
            }
            
            var createdUser = await _userRepository.CreateUserAsync(user);
            return createdUser;
        }
    }
}