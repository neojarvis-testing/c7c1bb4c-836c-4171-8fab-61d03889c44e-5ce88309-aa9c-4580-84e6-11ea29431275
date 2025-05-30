using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.ViewModels;
using dotnetapp3.Data;
using CommonLibrary.Models;
using dotnetapp3.Exceptions;
using dotnetapp3.Repository;

namespace dotnetapp3.Services
{
    public class RecurringDepositService : IRecurringDepositService
    {
        private readonly IRecurringDepositRepository _RecurringDepositRepository;
        private readonly IAccountRepository _accountRepository;

        public RecurringDepositService(
            IRecurringDepositRepository RecurringDepositRepository,
            IAccountRepository accountRepository
        ){
            _RecurringDepositRepository = RecurringDepositRepository;
            _accountRepository = accountRepository;
        }

        public async Task<List<RecurringDeposit>> GetAllAsync(){
            return await _RecurringDepositRepository.GetAllAsync();
        }

        public async Task<List<RecurringDeposit>> GetRecurringDepositAccountsByUserIdAsync(int userId){
            return await _RecurringDepositRepository.GetRecurringDepositAccountsByUserIdAsync(userId);
        }
        
        public async Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account)
        {
            if(account.UserId <=0)
            {
                throw InvalidValueTypeException.WithType(account.UserId.ToString());
            } 

            if(account.AccountId <=0)
            {
                throw InvalidValueTypeException.WithType(account.AccountId.ToString());
            }    

            var sourceAccount = await _accountRepository.GetAccountByIdAsync(account.AccountId);
            if(sourceAccount == null) {
                throw InvalidValueTypeException.WithType(account.AccountId.ToString());
            }

            if(account.MonthlyDeposit > sourceAccount.Balance){
                throw AccountBalanceException.With(account.MonthlyDeposit);
            }

            var newAccount = await _RecurringDepositRepository.CreateRecurringDepositAccountAsync(account);
            return newAccount;
        }

        public async Task<bool> CloseRecurringDepositAccountByIdAsync(int id){
          return await _RecurringDepositRepository.CloseRecurringDepositAccountByIdAsync(id);  
        } 
        
        public async Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId){
            return await _RecurringDepositRepository.GetRecurringDepositByAccountIdAsync(accountId);
        }        
    }
}