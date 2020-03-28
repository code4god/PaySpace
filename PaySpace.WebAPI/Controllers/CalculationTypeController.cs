using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.DataLayer.Repository;

namespace PaySpace.WebAPI.Controllers
{
    public class CalculationTypeController : ControllerBase
    {
        private ICalculationTypesRepository _calculationTypesRepository;
        private IMapper _mapper;
        public CalculationTypeController(ICalculationTypesRepository calculationTypesRepository, IMapper mapper)
        {
            _calculationTypesRepository = calculationTypesRepository;
            _mapper = mapper;
        }


        [HttpGet]
        [Route("calctype/gettypebypostalcode", Name = "GetTypeByPostalCode")]
        public IActionResult GetTypeByPostalCode(int Id)
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var calculationType = _calculationTypesRepository.GetCalculationTypeByPostalCode(Id);
            return Ok(JsonConvert.SerializeObject(calculationType, settings));
        }
    }
}