using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Espacamento
    {
        public int EspacamentoId { get; private set; }
        public int CodEspacamento { get; private set; }
        public string DescEspacamento { get; private set; }

        public ICollection<Variedades> Variedades { get; set; }
        public ICollection<Materiais> Materiais { get; set; }

        public Espacamento(int codEspacamento, string descEspacamento)
        {
            CodEspacamento = codEspacamento;
            DescEspacamento = descEspacamento;
        }
        public void AlterarCodigo(int codEspacamento)
        {
            CodEspacamento = codEspacamento;
        }
        public void AlterarDescricao(string descEspacamento)
        {
            DescEspacamento = descEspacamento;
        }
    }
}
