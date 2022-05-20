using MaximoFarm.Register.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class CadEstoque 
    {
        public int CadEstoqueId { get; private set; }
        public int CodCadEstoque { get; private set; }
        public string DescCadEstoque { get; private set; }

        public CadEstoque( int codCadEstoque, string descCadEstoque)
        {
            CodCadEstoque = codCadEstoque;
            DescCadEstoque = descCadEstoque;
        }
        public void AlterarId(int cadEstoqueId)
        {
            CadEstoqueId = cadEstoqueId;
        }
        public void AlterarCodigo(int codCadEstoque)
        {
            CodCadEstoque = codCadEstoque;
        }
        public void AlterarDescricao(string descCadEstoque)
        {
            DescCadEstoque = descCadEstoque;
        }
    }
}
