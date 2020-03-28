using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.DataLayer;
using PaySpace.DataLayer.Repository;
using PaySpace.TaxCalculator;

namespace PaySpace.WebAPI.Controllers
{
    [ApiController]
    
    public class TaxController : ControllerBase
    {
        private ICalculator _calculator;
        private ITaxRepository _taxRepository;
        private IPostalCodeRepository _postalCodeRepository;
        private IMapper _mapper;
        public TaxController(ICalculator calculator, ITaxRepository taxRepository, IPostalCodeRepository postalCodeRepository, IMapper mapper)
        {
            _calculator = calculator;
            _taxRepository = taxRepository;
            _postalCodeRepository = postalCodeRepository;
            _mapper = mapper;
        }

        [HttpPost]
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


        [HttpPost]
        [Route("tax/calculatetaxtype", Name = "TaxType")]
        public async Task<IActionResult> CalculateTaxByTypeAsync(int postalCodeId, decimal income)
        {
            var postalCode = _postalCodeRepository.Get(postalCodeId);
            var tax = new Tax();
            switch (postalCode.Code)
            {
                case "7441":
                    {
                        tax = await _calculator.GetProgressiveTaxAsync(income);                        
                        break;
                    }

                case "A100":
                    {
                        tax = await _calculator.GetFlatValueTaxAsync(income);
                        break;
                    }

                case "7000":
                    {
                        tax = await _calculator.GetFlatRateTaxAsync(income);
                        break;
                    }

                case "1000":
                    {
                        tax = await _calculator.GetProgressiveTaxAsync(income);
                        break;
                    }
                default:
                    break;
            }

            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };

            var saveTax = new DataLayer.Model.Tax();

            try
            {
                tax.PostalCodeId = postalCode.Id;
                tax.PostalCode = postalCode.Code;
                saveTax = _mapper.Map<DataLayer.Model.Tax>(tax);
                _taxRepository.Add(saveTax);

            }
            catch (System.Exception ex)
            {

                throw ex;
            }
             
            return Ok(JsonConvert.SerializeObject(saveTax, settings));
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