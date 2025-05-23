using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NotificationId { get; set; }

        [ForeignKey(nameof(Account))]
        public int? AccountId { get; set; }

        [ForeignKey(nameof(FixedDeposit))]
        public int? FDId { get; set; }

        [ForeignKey(nameof(RecurringDeposit))]
        public int? RDId { get; set; }

        [ForeignKey(nameof(Transaction))]
        public int? TransactionId { get; set; }

        [ForeignKey(nameof(User))]   
        public int? UserId { get; set; }

        public string Message { get; set; }

        public bool IsRead { get; set; }

        public DateTime CreatedAt { get; set; }

        public Account? Account { get; set; }

        public FixedDeposit? FixedDeposit { get; set; }

        public RecurringDeposit? RecurringDeposit { get; set; }

        public Transaction? Transaction { get; set; }

        public User? User { get; set; }
    }
}