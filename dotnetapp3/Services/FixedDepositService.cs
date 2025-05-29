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
    public class FixedDepositService : IFixedDepositService
    {
        private readonly IFixedDepositRepository _FixedDepositRepository;
        public FixedDepositService(IFixedDepositRepository FixedDepositRepository){
            _FixedDepositRepository = FixedDepositRepository;
        }

        public async Task<List<FixedDeposit>> GetAllAsync(){
            return await _FixedDepositRepository.GetAllAsync();
        }
        
        public async Task<FixedDeposit> CreateFixedDepositAccountAsync(FixedDepositViewModel account)
        {
            if(account.UserId <=0)
            {
                throw InvalidValueTypeException.WithType(account.UserId.ToString());
            } 
            if(account.UserId <=0)
            {
                throw InvalidValueTypeException.WithType(account.AccountId.ToString());
            }    
            var newAccount = await _FixedDepositRepository. CreateFixedDepositAccountAsync(account);
            return newAccount;
        }

        public async Task<bool> CloseFixedDepositAccountByIdAsync(int id){
          return await _FixedDepositRepository.CloseFixedDepositAccountByIdAsync(id);  
        }
        
        public async Task<List<FixedDeposit>> GetFixedDepositAccountsByUserIdAsync(int userId){
            return await _FixedDepositRepository.GetFixedDepositAccountsByUserIdAsync(userId);
        }

        public async Task<List<FixedDeposit>> GetFixedDepositByAccountIdAsync(int accountId){
            return await _FixedDepositRepository.GetFixedDepositByAccountIdAsync(accountId);
        } 
        
    }
}