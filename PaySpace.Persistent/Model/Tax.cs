using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PaySpace.Persistent.Model
{
    public class Tax
    {
        [Key]
        [Required]
        public int Id { get; set; }
        public decimal Income { get; set; }
        public decimal Amount { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 4)]
        public string PostalCode { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedDate { get; set; }
    }
}
