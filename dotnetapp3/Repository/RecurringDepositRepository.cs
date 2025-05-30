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
    public class RecurringDepositRepository : IRecurringDepositRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public RecurringDepositRepository(ApplicationDbContext dbContext)
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
                            .OrderByDescending(a => a.DateCreated)
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
                MatuarityAmount = GetMatuarityAmount(account.MonthlyDeposit, account.InterestRate, account.TentureMonths),
                Status = DepositStatusEnum.Active.ToString(),
                DateCreated = DateTime.Now,
                DateClosed = null
            };

            var dbAccount = await _dbContext.Accounts
                .Where(a => a.AccountId == account.AccountId)
                .FirstOrDefaultAsync();
            dbAccount.Balance -= account.MonthlyDeposit;

            _dbContext.Add(newAccount);
            await _dbContext.SaveChangesAsync();
            return newAccount;
        }

        private Decimal GetMatuarityAmount(decimal amount, decimal interestRate, int months)
        {
            var monthlyInterest = (amount * (interestRate/100))/12;
            return amount + monthlyInterest * months;
        }

        public async Task<bool> CloseRecurringDepositAccountByIdAsync(int id){

             var dbDeposit = await _dbContext.RecurringDeposits.FirstOrDefaultAsync(a => a.RDId == id);
            if (dbDeposit == null || dbDeposit.RDId <= 0)
            {
                return false;
            }
            
            var dbAccount = await _dbContext.Accounts
                .Where(a => a.AccountId == dbDeposit.AccountId)
                .FirstOrDefaultAsync();
            var closeDate = dbDeposit.DateCreated.AddMonths(dbDeposit.TentureMonths);
            if(closeDate < DateTime.Now) // Valid Close
            {
                dbAccount.Balance += dbDeposit.MatuarityAmount;
                dbDeposit.Status = DepositStatusEnum.Closed.ToString();
            } else { // Premature close
                var partialInterest = 0; // Need to add logic to calculate partial interest
                dbAccount.Balance += (dbDeposit.MonthlyDeposit + partialInterest);
                dbDeposit.Status = DepositStatusEnum.ClosedPrematuarely.ToString();
            }

            dbDeposit.DateClosed = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return true;
        }   

       public async  Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId){
         var accounts = await _dbContext.RecurringDeposits
                            .Where(a => a.AccountId == accountId)
                            .OrderByDescending(a => a.DateCreated)
                            .ToListAsync();
            return accounts ?? new List<RecurringDeposit>();
       }
    }
}