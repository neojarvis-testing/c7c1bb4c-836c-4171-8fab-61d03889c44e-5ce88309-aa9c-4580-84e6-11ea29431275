using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Text.Json.Serialization;

namespace CommonLibrary.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(400)]
        public string Email { get; set; }

        [Required]
        [StringLength(500)]
        public string Password { get; set; }

        [Required]
        [StringLength(200)]
        public string Username { get; set; }

        [Required]
        [Phone]
        [StringLength(30)]
        public string MobileNumber { get; set; }

        // UserRoleEnum
        [Required]
        [StringLength(30)] 
        [RegularExpression("Customer|Teller|Manager", ErrorMessage="Invalid User Role")]       
        public string UserRole { get; set; }

        [JsonIgnore]
        public List<Account> Accounts = new List<Account>();

        [JsonIgnore]
        public List<FixedDeposit> FixedDeposits = new List<FixedDeposit>();

        [JsonIgnore]
        public List<RecurringDeposit> RecurringDeposits = new List<RecurringDeposit>();

        [JsonIgnore]
        public List<Notification> Notifications = new List<Notification>();
    }
}