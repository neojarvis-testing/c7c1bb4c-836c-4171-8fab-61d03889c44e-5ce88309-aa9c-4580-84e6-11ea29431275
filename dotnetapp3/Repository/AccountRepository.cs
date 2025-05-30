using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using Microsoft.EntityFrameworkCore;
using dotnetapp3.Data;

namespace dotnetapp3.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public AccountRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Account?> GetAccountByIdAsync(int id)
        {
            var account = await _dbContext.Accounts
                            .Where(a => a.AccountId == id)
                            .FirstOrDefaultAsync();
            return account;
        }
    }
}