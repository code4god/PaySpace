using PaySpace.TaxCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.Web.Models
{
    public class CalculateTaxViewModel
    {
        public decimal Income { get; set; }        
        public decimal Amount { get; set; }
        public string PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public IEnumerable<Tax> Taxes { get; set; }
    }
}
