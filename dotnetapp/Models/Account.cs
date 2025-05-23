using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Required]
        [ForeignKey(nameof(User))]
        public int UserId { get; set; }

        [Required]
        [StringLength(500)]
        public string AccountHolderName { get; set; }

        [Required]
        public AccountTypeEnum AccountType { get; set; }

        [Required]
        public Decimal Balance { get; set; }

        [Required]
        public AccountStatusEnum Status { get; set; }

        [Required]
        [StringLength(100)]
        public string ProofOfIdentity { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        public User User { get; set; }

        [InverseProperty("Account")]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [InverseProperty("ReceivedAccount")]
        public List<Transaction> ReceivedTransactions { get; set; } = new List<Transaction>();

        public List<FixedDeposit> FixedDeposits = new List<FixedDeposit>();

        public List<RecurringDeposit> RecurringDeposits = new List<RecurringDeposit>();

        public List<Notification> Notifications = new List<Notification>();
    }
}