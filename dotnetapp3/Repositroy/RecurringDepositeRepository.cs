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

        public async Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account){
            var newAccount = new RecurringDeposit(){
                RDId = 0,
                UserId = account.UserId,
                AccountId = account.AccountId,
                MonthlyDeposit = account.MonthlyDeposit,
                InterestRate = account.InterestRate,
                TentureMonths = account.TentureMonths,
                MatuarityAmount = account.MatuarityAmount,
                Status = account.Status,
                DateCreated = account.DateCreated,
                DateClosed = account.DateClosed
            };
            _dbContext.Add(newAccount);
            await _dbContext.SaveChangesAsync();
            return newAccount;
        }

        public async Task<bool> CloseRecurringDepositAccountByIdAsync(int id){

             var dbAccount = await _dbContext.RecurringDeposits.FirstOrDefaultAsync(a => a.RDId == id);
            if (dbAccount == null || dbAccount.RDId <= 0)
            {
                return false;
            }
            
            dbAccount.Status = "Closed";
            dbAccount.DateClosed = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return true;
        }   

       public async  Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId){
         var accounts = await _dbContext.RecurringDeposits
                            .Where(a => a.AccountId == accountId)
                            .ToListAsync();
            return accounts ?? new List<RecurringDeposit>();
       }

    }
}