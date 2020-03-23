using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PaySpace.TaxCalculator
{
    public interface ICalculator
    {
        Task<Tax> GetProgressiveTaxAsync(decimal income);
        Task<Tax> GetFlatValueTaxAsync(decimal income);
        Task<Tax> GetFlatRateTaxAsync(decimal income);
    }
}
