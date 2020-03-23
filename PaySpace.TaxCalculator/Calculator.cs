using System;
using System.Threading.Tasks;

namespace PaySpace.TaxCalculator
{
    public class Calculator : ICalculator
    {
        #region constants
        private const decimal FLAT_RATE = 17.5m;
        private const decimal FLAT_VALUE = 5m;
        private const decimal FLAT_VALUE_PER_YEAR = 10000m;
        private const decimal INDIVIDUAL_PER_YEAR_EARNINGS = 200000m;
        private const string POSTAL_CODE_FLAT_RATE = "7000";
        private const string POSTAL_CODE_FLAT_VALUE = "A100";
        private const string POSTAL_CODE_PROGRESSIVE = "7441";
        #endregion

        #region Methods
        public Task<Tax> GetFlatRateTaxAsync(decimal income)
        {
            return Task.FromResult(new Tax 
                {
                    Amount = (income * FLAT_RATE) / 100,
                    Income = income,
                    PostalCode = POSTAL_CODE_FLAT_RATE,
                    CreatedDate = DateTime.Now                    
            });
        }

        public Task<Tax> GetFlatValueTaxAsync(decimal income)
        {
            if (income < INDIVIDUAL_PER_YEAR_EARNINGS)
                return Task.FromResult(new Tax
                {
                    Amount = (income * FLAT_VALUE) / 100,
                    Income = income,
                    PostalCode = POSTAL_CODE_FLAT_VALUE
                });

            return Task.FromResult(new Tax
            {
                Amount = FLAT_VALUE_PER_YEAR,
                Income = income,
                PostalCode = POSTAL_CODE_FLAT_VALUE
            });
        }

        public Task<Tax> GetProgressiveTaxAsync(decimal income)
        {
            var taxAmount = 0m;
            var ranges = new[]
            {
                new { From = 0m, To = 8350m, Rate = 10m },
                new { From = 8351m, To = 33950m, Rate = 15m },
                new { From = 33951m, To = 82250m, Rate = 25m },
                new { From = 82251m, To = 171550m, Rate = 28m },
                new { From = 171551m, To = 372950m, Rate = 33m },
                new { From = 372951m, To = - (171551m-372950m *33m), Rate = 35m }
            };

            foreach (var range in ranges)
            {
                var previousRange = range;
                if(income > range.From && income < range.To)
                {
                    if (income > previousRange.To)
                    {
                        var marginalTax = (previousRange.To * previousRange.Rate) / 100;
                        var currentRangeAmount = income - previousRange.To;
                        taxAmount = (currentRangeAmount * range.Rate) / 100;
                    }
                    //else
                    //{
                    //    taxAmount = (income * range.Rate) / 100;
                    //}
                    break;
                }
            }

            return Task.FromResult(new Tax
            {
                Amount = taxAmount,
                Income = income,
                PostalCode = POSTAL_CODE_PROGRESSIVE
            }); 
        }
        #endregion
    }
}
