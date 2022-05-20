using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Ciclo
    {
        public int CicloId { get; private set; }
        public int CodCiclo { get; private set; }
        public string DescCiclo { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Variedades> Variedades { get; set; }

        public Ciclo( int codCiclo, string descCiclo, bool ativo)
        {
            CodCiclo = codCiclo;
            DescCiclo = descCiclo;
            Ativo = ativo;
        }

        public void AlterarCodigo(int codCiclo)
        {
            CodCiclo = codCiclo;
        }

        public void AlterarDescricao(string descCiclo)
        {
            DescCiclo = descCiclo;
        }

        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
