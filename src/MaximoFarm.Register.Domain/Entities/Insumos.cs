using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Insumos
    {
        public int InsumoId { get;private set; }
        public int CodInsumo { get; private set; }
        public string DescInsumo { get; private set; }

        //EF Relations
        public int CodFornecedor { get; private set; }
        public Fornecedores Fornecedores { get; private set; }

        public int CodMarca { get; private set; }
        public Marcas Marcas { get; private set; }

        public int CodMedida { get; private set; }
        public Medidas Medidas { get; private set; }

        public int CodGrupoProduto { get; private set; }
        public GrupoProduto GrupoProduto { get; private set; }

        public Insumos(int codInsumo, string descInsumo)
        {
            CodInsumo = codInsumo;
            DescInsumo = descInsumo;
        }
    }
}
