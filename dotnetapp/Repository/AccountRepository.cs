using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp.Data;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace dotnetapp.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            var accounts = await _dbContext.Accounts.ToListAsync();
            return accounts ?? new List<Account>();
        }

        public async Task<List<Account>> GetAccountsByUserIdAsync(int userId)
        {
            var accounts = await _dbContext.Accounts
                .Where(a => a.UserId == userId)
                .ToListAsync();
            return accounts ?? new List<Account>();
        }

        public async Task<Account> CreateAccountAsync(AccountCreateVM account)
        {
            var newAccount = new Account()
            {
                UserId = account.UserId,
                AccountHolderName = account.AccountHolderName,
                AccountType = account.AccountType,
                Balance = account.Balance,
                Status = AccountStatusEnum.Pending,
                ProofOfIdentity = account.ProofOfIdentity,
                DateCreated = DateTime.Now,
                LastUpdated = DateTime.Now
            };

            _dbContext.Accounts.Add(newAccount);
            await _dbContext.SaveChangesAsync();
            return newAccount;
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            var account = await _dbContext.Accounts
                            .Where(a => a.AccountId == id)
                            .FirstOrDefaultAsync();
            return account;
        }

        public async Task<Account?> UpdateAccountAsync(Account account)
        {
            var dbAccount = await GetAccountByIdAsync(account.AccountId);
            if (dbAccount == null)
            {
                return null;
            }

            _dbContext.Entry(dbAccount).CurrentValues.SetValues(account);
            await _dbContext.SaveChangesAsync();
            return dbAccount;
        }

        public async Task UpdateAccountStatusAsync(int accountId, AccountStatusUpdateVM status)
        {
            var dbAccount = await GetAccountByIdAsync(accountId);
            if (dbAccount == null)
            {
                return;
            }
            
            dbAccount.Status = status.Status;
            dbAccount.LastUpdated = DateTime.Now;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var dbAccount = await GetAccountByIdAsync(accountId);
            if (dbAccount == null)
            {
                return;
            }

            _dbContext.Accounts.Remove(dbAccount);
            await _dbContext.SaveChangesAsync();
        }
    }
}