using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Services;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using dotnetapp.Exceptions;

namespace dotnetapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet]
        // Manger, Teller
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var accounts = await _accountService.GetAllAsync();
                return Ok(accounts);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("user/{userId}")]
        // Customer, Manager
        public async Task<IActionResult> GetAccountsByUserId(int userId)
        {
            try
            {
                var accounts = await _accountService.GetAccountsByUserIdAsync(userId);
                return Ok(accounts);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        // Customer
        public async Task<IActionResult> CreateAccount([FromBody] AccountCreateVM account)
        {
            try
            {
                var createdAccount = await _accountService.CreateAccountAsync(account);
                return StatusCode(201, createdAccount);
            }
            catch (AccountInvalidTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AccountAlreadyExistException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        // Customer, Manager
        public async Task<IActionResult> GetAccountById(int id)
        {
            try
            {
                var account = await _accountService.GetAccountByIdAsync(id);
                return Ok(account);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        // Manager
        public async Task<IActionResult> UpdateAccount([FromBody] Account account)
        {
            try
            {
                var updatedAccount = await _accountService.UpdateAccountAsync(account);
                return StatusCode(200, updatedAccount);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message+ ex.StackTrace);
            }
            catch (AccountInvalidTypeException ex)
            {
                return BadRequest(ex.Message+ ex.StackTrace);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message+ ex.StackTrace);
            }
        }

        [HttpPatch]
        [Route("{id}")]
        // Manager
        public async Task<IActionResult> UpdateAccountStatus(int id, [FromBody] AccountStatusUpdateVM status)
        {
            try
            {
                await _accountService.UpdateAccountStatusAsync(id, status);
                return StatusCode(204);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (AccountInvalidTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        [Route("{id}")]
        // Manager
        public async Task<IActionResult> DeleteAccount(int id)
        {
            try
            {
                await _accountService.DeleteAccountAsync(id);
                return StatusCode(204);
            }
            catch (AccountNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}