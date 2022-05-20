using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Fornecedores
    {
        public int FornecedorId { get; private set; }
        public int CodFornecedor { get; private set; }
        public string DescFornecedor { get; private set; }
        public int TipoPessoa { get; private set; } //criar ENUM

        //EF Relations
        public int EnderecoId { get; private set; }
        public Enderecos Enderecos { get; private set; }
        public ICollection<Variedades> Variedades { get; set; }
        public ICollection<Equipamentos> Equipamentos { get; set; }
        public ICollection<Propriedade> Propriedades { get; set; }
        public ICollection<Insumos> Insumos { get; set; }

        public Fornecedores(int codFornecedor, string descFornecedor, int tipoPessoa)
        {
            CodFornecedor = codFornecedor;
            DescFornecedor = descFornecedor;
            TipoPessoa = tipoPessoa;
        }
    }
}
