using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class CentroReceita
    {
        public int CentroReceitaId { get;private set; }
        public int CodCentroReceita { get; private set; }
        public string DescCentroReceita { get; private set; }
        public bool Ativo { get; private set; }

        public CentroReceita( int codCentroReceita, string descCentroReceita, bool ativo)
        {
            CodCentroReceita = codCentroReceita;
            DescCentroReceita = descCentroReceita;
            Ativo = ativo;
        }

        public void AlterarId(int centroReceitaId)
        {
            CentroReceitaId = centroReceitaId;
        }
        public void AlterarCodigo(int codCentroReceita)
        {
            CodCentroReceita = codCentroReceita;
        }
        public void AlterarDescricao(string descCentroReceita)
        {
            DescCentroReceita = descCentroReceita;
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
