using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.TaxCalculator;

namespace PaySpace.WebAPI.Controllers
{
    [ApiController]
    
    public class TaxController : ControllerBase
    {
        private ICalculator _calculator;
        public TaxController(ICalculator calculator)
        {
            _calculator = calculator;
        }

        [HttpGet]
        [Route("tax/flatrate", Name = "FlatRate")]
        public async Task<IActionResult> GetFlatRateAsync()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var tax = await _calculator.GetFlatRateTaxAsync(1000);
            return Ok(JsonConvert.SerializeObject(tax, settings));
        }
    }
}