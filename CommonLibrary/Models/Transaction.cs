using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommonLibrary.Models
{
    public class Transaction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TransactionId { get; set; }

        [Required]
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }

        [ForeignKey(nameof(ReceivedAccount))]
        public int? ReceivedAccountId { get; set; }

        // TransactionTypeEnum
        [StringLength(30)]
        [RegularExpression("Deposit|Withdrawal|Transfer", ErrorMessage="Invalid Transaction Type")] 
        public string TransactionType { get; set; }

        public Decimal Amount { get; set; }

        // TransactionStatusEnum
        [StringLength(30)]
        [RegularExpression("Pending|Completed|Failed", ErrorMessage="Invalid Transaction Status")] 
        public string Status { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public bool IsApprovedByTeller { get; set; }

        public bool IsApprovedByManager{ get; set; }

        [JsonIgnore]
        public Account? Account { get; set; }

        [JsonIgnore]
        public Account? ReceivedAccount { get; set; }

        [JsonIgnore]
        public List<Notification> Notifications = new List<Notification>();
    }
}