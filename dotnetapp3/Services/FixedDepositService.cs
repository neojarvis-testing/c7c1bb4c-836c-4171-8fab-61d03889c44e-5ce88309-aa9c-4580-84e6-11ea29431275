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
    public class FixedDepositService : IFixedDepositService
    {
        private readonly IFixedDepositRepository _fixedDepositRepository;
        public FixedDepositService(IFixedDepositRepository fixedDepositRepository){
            _fixedDepositRepository = fixedDepositRepository;
        }

        public async Task<List<FixedDeposit>> GetAllAsync(){
            return await _fixedDepositRepository.GetAllAsync();
        }
        public async Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId){
            return await _fixedDepositRepository.GetFixedDepositAccountsByUserIdAsync(userId);
        }
        public async Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId){
            return await _fixedDepositRepository.GetFixedDepositByAccountIdAsync(accountId);
        }
        public async Task<FixedDeposit> GetFixedDepositAccountsByIdAsync(int id){
            return await _fixedDepositRepository.GetFixedDepositAccountsByIdAsync(id);
        }      
        public async Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account){
         return await _fixedDepositRepository. CreateFixedDepositAccountAsync(account);  
        }
        public async Task<bool> UpdateFixedDepositAccountAsync(FixedDepositViewModel account){
          return await _fixedDepositRepository.UpdateFixedDepositAccountAsync(account);  
        } 
        
    }
}