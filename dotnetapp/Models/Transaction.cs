using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
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

        public TransactionTypeEnum TransactionTypeEnum { get; set; }

        public Decimal Amount { get; set; }

        public TransactionStatusEnum Status { get; set; }

        [StringLength(4000)]
        public string Description { get; set; }

        public bool IsApprovedByTeller { get; set; }

        public bool IsApprovedByManager{ get; set; }

        public Account Account { get; set; }

        public Account? ReceivedAccount { get; set; }

        public List<Notification> Notifications = new List<Notification>();
    }
}