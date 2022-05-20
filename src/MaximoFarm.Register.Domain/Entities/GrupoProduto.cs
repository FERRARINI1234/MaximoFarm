using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class GrupoProduto
    {
        public int GrupoProdutoId { get;private set; }
        public int CodGrupoProduto { get; private set; }
        public string DescGrupoProduto { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Materiais> Materiais { get; set; }
        public ICollection<Insumos> Insumos { get; set; }
        public GrupoProduto( int codGrupoProduto, string descGrupoProduto, bool ativo)
        { 
            CodGrupoProduto=codGrupoProduto;
            DescGrupoProduto=descGrupoProduto;
            Ativo= ativo;
        }
        public void AlterarCodigo(int codGrupoProduto)
        {
            CodGrupoProduto = codGrupoProduto;
        }
        public void AlterarDescricao(string descGrupoProduto)
        {
            DescGrupoProduto = descGrupoProduto;
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
