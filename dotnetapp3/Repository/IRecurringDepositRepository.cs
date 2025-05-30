using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp3.ViewModels;
using Microsoft.EntityFrameworkCore;
using dotnetapp3.Data;

namespace dotnetapp3.Repository
{
    public interface IRecurringDepositRepository
    {
        Task<List<RecurringDeposit>> GetAllAsync();
        Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId);
        Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account);
        Task<bool> CloseRecurringDepositAccountByIdAsync(int id);  
        Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId);
    }
}