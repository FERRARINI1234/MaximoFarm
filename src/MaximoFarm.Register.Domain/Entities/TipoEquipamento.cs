using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class TipoEquipamento
    {
        public int TipoId { get;private set; }
        public int CodTipo { get; private set; }
        public string DescTipo { get; private set; }

        public ICollection<Equipamentos> Equipamentos { get; set; }

        public TipoEquipamento(int codTipo, string descTipo)
        {
            CodTipo = codTipo;
            DescTipo = descTipo;
        }
        public void AlterarCodigo(int codTipo)
        {
            CodTipo = codTipo;
        }
        public void AlterarDescricao(string descTipo)
        {
            DescTipo = descTipo;
        }
    }
}
