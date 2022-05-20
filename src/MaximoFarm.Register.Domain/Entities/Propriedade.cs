using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Propriedade
    {
        public int CodPropriedade { get; set; }
        public string DescPropriedade { get; set; }
        public Decimal QuantidadeAreaTotal { get; set; }
        public int Incra { get; set; }
        public int Cadpro { get; set; }
        public int Ccir { get; set; }
        public int CodFornecedor { get; set; }
        public Fornecedores Fornecedores { get; set; }
        public int CodCidade { get; set; }
        public Cidades Cidades { get; set; }
        public ICollection< PropriedadeItem> PropriedadeItem { get; set; }

        public Propriedade()
        {

        }
    }
}
