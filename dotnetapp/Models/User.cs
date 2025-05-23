using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnetapp.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [StringLength(400)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Username { get; set; }

        [Required]
        [StringLength(30)]
        public string MobileNumber { get; set; }

        [Required]
        public UserRoleEnum UserRole { get; set; }

        public List<Account> Accounts = new List<Account>();

        public List<FixedDeposit> FixedDeposits = new List<FixedDeposit>();

        public List<RecurringDeposit> RecurringDeposits = new List<RecurringDeposit>();

        public List<Notification> Notifications = new List<Notification>();
    }
}