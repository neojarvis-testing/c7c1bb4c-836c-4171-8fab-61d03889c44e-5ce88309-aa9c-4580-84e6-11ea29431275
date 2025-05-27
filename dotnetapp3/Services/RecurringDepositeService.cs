using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnetapp3.Repositroy;
using dotnetapp3.ViewModels;
using dotnetapp3.Data;
using CommonLibrary.Models;

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
        public async Task<List<RecurringDeposit>> GetRecurringDepositByAccountIdAsync(int accountId){
            return await _RecurringDepositRepository.GetRecurringDepositByAccountIdAsync(accountId);
        }
        public async Task<RecurringDeposit> GetRecurringDepositAccountsByIdAsync(int id){
            return await _RecurringDepositRepository.GetRecurringDepositAccountsByIdAsync(id);
        }      
        public async Task<RecurringDeposit> CreateRecurringDepositAccountAsync(RecurringDepositViewModel account){
         return await _RecurringDepositRepository. CreateRecurringDepositAccountAsync(account);  
        }
        public async Task<bool> UpdateRecurringDepositAccountAsync(RecurringDepositViewModel account){
          return await _RecurringDepositRepository.UpdateRecurringDepositAccountAsync(account);  
        } 
 
        
    }
}