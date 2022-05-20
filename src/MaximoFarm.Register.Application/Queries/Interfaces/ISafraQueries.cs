using MaximoFarm.Register.Application.Queries.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.Interfaces
{
    public interface ISafraQueries
    {
        Task<List<SafraViewModel>> ConsultarSafras();
        Task<List<SafraViewModel>> ConsultarSafrasPorCodigo(int codigo);
    }
}
