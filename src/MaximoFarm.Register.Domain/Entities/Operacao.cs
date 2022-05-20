using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Operacao
    {
        public int OperacaoId { get;private set; }
        public int CodOperacao { get; private set; }
        public string DescAbrevOperacao { get; private set; }
        public string DescOperacao { get; private set; }

        public Operacao(int codOperacao, string descAbrevOperacao, string descOperacao)
        {
            CodOperacao= codOperacao;
            DescAbrevOperacao= descAbrevOperacao;
            DescOperacao= descOperacao;
        }
        public void AlterarCodigo(int codOperacao)
        {
            CodOperacao = codOperacao;
        }
        public void AlterarDescricaoAbreviada(string descAbrevOperacao)
        {
            DescAbrevOperacao = descAbrevOperacao;
        }
        public void AlterarDescricao(string descOperacao)
        {
            DescOperacao = descOperacao;
        }
    }
}
