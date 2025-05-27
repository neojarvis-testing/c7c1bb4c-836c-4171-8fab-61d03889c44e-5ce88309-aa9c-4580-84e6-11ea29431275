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
    public interface IRecurringDepositeService
    {
        Task<List<RecurringDeposit>> GetAllAsync();
        Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId);
        Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId);  
         Task<RecurringDeposit> GetRecurringDepositAccountsByIdAsync(int id);      
        Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account);
        Task<bool> UpdateRecurringDepositAccountAsync(RecurringDepositViewModel account);  
        
    }
}