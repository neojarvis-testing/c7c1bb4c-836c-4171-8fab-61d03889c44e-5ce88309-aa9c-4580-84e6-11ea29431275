using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp3.ViewModels;

namespace dotnetapp3.Repositroy
{
    public interface IRecurringDepositeRepository
    {
         Task<List<RecurringDeposit>> GetAllAsync();
        Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId);
        Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId);  
         Task<RecurringDeposit> GetRecurringDepositAccountsByIdAsync(int id);      
        Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account);
        Task<bool> UpdateRecurringDepositAccountAsync(RecurringDepositViewModel account);
    }
}