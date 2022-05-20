using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class ContaReceita
    {
        public int ContaReceitaId { get;private set; }
        public int CodContaReceita { get; private set; }
        public string DescContaReceita { get; private set; }
        public bool Ativo { get; private set; }

        public ContaReceita(int codContaReceita, string descContaReceita, bool ativo)
        {
            CodContaReceita = codContaReceita;
            DescContaReceita = descContaReceita;
            Ativo = ativo;
        }
        public void AlterarCodigo(int codContaReceita)
        {
            CodContaReceita = codContaReceita;
        }
        public void AlterarDescricao(string descContaReceita)
        {
            DescContaReceita = descContaReceita;
        }
        public void Ativar()=> Ativo = true;
        public void Desativar()=>Ativo = false;
    }
}
