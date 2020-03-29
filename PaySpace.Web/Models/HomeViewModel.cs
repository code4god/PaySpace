using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Threading.Tasks;

namespace PaySpace.Web.Models
{
    public class HomeViewModel
    {
        [Range(1, 9999999999999999.99, ErrorMessage = "Income must be greater than 0!")]
        [Required(ErrorMessage = "Income must be greater than 0!")]
        public decimal Income { get; set; }

        public decimal Amount { get; set; }
        [Required(ErrorMessage = "A postal code must be selected!")]
        public int SelectedPostalCodeId { get; set; }

        public PostalCode SelectedPostalCode { get; set; }
        public DateTime CreatedDate { get; set; }

        [BindRequired]
        public SelectList Codes { get; set; }
        public List<PostalCode> PostalCodes { get; set; }

        public void OnGet(List<PostalCode> PostalCodes)
        {
            Codes = new SelectList(PostalCodes, nameof(PostalCode.Id), nameof(PostalCode.Code));
        }
    }
}
