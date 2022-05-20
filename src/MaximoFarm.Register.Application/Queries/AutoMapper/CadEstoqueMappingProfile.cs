using AutoMapper;
using MaximoFarm.Register.Application.Queries.ViewModels;
using MaximoFarm.Register.Domain.Entities;

namespace MaximoFarm.Register.Application.Queries.AutoMapper
{
    public class CadEstoqueMappingProfile : Profile
    {
        public CadEstoqueMappingProfile()
        {
            CreateMap<CadEstoque, CadEstoqueViewModel>()
              .ReverseMap();
        }
    }
}
