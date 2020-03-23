using AutoMapper;
using PaySpace.TaxCalculator;
using PaySpace.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PaySpace.Web
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Tax, HomeViewModel>(); 
        }

    }
}
