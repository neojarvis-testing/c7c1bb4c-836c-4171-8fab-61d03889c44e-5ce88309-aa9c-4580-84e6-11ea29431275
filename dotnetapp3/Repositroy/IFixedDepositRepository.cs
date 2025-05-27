using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp3.ViewModels;
namespace dotnetapp3.Repositroy
{
    public interface IFixedDepositRepository
    {
        Task<List<FixedDeposit>> GetAllAsync();
        Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId);
        Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId);  
         Task<FixedDeposit> GetFixedDepositAccountsByIdAsync(int id);      
        Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account);
        Task<bool> UpdateFixedDepositAccountAsync(FixedDepositViewModel account);        
    }
}