using AutoMapper;
using PaySpace.DataLayer.Model;

namespace PaySpace.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxCalculator.Tax, Tax>().ForMember(dest=> dest.PostalCode, opt => opt.MapFrom(src=> src.PostalCodeId)).ReverseMap();
        }

    }
}
