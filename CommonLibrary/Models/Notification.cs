using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CommonLibrary.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public int? AccountId { get; set; }
        public int? FDId { get; set; }
        public int? RDId { get; set; }
        public int? TransactionId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}