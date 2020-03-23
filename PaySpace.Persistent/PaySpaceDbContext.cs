using Microsoft.EntityFrameworkCore;
using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.Persistent
{
    public class PaySpaceDbContext : DbContext
    {
        public PaySpaceDbContext(DbContextOptions<PaySpaceDbContext> options) : base(options)
        {
            
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
