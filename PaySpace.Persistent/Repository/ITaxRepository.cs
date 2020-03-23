using PaySpace.Persistent.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.Persistent.Repository
{
    public interface ITaxRepository 
        : IRepository<Tax>
    {
        IEnumerable<Tax> GetTaxCalculations();
        IEnumerable<Tax> GetTaxByPostalCode(string postalCode);
    }
}
