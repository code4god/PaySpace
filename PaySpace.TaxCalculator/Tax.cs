using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.TaxCalculator
{
    [Serializable]
    public class Tax
    {
        public decimal Income { get; set; }
        public decimal Amount { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
