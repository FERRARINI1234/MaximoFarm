using AutoMapper;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.AutoMapper
{
    public class CentroCustoMappingProfile : Profile
    {
        public CentroCustoMappingProfile()
        {
            CreateMap<CentroCusto, CentroCustoViewModel>().ReverseMap();
        }
    }
}
