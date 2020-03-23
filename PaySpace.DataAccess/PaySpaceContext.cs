using Microsoft.EntityFrameworkCore;
using PaySpace.DataAccess.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.Persistent
{
    public class PaySpaceContext : DbContext
    {
        public PaySpaceContext(DbContextOptions<PaySpaceContext> options) : base(options) 
        { }

        public DbSet<Tax> Taxes { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        //    modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        //    modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

        //    modelBuilder.Configurations.Add(new ProductMap());
        //}
    }
}
