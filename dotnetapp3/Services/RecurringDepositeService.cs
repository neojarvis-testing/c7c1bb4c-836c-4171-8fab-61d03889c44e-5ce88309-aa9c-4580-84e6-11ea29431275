using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.Repositroy;
using dotnetapp3.ViewModels;
using dotnetapp3.Data;
using CommonLibrary.Models;
using dotnetapp3.Exceptions;

namespace dotnetapp3.Services
{
    public class RecurringDepositeService : IRecurringDepositeService
    {
        private readonly IRecurringDepositeRepository _RecurringDepositRepository;
        public RecurringDepositeService(IRecurringDepositeRepository RecurringDepositRepository){
            _RecurringDepositRepository = RecurringDepositRepository;
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
            if(account.UserId <=0)
            {
                throw InvalidValueTypeException.WithType(account.AccountId.ToString());
            }    
            var newAccount = await _RecurringDepositRepository. CreateRecurringDepositAccountAsync(account);
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