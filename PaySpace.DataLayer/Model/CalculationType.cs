using System;
using System.Collections.Generic;
using System.Text;

namespace PaySpace.DataLayer.Model
{
    public class CalculationType
    {
        public int Id { get; set; }

        public PostalCode PostalCode { get; set; }

        public string Description { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
