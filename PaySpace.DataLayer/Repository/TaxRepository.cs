using PaySpace.DataLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySpace.DataLayer
{
    public class TaxRepository : ITaxRepository
    {
        private readonly PaySpaceContext _context;
        public TaxRepository(PaySpaceContext paySpaceContext)
        {
            _context = paySpaceContext;
        }
        public void Add(Tax tax)
        {
            tax.CreatedDate = DateTime.Now;
            _context.Add(tax);
            _context.SaveChanges();
        }
        
        public Tax Get(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Tax> GetAll()
        {
            return _context.Taxes.ToList();
        }

        public void Remove(Tax tax)
        {
            _context.Remove(tax);
        }
    }
}
