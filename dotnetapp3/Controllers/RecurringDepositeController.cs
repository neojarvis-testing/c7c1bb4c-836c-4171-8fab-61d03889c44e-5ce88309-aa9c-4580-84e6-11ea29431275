using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp3.Services;
using dotnetapp3.ViewModels;
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
        [Route("/RecurringDepositGetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _RecurringDepositService.GetAllAsync());
        }

        [HttpGet]
        [Route("/GetRecurringDepositAccountsByUserIdAsync{userId}")]
        public async Task<IActionResult> GetRecurringDepositAccountsByUserIdAsync(int userId)
        {
            try
            {
                if(userId <= 0)
                {
                    throw new ArgumentException("Invalid UserId-"+userId);
                }
                return  Ok(await _RecurringDepositService.GetRecurringDepositAccountsByUserIdAsync(userId));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        [HttpGet]
         [Route("/GetRecurringDepositByAccountIdAsync{accountId}")]
        public async Task<IActionResult> GetRecurringDepositByAccountIdAsync(int accountId)
        {
            try
            {
                if(accountId <= 0)
                {
                    throw new ArgumentException("Invalid AccountId - "+accountId);
                }
                return  Ok(await _RecurringDepositService.GetRecurringDepositByAccountIdAsync(accountId));
            }
            catch(Exception ex){
                return NotFound();
            }
        }
        [HttpGet]
        [Route("/GetRecurringDepositAccountsByIdAsync{rdid}")]
        public async Task<IActionResult> GetRecurringDepositAccountsByIdAsync(int rdid)
        {
            try
            {
                if(rdid <= 0)
                {
                    throw new ArgumentException("Invalid rDID - "+rdid);
                }
                return  Ok(await _RecurringDepositService.GetRecurringDepositAccountsByIdAsync(rdid));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

         [HttpPost]
         [Route("/CreateRecurringDepositAccountAsync")]
        public async Task<IActionResult> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account)
        {
            try
            {
                if(account == null)
                {
                    throw new ArgumentException("Account is Null");
                }
                if(account.RDId <= 0)
                {
                    throw new ArgumentException("Invalid RDID  - "+account.RDId);
                }
                return  Ok(await _RecurringDepositService.CreateRecurringDepositAccountAsync(account));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/UpdateRecurringDepositAccountAsync")]
        public async Task<IActionResult> UpdateRecurringDepositAccountAsync(RecurringDepositViewModel account)
        {
            try
            {
                if(account == null)
                {
                    throw new ArgumentException("Account is Null");
                }
                if(account.RDId <= 0)
                {                 
                    throw new ArgumentException("Invalid RDID  - "+account.RDId);
                }
                return  Ok(await _RecurringDepositService.UpdateRecurringDepositAccountAsync(account));
            }
            catch(Exception ex){
                return NotFound();
            }
        }



    }
}