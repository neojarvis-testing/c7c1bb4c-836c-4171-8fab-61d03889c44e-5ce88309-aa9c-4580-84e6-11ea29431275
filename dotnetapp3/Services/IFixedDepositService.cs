using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.Repositroy;
using dotnetapp3.ViewModels;
using dotnetapp3.Data;
using CommonLibrary.Models;

namespace dotnetapp3.Services
{
    public interface IFixedDepositService
    {
        Task<List<FixedDeposit>> GetAllAsync();
        Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account);
        Task<bool> CloseFixedDepositAccountByIdAsync(int id); 
        Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId);  
        Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId);
    } 
}