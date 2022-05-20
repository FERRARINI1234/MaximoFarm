using MaximoFarm.Register.Application.Queries.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.Interfaces
{
    public interface ICadEstoqueQueries
    {
        Task<List<CadEstoqueViewModel>> ConsultarCadastroEstoque();
        Task<List<CadEstoqueViewModel>> ConsultarCadastroEstoquePorCodigo(int codigo);
    }
}
