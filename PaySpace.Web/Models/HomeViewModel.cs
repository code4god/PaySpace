using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PaySpace.Web.Models
{
    public class HomeViewModel
    {
        [Range(1, 100000000)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "UPRN must be numeric")]
        public decimal Income { get; set; }
        public decimal Amount { get; set; }
        public int SelectedPostalCodeId { get; set; }
        public PostalCode SelectedPostalCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Test { get; set; }
        public List<PostalCode> PostalCodes { get; set; }
    }    
}
