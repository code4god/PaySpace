using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PaySpace.TaxCalculator;
using PaySpace.Web.Models;

namespace PaySpace.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICalculator _calculator;
        private readonly IMapper _mapper;
        public HomeController(ILogger<HomeController> logger, ICalculator calculator, IMapper mapper)
        {
            _logger = logger;
            _calculator = calculator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("hello web app!");
            var codes = new List<PostalCode>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342");
               
                var response = await client.GetAsync("/postalCode/codes"); 
               
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    codes = JsonConvert.DeserializeObject<List<PostalCode>>(result);
                }
                else 
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            var viewModel = new HomeViewModel
            {
                PostalCodes = codes
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("home/calculatetax", Name ="CalculateTax")]
        public async Task<IActionResult> CalculateTaxAsync (HomeViewModel viewModel)
        {
            var tax = new Tax();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342");
                var parameters = new Dictionary<string, string>();
                parameters["text"] = "application/json";

                var response = await client.PostAsync($"tax/calculatetaxtype?postalCodeId={viewModel.SelectedPostalCodeId}&income={viewModel.Income}", new FormUrlEncodedContent(parameters)); //await client.PostAsync($"/tax/flatrate?income={viewModel.Income}", new FormUrlEncodedContent(parameters));

                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    tax = JsonConvert.DeserializeObject<Tax>(result);
                }
                else //web api sent error response 
                {
                    //    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            var calcTaxViewModel = _mapper.Map<CalculateTaxViewModel>(tax);
            return PartialView("CalculateTax", calcTaxViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
