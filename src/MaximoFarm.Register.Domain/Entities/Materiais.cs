using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Materiais
    {
        public int MaterialId { get;private set; }
        public int CodMaterial { get;private set; }
        public string DescMaterial { get;private set; }

        public int CodMedida { get; set; }
        public Medidas Medidas { get; set; }

        public int CodGrupoProduto { get; set; }
        public GrupoProduto GrupoProduto { get; set; }

        public int CodEspacamento { get; set; }
        public Espacamento Espacamento { get; set; }

        public Materiais(int codMaterial, string descMaterial)
        {
            CodMaterial = codMaterial;
            DescMaterial = descMaterial;
        }
    }
}
