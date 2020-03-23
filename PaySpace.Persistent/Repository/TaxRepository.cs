using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PaySpace.Persistent.Repository
{
    public class TaxRepository : ITaxRepository
    {
        protected readonly PaySpaceDbContext DbContext;
       
        public PaySpaceDbContext Context
        {
            get { return DbContext as PaySpaceDbContext; }
        }

        public IEnumerable<Tax> GetTaxByPostalCode(string postalCode)
        {
            return Context.Taxes.Where(x => x.PostalCode == postalCode);
        }

        public IEnumerable<Tax> GetTaxCalculations()
        {
            return Context.Taxes.ToList();
        }

        

        public void Add(Tax entity)
        {
            Context.Set<Tax>().Add(entity);
        }

        public Tax Get(int id)
        {
            return Context.Set<Tax>().Find(id);
        }

        public IEnumerable<Tax> GetAll()
        {
            return Context.Set<Tax>().ToList();
        }

        public void Remove(Tax entity)
        {
            Context.Set<Tax>().Remove(entity);
        }
    }
}
