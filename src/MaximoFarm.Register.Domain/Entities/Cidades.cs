using System.Collections.Generic;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Cidades
    {
        public int CidadeId { get;private set; }
        public int CodCidade { get; private set; }
        public string DescCidade { get; private set; }

        public int CodEstado { get; set; }
        public Estados Estados { get; set; }

        public ICollection<Enderecos> Enderecos { get; set; }
        public ICollection<Propriedade> Propriedade { get; set; }

        public Cidades(int codCidade, string descCidade)
        {
            CodCidade = codCidade;
            DescCidade = descCidade;
        }
    }
}
