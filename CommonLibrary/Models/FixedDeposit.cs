using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace CommonLibrary.Models
{
    public class FixedDeposit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FDId { get; set; }

        [ForeignKey(nameof(User))]
        public int? UserId { get; set; }

        [Required]
        [ForeignKey(nameof(Account))]
        public int AccountId { get; set; }

        public Decimal PrincipalAmount { get; set; }

        public Decimal InterestRate { get; set; }

        public int TentureMonths { get; set; }

        public Decimal MatuarityAmount { get; set; }

        //DepositStatusEnum
        [StringLength(30)]
        [RegularExpression("Active|Closed|ClosedPrematuarely", ErrorMessage="Invalid Status")] 
        public string Status { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateClosed { get; set; }

        [JsonIgnore]
        public User? User { get; set; }

        [JsonIgnore]
        public Account? Account { get; set; }

        [JsonIgnore]
        public List<Notification> Notifications = new List<Notification>();
    }
}