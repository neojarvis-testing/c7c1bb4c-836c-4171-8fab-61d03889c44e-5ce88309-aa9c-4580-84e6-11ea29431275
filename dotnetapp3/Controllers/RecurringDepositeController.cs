using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp3.Services;
using dotnetapp3.ViewModels;
using dotnetapp3.Exceptions;
using Microsoft.AspNetCore.Authorization;
namespace dotnetapp3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecurringDepositeController : ControllerBase
    {
        private readonly IRecurringDepositeService _RecurringDepositService;

        public RecurringDepositeController(IRecurringDepositeService RecurringDepositService){
            _RecurringDepositService = RecurringDepositService;
        }

        [HttpGet]
        [Authorize(Roles = "Teller,Manager")]
        [Route("/api/recurringDeposit")]
        public async Task<IActionResult> GetAll()
        {
            try{
                var data = await _RecurringDepositService.GetAllAsync();
                return Ok(data);
            }catch(Exception ex){
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("/api/recurringdeposit/user/{userId}")]
        public async Task<IActionResult> GetRecurringDepositAccountsByUserIdAsync(int userId)
        {
            try
            {
                if(userId <= 0)
                {
                    throw new ArgumentException("Invalid UserId-"+userId);
                }
                var data = await _RecurringDepositService.GetRecurringDepositAccountsByUserIdAsync(userId);
                return  Ok(data);
            }
            catch(Exception ex){
                 return StatusCode(500);
            }
        }
        
        [HttpPost]
        [Authorize(Roles = "Customer")]
        [Route("/api/recurringdeposit")]
        public async Task<IActionResult> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account)
        {
            try
            {
                var createdAccount = await _RecurringDepositService.CreateRecurringDepositAccountAsync(account);
                return StatusCode(201, createdAccount);
            }
            catch (InvalidValueTypeException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        

        [HttpPost]
        [Authorize(Roles = "Manager")]
        [Route("/api/recurringdeposit/close/{id}")]
        public async Task<IActionResult> CloseRecurringDepositAccountByIdAsync(int id)
        {
            try
            {
                var isUpdated = await _RecurringDepositService.CloseRecurringDepositAccountByIdAsync(id);
                return isUpdated ? Ok() : BadRequest();
            }
            catch(Exception ex){
                return StatusCode(500);
            }
        }


        [HttpGet]
        [Route("/api/recurringdeposit/account/{accountId}")]
        [Authorize(Roles = "Customer, Teller, Manager")]
        public async Task<IActionResult> GetRecurringDepositByAccountIdAsync(int accountId)
        {
            try
            {
                if(accountId <= 0)
                {
                    throw new ArgumentException("Invalid AccountId - "+accountId);
                }
                var data = await _RecurringDepositService.GetRecurringDepositByAccountIdAsync(accountId);
                return  Ok(data);
            }
            catch(Exception ex){
                return StatusCode(500);
            }
        }
    }
}