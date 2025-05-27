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
    public class FixedDepositController : ControllerBase
    {
        private readonly IFixedDepositService _fixedDepositService;

        public FixedDepositController(IFixedDepositService fixedDepositService){
            _fixedDepositService = fixedDepositService;
        }

        [HttpGet]
        [Route("/FixedDepositGetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _fixedDepositService.GetAllAsync());
        }

        [HttpGet]
        [Route("/GetFixedDepositAccountsByUserIdAsync{userId}")]
        public async Task<IActionResult> GetFixedDepositAccountsByUserIdAsync(int userId)
        {
            try
            {
                if(userId <= 0)
                {
                    throw new ArgumentException("Invalid UserId-"+userId);
                }
                return  Ok(await _fixedDepositService.GetFixedDepositAccountsByUserIdAsync(userId));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        [HttpGet]
         [Route("/GetFixedDepositByAccountIdAsync{accountId}")]
        public async Task<IActionResult> GetFixedDepositByAccountIdAsync(int accountId)
        {
            try
            {
                if(accountId <= 0)
                {
                    throw new ArgumentException("Invalid AccountId - "+accountId);
                }
                return  Ok(await _fixedDepositService.GetFixedDepositByAccountIdAsync(accountId));
            }
            catch(Exception ex){
                return NotFound();
            }
        }
        [HttpGet]
        [Route("/GetFixedDepositAccountsByIdAsync{fdid}")]
        public async Task<IActionResult> GetFixedDepositAccountsByIdAsync(int fdid)
        {
            try
            {
                if(fdid <= 0)
                {
                    throw new ArgumentException("Invalid FDID - "+fdid);
                }
                return  Ok(await _fixedDepositService.GetFixedDepositAccountsByIdAsync(fdid));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

         [HttpPost]
         [Route("/CreateFixedDepositAccountAsync")]
        public async Task<IActionResult> CreateFixedDepositAccountAsync(FixedDepositViewModel account)
        {
            try
            {
                if(account == null)
                {
                    throw new ArgumentException("Account is Null");
                }
                if(account.FDId <= 0)
                {
                    throw new ArgumentException("Invalid FDID  - "+account.FDId);
                }
                return  Ok(await _fixedDepositService.CreateFixedDepositAccountAsync(account));
            }
            catch(Exception ex){
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/UpdateFixedDepositAccountAsync")]
        public async Task<IActionResult> UpdateFixedDepositAccountAsync(FixedDepositViewModel account)
        {
            try
            {
                if(account == null)
                {
                    throw new ArgumentException("Account is Null");
                }
                if(account.FDId <= 0)
                {                 
                    throw new ArgumentException("Invalid FDID  - "+account.FDId);
                }
                return  Ok(await _fixedDepositService.UpdateFixedDepositAccountAsync(account));
            }
            catch(Exception ex){
                return NotFound();
            }
        }


    }
}