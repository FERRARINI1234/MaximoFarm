using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class PontoAbastecimento
    {
        public int PontoAbastecimentoId { get;private set; }
        public int CodPontoAbastecimento { get; private set; }
        public string DescPontoAbastecimento { get; private set; }

        public PontoAbastecimento(int codPontoAbastecimento, string descPontoAbastecimento)
        {
            CodPontoAbastecimento = codPontoAbastecimento;
            DescPontoAbastecimento = descPontoAbastecimento;
        }
        public void AlterarCodigo(int codPontoAbastecimento)
        {
            CodPontoAbastecimento = codPontoAbastecimento;
        }
        public void AlterarDescricao(string descPontoAbastecimento)
        {
            DescPontoAbastecimento = descPontoAbastecimento;
        }
    }
}
