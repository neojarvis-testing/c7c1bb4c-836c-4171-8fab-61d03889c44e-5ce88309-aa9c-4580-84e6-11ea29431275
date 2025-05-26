using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetapp3.Services;
namespace dotnetapp3.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RecurringDepositeController : ControllerBase
    {
        private readonly IRecurringDepositeService _recurringDepositeService;
        public RecurringDepositeController(IRecurringDepositeService recurringDepositeService){
            _recurringDepositeService = recurringDepositeService;
        }

                [HttpGet]
        [Route("api/ms/recurringdeposite")]
        public async Task<IActionResult> GetAll()
        {
            return Ok();
        }

        [HttpGet]
        [Route("api/ms/recurringdeposite{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }

         [HttpPost]
        [Route("api/ms/recurringdeposite")]
        public async Task<IActionResult> Post()
        {
            return Ok();
        }

        [HttpDelete]
        [Route("api/ms/recurringdeposite{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok();
        }

        [HttpPut]
        [Route("api/ms/recurringdeposite{id}")]
        public async Task<IActionResult> Update(int id)
        {
           return Ok();
        }
    }
}