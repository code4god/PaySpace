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
        
        public HomeController(ILogger<HomeController> logger, ICalculator calculator, IMapper mapper)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("hello web app!");
            var result = await HttpClientGet($"/postalCode/codes");
            var codes = JsonConvert.DeserializeObject<List<PostalCode>>(result);
            var viewModel = new HomeViewModel
            {
                PostalCodes = codes
            };
            return View(viewModel);
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
