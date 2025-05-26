using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CommonLibrary.Lib;
using dotnetapp.ViewModels;
using dotnetapp.Services;

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
        public async Task<IActionResult> Login([FromBody] LoginVM login)
        {
            try
            {
                if (login == null ||
                    string.IsNullOrEmpty(login.Username) ||
                    string.IsNullOrEmpty(login.Password))
                {
                    return BadRequest();
                }

                var user = await _authService.GetUserByUsernameAsync(login.Username);
                if (user == null)
                {
                    return Unauthorized("Invalid username or password");
                }

                if (CryptoLib.Hash(login.Password) != user.Password)
                {
                    return Unauthorized("Invalid username or password");
                }

                var token = TokenLib.Newtoken(user.Username, 
                    user.Email, 
                    new string[] { user.UserRole.ToString() }, 
                    new string[] { user.UserRole.ToString() }, 
                    120);

                return Ok(new {
                    UserId = user.UserId,
                    Name = user.Accounts != null && user.Accounts.Count > 0 ? user.Accounts[0].AccountHolderName : user.Email,
                    Email = user.Email,
                    Token = token
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}