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
    public class FixedDepositController : ControllerBase
    {
        private readonly IFixedDepositService _FixedDepositService;
        public FixedDepositController(IFixedDepositService FixedDepositService){
            _FixedDepositService = FixedDepositService;
        }

        [HttpGet]
        [Authorize(Roles = "Manager, Teller")]
        [Route("/api/fixedDeposit")]
        public async Task<IActionResult> GetAll()
        {
            try{
                var data = await _FixedDepositService.GetAllAsync();
                return Ok(data);
            }catch(Exception ex){
                return StatusCode(500);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        [Route("/api/FixedDeposit")]
        public async Task<IActionResult> CreateFixedDepositAccountAsync(FixedDepositViewModel account)
        {
            try
            {
                var createdAccount = await _FixedDepositService.CreateFixedDepositAccountAsync(account);
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
        [Route("/api/FixedDeposit/close/{id}")]
        public async Task<IActionResult> CloseFixedDepositAccountByIdAsync(int id)
        {
            try
            {
                var isUpdated = await _FixedDepositService.CloseFixedDepositAccountByIdAsync(id);
                return isUpdated ? Ok() : BadRequest();
            }
            catch(Exception ex){
                return StatusCode(500);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Customer")]
        [Route("/api/FixedDeposit/user/{userId}")]
        public async Task<IActionResult> GetFixedDepositAccountsByUserIdAsync(int userId)
        {
            try
            {
                if(userId <= 0)
                {
                    throw new ArgumentException("Invalid UserId-"+userId);
                }
                var data = await _FixedDepositService.GetFixedDepositAccountsByUserIdAsync(userId);
                return  Ok(data);
            }
            catch(Exception ex){
                 return StatusCode(500);
            }
        }

        [HttpGet]
        [Route("/api/FixedDeposit/account/{accountId}")]
        [Authorize(Roles = "Customer, Teller, Manager")]
        public async Task<IActionResult> GetFixedDepositByAccountIdAsync(int accountId)
        {
            try
            {
                if(accountId <= 0)
                {
                    throw new ArgumentException("Invalid AccountId - "+accountId);
                }
                var data = await _FixedDepositService.GetFixedDepositByAccountIdAsync(accountId);
                return  Ok(data);
            }
            catch(Exception ex){
                return StatusCode(500);
            }
        }
    }
}