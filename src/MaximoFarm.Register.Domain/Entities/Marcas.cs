using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Marcas
    {
        public int MarcaId { get;private set; }
        public int CodMarca { get; private set; }
        public string DescMarca { get; private set; }

        public ICollection<Modelos> Modelos { get; set; }
        public ICollection<Insumos> Insumos { get; set; }
        public Marcas(int codMarca, string descMarca)
        {
            CodMarca = codMarca;
            DescMarca = descMarca;
        }
        public void AlterarCodigo(int codMarca)
        {
            CodMarca = codMarca;
        }
        public void AlterarDescricao(string descMarca)
        {
            DescMarca = descMarca;
        }
    }
}
