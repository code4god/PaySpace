using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataAccess.Model
{
    public class Tax
    {
        public decimal Income { get; set; }
        public decimal Amount { get; set; }
        public int PostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
