using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CommonLibrary.Models;

namespace dotnetapp3.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<FixedDeposit> FixedDeposits {get; set; }
        public DbSet<RecurringDeposit> RecurringDeposits {get; set; }
    }
}