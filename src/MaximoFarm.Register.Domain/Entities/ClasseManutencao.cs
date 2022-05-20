using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class ClasseManutencao
    {
        public int ClasseManutencaoId { get; private set; }
        public int CodClasseManutencao { get; private set; }
        public string DescClasseManutencao { get; private set; }

        public ClasseManutencao( int codClasseManutencao, string descClasseManutencao)
        {
            CodClasseManutencao = codClasseManutencao;
            DescClasseManutencao = descClasseManutencao;
        }
        public void AlterarCodigo(int codClasseManutencao)
        {
            CodClasseManutencao = codClasseManutencao;
        }
        public void AlterarDescricao(string descClasseManutencao)
        {
            DescClasseManutencao = descClasseManutencao;
        }
    }
}
