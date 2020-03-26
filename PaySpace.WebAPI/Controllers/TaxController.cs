using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.DataLayer;
using PaySpace.TaxCalculator;

namespace PaySpace.WebAPI.Controllers
{
    [ApiController]
    
    public class TaxController : ControllerBase
    {
        private ICalculator _calculator;
        private ITaxRepository _taxRepository;
        private IMapper _mapper;
        public TaxController(ICalculator calculator, ITaxRepository taxRepository, IMapper mapper)
        {
            _calculator = calculator;
            _taxRepository = taxRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("tax/flatrate", Name = "FlatRate")]
        public async Task<IActionResult> GetFlatRateAsync(decimal income)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var tax = await _calculator.GetFlatRateTaxAsync(income);
            return Ok(JsonConvert.SerializeObject(tax, settings));
        }

        [HttpGet]
        [Route("tax/getall", Name = "GetTaxes")]
        public IActionResult GetAll()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var tax =  _taxRepository.GetAll();
            return Ok(JsonConvert.SerializeObject(tax, settings));
        }

        [HttpPost]
        [Route("tax/add", Name = "Add")]
        public void Add([FromBody] Tax item)
        {
            var entity = _mapper.Map<Tax>(item);
            //_taxRepository.Add(entity);
        }
    }
}