using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp.Services;
using dotnetapp.Models;
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
                if (accounts.Count == 0) {
                    return NotFound("No Accounts");
                }
                return Ok(accounts);
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
                if (accounts.Count == 0) {
                    return NotFound("No Accounts");
                }
                return Ok(accounts);
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
                if (account.AccountType == AccountTypeEnum.Savings ||
                    account.AccountType == AccountTypeEnum.Current)
                {
                    var createdAccount = await _accountService.CreateAccountAsync(account);
                    if (createdAccount != null) {
                        return StatusCode(201, createdAccount);
                    }
                    throw AccountAlreadyExistException.WithUserId(account.UserId);
                } 
                else 
                {
                    throw AccountInvalidTypeException.WithType(account.AccountType.ToString());
                }
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
                if (account != null) {
                    return Ok(account);
                }
                throw AccountNotFoundException.WithId(id);
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
                if (updatedAccount != null) {
                    return StatusCode(200, updatedAccount);
                }
                throw AccountNotFoundException.WithId(account.AccountId);
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