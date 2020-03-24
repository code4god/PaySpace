using AutoMapper;
using PaySpace.DataLayer.Model;

namespace PaySpace.WebAPI
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<TaxCalculator.Tax, Tax>();
        }

    }
}
