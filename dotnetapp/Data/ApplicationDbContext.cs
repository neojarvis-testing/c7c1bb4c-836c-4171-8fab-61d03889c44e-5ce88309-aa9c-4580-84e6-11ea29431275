using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommonLibrary.Models;

namespace dotnetapp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users {get; set; }
        public DbSet<Account> Accounts {get; set; }
        public DbSet<Transaction> Transactions {get; set; }
        public DbSet<FixedDeposit> FixedDeposits {get; set; }
        public DbSet<RecurringDeposit> RecurringDeposits {get; set; }
        public DbSet<Notification> Notifications {get; set; }
    }
}