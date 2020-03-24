using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PaySpace.DataLayer.Repository;

namespace PaySpace.WebAPI.Controllers
{
    public class PostalCodeController : ControllerBase
    {
        private IPostalCodeRepository _postalCodeRepository;
        private IMapper _mapper;
        public PostalCodeController(IPostalCodeRepository postalCodeRepository, IMapper mapper)
        {
            _postalCodeRepository = postalCodeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("postalCode/codes", Name = "PostalCodes")]
        public IActionResult GetPostalCodes()
        {
            var settings = new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                MissingMemberHandling = MissingMemberHandling.Ignore
            };
            var codes =  _postalCodeRepository.GetAll();
            return Ok(JsonConvert.SerializeObject(codes, settings));
        }
    }
}