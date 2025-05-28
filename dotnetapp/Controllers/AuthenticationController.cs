using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommonLibrary.Lib;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using dotnetapp.Services;
using dotnetapp.Exceptions;
using Microsoft.AspNetCore.Authorization;

namespace dotnetapp.Controllers
{
    [ApiController]
    //[Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthenticationController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("api/login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
            try
            {
                if (login == null ||
                    string.IsNullOrEmpty(login.Email) ||
                    string.IsNullOrEmpty(login.Password))
                {
                    return BadRequest();
                }

                var user = await _authService.GetUserByUsernameAsync(login.Email);
                if (user == null)
                {
                    return Unauthorized("Invalid email or password");
                }

                if (CryptoLib.Hash(login.Password) != user.Password)
                {
                    return Unauthorized("Invalid email or password");
                }

                var token = TokenLib.Newtoken(user.Username, 
                    user.Email, 
                    new string[] { user.UserRole }, 
                    new string[] { user.UserRole }, 
                    120);

                return Ok(new {
                    UserId = user.UserId,
                    Name = user.Accounts != null && user.Accounts.Count > 0 ? user.Accounts[0].AccountHolderName : user.Email,
                    Role = user.UserRole,
                    Email = user.Email,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("api/register")]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            try
            {
                var registeredUser = await _authService.RegisterUser(user);
                return Ok(new {
                    Status = "Success",
                    Message = "User has been created successfully",
                    UserId = registeredUser.UserId
                });
            }
            catch (UserPayloadInvalidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (UserAlreadyExistsException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}