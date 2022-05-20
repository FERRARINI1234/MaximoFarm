using MaximoFarm.Register.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.Interfaces
{
    public interface IContaReceitaQueries
    {
        Task<List<ContaReceitaViewModel>> ConsultarContaReceita();
        Task<List<ContaReceitaViewModel>> ConsultarContaReceitaPorCodigo(int codigo);
    }
}
