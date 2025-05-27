using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnetapp3.ViewModels
{
    public class RecurringDepositViewModel
    {
        public int RDId { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public Decimal MonthlyDeposit { get; set; }
        public Decimal InterestRate { get; set; }
        public int TentureMonths { get; set; }
        public Decimal MatuarityAmount { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; } 
        
    }
}