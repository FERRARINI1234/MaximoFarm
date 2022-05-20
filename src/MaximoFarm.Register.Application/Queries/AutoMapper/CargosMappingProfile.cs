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
    public class CargosMappingProfile : Profile
    {
        public CargosMappingProfile()
        {
            CreateMap<Cargos, CargosViewModel>()
              .ReverseMap();
        }
    }
}
