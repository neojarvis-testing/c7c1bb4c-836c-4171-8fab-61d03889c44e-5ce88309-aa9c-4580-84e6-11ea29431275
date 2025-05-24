using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
     public enum AccountType {
            Savings = 1,
            Current = 2
        }
    public class Account
    {
        public int AccountId { get; set; }
        public int UserId { get; set; }
        public string AccountHolderName { get; set; }
        public AccountType AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; }
        public string ProofOfIdentity { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastUpdated { get; set; }
    }

    public class AccountConfiguration : EntityTypeConfiguration<Account> {
        public AccountConfiguration(){
            this.property(i => i.AccountType).hasColumnType("int").IsRequired();
        }
    }
}