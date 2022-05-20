using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Enderecos
    {
        public int EnderecoId { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public int Numero { get; set; }
        public string Complemento { get; set; }
        public int Telefone { get; set; }
        public int TelefoneAux { get; set; }
        public string Email { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public int CodCidade { get; set; }
        public Cidades Cidades { get; set; }

        public ICollection<Fornecedores> Fornecedores { get; set; }
        public Enderecos()
        {
        }
    }
}
