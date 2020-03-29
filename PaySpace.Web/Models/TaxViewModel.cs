using PaySpace.TaxCalculator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.Web.Models
{
    public class TaxViewModel
    {
        public decimal Income { get; set; }
        public decimal Amount { get; set; }
        public string Code { get; set; }
        public string CalculationType { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Tax> Taxes { get; set; }
    }
}
