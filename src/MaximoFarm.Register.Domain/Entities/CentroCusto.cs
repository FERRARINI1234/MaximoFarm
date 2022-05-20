using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class CentroCusto
    {
        public int CentroCustoId { get; private set; }
        public int CodCentroCusto { get; private set; }
        public string DescCentroCusto { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Equipamentos> Equipamentos { get; set; }

        public CentroCusto( int codCentroCusto, string descCentroCusto, bool ativo)
        {
            CodCentroCusto = codCentroCusto;
            DescCentroCusto = descCentroCusto;
            Ativo = ativo;
        }
        public void AlterarId(int centroCustoId)
        {
            CentroCustoId = centroCustoId;
        }
        public void AlterarCodigo(int codCentroCusto)
        {
            CodCentroCusto = codCentroCusto;
        }
        public void AlterarDescricao(string descCentroCusto)
        {
            DescCentroCusto = descCentroCusto;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
