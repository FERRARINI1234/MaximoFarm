using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class ContaDebito
    {
        public int ContaDebitoId { get;private set; }
        public int CodContaDebito { get; private set; }
        public string DescContaDebito { get; private set; }
        public bool Ativo { get; private set; }

        public ContaDebito( int codContaDebito, string descContaDebito, bool ativo)
        {
            CodContaDebito = codContaDebito;
            DescContaDebito = descContaDebito;
            Ativo = ativo;
        }
        public void AlterarCodigo(int codContaDebito)
        {
            CodContaDebito = codContaDebito;
        }
        public void AlterarDescricao(string descContaDebito)
        {
            DescContaDebito = descContaDebito;
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
