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
    public class FixedDepositRepository : IFixedDepositRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public FixedDepositRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<FixedDeposit>> GetAllAsync(){
            var FixedDepositedata = await _dbContext.FixedDeposits.ToListAsync();
            return FixedDepositedata ?? new List<FixedDeposit>();
        }

        public async Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account){
            var newAccount = new FixedDeposit(){
                FDId = 0,
                UserId = account.UserId,
                AccountId = account.AccountId,
                PrincipalAmount = account.PrincipalAmount,
                InterestRate = account.InterestRate,
                TentureMonths = account.TentureMonths,
                MatuarityAmount = GetMatuarityAmount(account.PrincipalAmount, account.InterestRate, account.TentureMonths),
                Status = DepositStatusEnum.Active.ToString(),
                DateCreated = DateTime.Now,
                DateClosed = null
            };
            _dbContext.Add(newAccount);
            await _dbContext.SaveChangesAsync();
            return newAccount;
        }

        private Decimal GetMatuarityAmount(decimal amount, decimal interestRate, int months)
        {
            var monthlyInterest = (amount * (interestRate/100))/12;
            return amount + monthlyInterest * months;
        }

        public async Task<bool> CloseFixedDepositAccountByIdAsync(int id){

             var dbAccount = await _dbContext.FixedDeposits.FirstOrDefaultAsync(a => a.FDId == id);
            if (dbAccount == null || dbAccount.FDId <= 0)
            {
                return false;
            }
            
            dbAccount.Status = "Closed";
            dbAccount.DateClosed = DateTime.Now;
            await _dbContext.SaveChangesAsync();
            return true;
        }   
        
        public async Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId){
             var accounts = await _dbContext.FixedDeposits
                            .Where(a => a.UserId == userId)
                            .OrderByDescending(a => a.DateCreated)
                            .ToListAsync();
            return accounts ?? new List<FixedDeposit>();
        }

       public async  Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId){
         var accounts = await _dbContext.FixedDeposits
                            .Where(a => a.AccountId == accountId)
                            .OrderByDescending(a => a.DateCreated)
                            .ToListAsync();
            return accounts ?? new List<FixedDeposit>();
       }
    }
}