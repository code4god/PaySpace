using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PaySpace.DataLayer.Model
{
    public class Tax
    {
        
        public int Id { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Income { get; set; }

        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
       
        public int PostalCode { get; set; }        

        public DateTime CreatedDate { get; set; }
    }
}
