using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommonLibrary.Models
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
        [StringLength(30)]
        [RegularExpression("Savings|Current", ErrorMessage="Invalid Account Type")]  
        // AccountTypeEnum
        public string AccountType { get; set; }

        [Required]
        public Decimal Balance { get; set; }

        [Required]
        [StringLength(30)]
        [RegularExpression("Pending|Active|Deactivated", ErrorMessage="Invalid Account Status")] 
        // AccountStatusEnum
        public string Status { get; set; }

        [Required]
        [StringLength(100)]
        public string ProofOfIdentity { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime LastUpdated { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        [InverseProperty("Account")]
        public List<Transaction> Transactions { get; set; } = new List<Transaction>();

        [JsonIgnore]
        [InverseProperty("ReceivedAccount")]
        public List<Transaction> ReceivedTransactions { get; set; } = new List<Transaction>();

        [JsonIgnore]
        public List<FixedDeposit> FixedDeposits = new List<FixedDeposit>();

        [JsonIgnore]
        public List<RecurringDeposit> RecurringDeposits = new List<RecurringDeposit>();

        [JsonIgnore]
        public List<Notification> Notifications = new List<Notification>();
    }
}