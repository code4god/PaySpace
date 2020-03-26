using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            _logger.LogInformation("hellow!");
            var tax = new Tax();
            var codes = new List<PostalCode>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342");
                //HTTP GET
                var responseTask = await client.GetAsync("/postalCode/codes"); //await client.GetAsync("/tax/flatrate");
               
                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    codes = JsonConvert.DeserializeObject<List<PostalCode>>(result);
                    //tax = JsonConvert.DeserializeObject<Tax>(result);
                }
                else //web api sent error response 
                {
                //    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            var viewModel = _mapper.Map<HomeViewModel>(tax);
            viewModel.PostalCodes = codes;
            return View(viewModel);
        }

        public async Task<IActionResult> CalculateTax (HomeViewModel viewModel)
        {
            var tax = new Tax();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44342");
                //HTTP GET
                var responseTask =  await client.GetAsync($"/tax/flatrate?income={viewModel.Income}"); //await client.GetAsync("/tax/flatrate");

                if (responseTask.IsSuccessStatusCode)
                {
                    var result = responseTask.Content.ReadAsStringAsync().Result;
                    tax = JsonConvert.DeserializeObject<Tax>(result);
                    //tax = JsonConvert.DeserializeObject<Tax>(result);
                }
                else //web api sent error response 
                {
                    //    //log response status here..
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }
            return Ok(tax);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
