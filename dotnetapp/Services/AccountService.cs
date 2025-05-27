using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;
using dotnetapp.ViewModels;
using dotnetapp.Repository;
using dotnetapp.Exceptions;

namespace dotnetapp.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public async Task<List<Account>> GetAllAsync()
        {
            var accounts = await _accountRepository.GetAllAsync();
            if (accounts == null || accounts.Count == 0) {
                throw new AccountNotFoundException("No Accounts");
            }
            return accounts;
        }

        public async Task<List<Account>> GetAccountsByUserIdAsync(int userId)
        {
            var accounts = await _accountRepository.GetAccountsByUserIdAsync(userId);
            if (accounts == null || accounts.Count == 0) {
                throw AccountNotFoundException.WithUserId(userId);
            }
            return accounts;
        }

        public async Task<Account> CreateAccountAsync(AccountCreateVM account)
        {
            if (!account.AccountType.IsValidEnumValue<AccountTypeEnum>())
            {
                throw AccountInvalidTypeException.WithType(account.AccountType.ToString());
            }

            var existingAccounts = await _accountRepository.GetAccountsByUserIdAsync(account.UserId);
            if (existingAccounts != null &&
                existingAccounts.Where(a => a.AccountType == account.AccountType).Count() > 0)
            {
                throw AccountAlreadyExistException.WithUserId(account.UserId);
            }

            var newAccount = await _accountRepository.CreateAccountAsync(account);
            return newAccount;
        }

        public async Task<Account> GetAccountByIdAsync(int id)
        {
            var existingAccount = await _accountRepository.GetAccountByIdAsync(id);
            if (existingAccount == null)
            {
                throw AccountNotFoundException.WithId(id);
            }
            return existingAccount;
        }

        public async Task<Account> UpdateAccountAsync(Account account)
        {
            if (!account.AccountType.IsValidEnumValue<AccountTypeEnum>())
            {
                throw AccountInvalidTypeException.WithType(account.AccountType.ToString());
            }

            var existingAccount = await GetAccountByIdAsync(account.AccountId);
            var updatedAccount = await _accountRepository.UpdateAccountAsync(account);
            return updatedAccount;
        }

        public async Task UpdateAccountStatusAsync(int accountId, AccountStatusUpdateVM status)
        {
            if (!status.Status.IsValidEnumValue<AccountStatusEnum>())
            {
                throw AccountInvalidTypeException.WithType(status.Status.ToString());
            }

            var existingAccount = await GetAccountByIdAsync(accountId);
            await _accountRepository.UpdateAccountStatusAsync(accountId, status);
        }

        public async Task DeleteAccountAsync(int accountId)
        {
            var existingAccount = await GetAccountByIdAsync(accountId);
            await _accountRepository.DeleteAccountAsync(accountId);
        }
    }
}