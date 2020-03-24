using Microsoft.EntityFrameworkCore;
using PaySpace.DataLayer.Model;

namespace PaySpace.DataLayer
{
    public class PaySpaceContext : DbContext
    {
        public PaySpaceContext(DbContextOptions<PaySpaceContext> options) 
            : base(options) 
        { 
        
        }

        public DbSet<Tax> Taxes { get; set; }
        public DbSet<PostalCode> PostalCodes { get; set; }
        public DbSet<CalculationType> CalculationTypes { get; set; }


    }
}
