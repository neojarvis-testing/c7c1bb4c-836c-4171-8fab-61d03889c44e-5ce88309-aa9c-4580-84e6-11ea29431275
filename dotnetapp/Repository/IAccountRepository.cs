using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp.ViewModels;

namespace dotnetapp.Repository
{
    public interface IAccountRepository
    {
        Task<List<Account>> GetAllAsync();

        Task<List<Account>> GetAccountsByUserIdAsync(int userId);

        Task<Account> CreateAccountAsync(AccountCreateVM account);

        Task<Account?> GetAccountByIdAsync(int id);

        Task<Account?> UpdateAccountAsync(Account account);

        Task UpdateAccountStatusAsync(int accountId, AccountStatusUpdateVM status);

        Task DeleteAccountAsync(int accountId);
    } 
}