using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Variedades
    {
        public int VariedadeId { get; set; }
        public int CodVariedade { get; set; }
        public string DescVariedade { get; set; }
        public string DescAbrevVariedade { get; set; }

        //EF Relations

        public int CodMedida { get; set; }
        public Medidas Medidas { get; set; }

        public int CodFornecedor { get; set; }
        public Fornecedores Fornecedores { get; set; }

        public int CodCiclo { get; set; }
        public Ciclo Ciclo { get; set; }

        public int CodEspacamento { get; set; }
        public Espacamento Espacamento { get; set; }

        public Variedades()
        {

        }
    }
}
