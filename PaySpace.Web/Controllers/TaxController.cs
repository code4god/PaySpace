using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.TaxCalculator;
using PaySpace.Web.Models;

namespace PaySpace.Web.Controllers
{
    public class TaxController : Controller
    {
        private readonly ICalculator _calculator;
        private readonly IMapper _mapper;

        public TaxController(ICalculator calculator, IMapper mapper)
        {
            _calculator = calculator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await HttpClientGet("tax/getall");
            var viewModel = new CalculateTaxViewModel
            {
                Taxes = JsonConvert.DeserializeObject<List<Tax>>(result).OrderByDescending(t=> t.CreatedDate)
            };
            return View(viewModel);
        }

        [HttpPost]
        [Route("tax/calculatetax", Name = "CalculateTax")]
        public async Task<IActionResult> CalculateTaxAsync(HomeViewModel viewModel)
        {
            var tax = new Tax();
            tax = await HttpClientPost(viewModel, tax);
            var calcTaxViewModel = _mapper.Map<CalculateTaxViewModel>(tax);           

            return View("CalculateTax", calcTaxViewModel);
        }

        private async Task<Tax> HttpClientPost(HomeViewModel viewModel, Tax tax)
        {
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

            return tax;
        }

        private async Task<string> HttpClientGet(string endPoint)
        {
            var result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342");

                var response = await client.GetAsync(endPoint);

                if (response.IsSuccessStatusCode)
                {
                    result = response.Content.ReadAsStringAsync().Result;

                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return result;
        }
    }
}