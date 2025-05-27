using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLibrary.Models;

namespace dotnetapp.ViewModels
{
    public class AccountCreateVM
    {
        public int UserId { get; set; }
        public string AccountHolderName { get; set; }
        public string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string ProofOfIdentity { get; set; }
    }
}