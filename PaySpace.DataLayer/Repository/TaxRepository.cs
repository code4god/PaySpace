using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.DataLayer
{
    public class TaxRepository : ITaxRepository
    {
        private readonly PaySpaceContext _context;
        public TaxRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }
        public Task AddAsync(Tax tax)
        {
            tax.CreatedDate = DateTime.Now;
            _context.Add(tax);

           return _context.SaveChangesAsync();
        }
        
        public Tax Get(int Id)
        {
            return _context.Taxes.Where(t => t.Id == Id).SingleOrDefault();
        }

        public IEnumerable<Tax> GetAll()
        {
            return _context.Taxes.ToList();
        }

        public Task RemoveAsync(Tax tax)
        {
            _context.Remove(tax);
            return _context.SaveChangesAsync();           
        }
    }
}
