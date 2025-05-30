using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;

namespace dotnetapp3.Repository
{
    public interface IAccountRepository
    {
        Task<Account?> GetAccountByIdAsync(int id);
    } 
}