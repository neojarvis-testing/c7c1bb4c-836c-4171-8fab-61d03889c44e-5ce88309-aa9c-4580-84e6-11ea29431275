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
    public class FixedDepositRepository : IFixedDepositRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FixedDepositRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FixedDeposit>> GetAllAsync(){
            var fixedDepositedata = await _dbContext.FixedDeposits.ToListAsync();
            return fixedDepositedata ?? new List<FixedDeposit>();
        }

        public async Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId){
             var accounts = await _dbContext.FixedDeposits
                            .Where(a => a.UserId == userId)
                            .ToListAsync();
            return accounts ?? new List<FixedDeposit>();
        }
       public async  Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId){
         var accounts = await _dbContext.FixedDeposits
                            .Where(a => a.AccountId == accountId)
                            .ToListAsync();
            return accounts ?? new List<FixedDeposit>();
       }

       public async Task<FixedDeposit> GetFixedDepositAccountsByIdAsync(int id)
       {
             var accounts = await _dbContext.FixedDeposits
                            .Where(a => a.FDId == id)
                            .FirstOrDefaultAsync();
            return accounts ?? new FixedDeposit();
        }

        public async Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account){
             var dbAccount = await GetFixedDepositAccountsByIdAsync(account.AccountId);
            if (dbAccount == null)
            {
                return null;
            }

            _dbContext.Entry(dbAccount).CurrentValues.SetValues(account);
            await _dbContext.SaveChangesAsync();
            return dbAccount;
        }

        public async Task<bool> UpdateFixedDepositAccountAsync(FixedDepositViewModel account){
                        var dbAccount = await GetFixedDepositAccountsByIdAsync(account.FDId);
            if (dbAccount == null)
            {
                return false;
            }
            
            dbAccount.UserId = account.UserId;
            dbAccount.AccountId = account.AccountId;
            dbAccount.PrincipalAmount = account.PrincipalAmount;
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