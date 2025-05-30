using System;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.ViewModels;
using dotnetapp3.Data;
using CommonLibrary.Models;

namespace dotnetapp3.Services
{
    public interface IRecurringDepositService
    {
        Task<List<RecurringDeposit>> GetAllAsync();
        Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId);
        Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account);
        Task<bool> CloseRecurringDepositAccountByIdAsync(int id);  
        Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId);
    }
}