using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
    public enum Status {
        Active =1,
        Closed =2,
        PrematurelyClosed =3
    }
    public class FixedDeposit
    {
        public int FDId { get; set; }
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public decimal PrincipalAmount { get; set; }
        public decimal InterestRate { get; set; }
        public int TensureMonths { get; set; }
        public decimal MaturityAmount { get; set; }
        public Status Status { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateClosed { get; set; }
    }

    public class FixedDepositConfiguration : EntityTypeConfiguration<FixedDeposit> {
        public FixedDepositConfiguration(){
            this.property(i => i.Status).hasColumnType("int").IsRequired();
        }
    }
}