using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.Repositroy;
using CommonLibrary.Models;
using dotnetapp3.ViewModels;
using Microsoft.EntityFrameworkCore;
using dotnetapp3.Data;

namespace dotnetapp3.Repositroy
{
    public class RecurringDepositeRepository : IRecurringDepositeRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecurringDepositeRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<RecurringDeposit>> GetAllAsync(){
            var RecurringDepositedata = await _dbContext.RecurringDeposits.ToListAsync();
            return RecurringDepositedata ?? new List<RecurringDeposit>();
        }

        public async Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId){
             var accounts = await _dbContext.RecurringDeposits
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
            return accounts ?? new List<RecurringDeposit>();
        }
       public async  Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId){
         var accounts = await _dbContext.RecurringDeposits
                            .Where(a => a.AccountId == accountId)
                            .ToListAsync();
            return accounts ?? new List<RecurringDeposit>();
       }

       public async Task<RecurringDeposit> GetRecurringDepositAccountsByIdAsync(int id)
       {
             var accounts = await _dbContext.RecurringDeposits
                            .Where(a => a.RDId == id)
                            .FirstOrDefaultAsync();
            return accounts ?? new RecurringDeposit();
        }

        public async Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account){
             var dbAccount = await GetRecurringDepositAccountsByIdAsync(account.AccountId);
            if (dbAccount == null)
            {
                return null;
            }

            _dbContext.Entry(dbAccount).CurrentValues.SetValues(account);
            await _dbContext.SaveChangesAsync();
            return dbAccount;
        }

        public async Task<bool> UpdateRecurringDepositAccountAsync(RecurringDepositViewModel account){
                        var dbAccount = await GetRecurringDepositAccountsByIdAsync(account.RDId);
            if (dbAccount == null)
            {
                return false;
            }
            
            dbAccount.UserId = account.UserId;
            dbAccount.AccountId = account.AccountId;
            dbAccount.MonthlyDeposit = account.MonthlyDeposit;
            dbAccount.InterestRate = account.InterestRate;
            dbAccount.TentureMonths = account.TentureMonths;
            dbAccount.MatuarityAmount = account.MatuarityAmount;
            dbAccount.Status = account.Status;
            dbAccount.DateCreated = account.DateCreated;
            dbAccount.DateClosed = account.DateClosed;
            await _dbContext.SaveChangesAsync();
            return true;
        }        
        
    }
}