using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class GrupoEquipamento
    {
        public int GrupoEquipamentoId { get; private set; }
        public int CodGrupoEquipamento { get; private set; }
        public string DescGrupoEquipamento { get; private set; }
        public bool Ativo { get; private set; }

        public ICollection<Equipamentos> Equipamentos { get; set; }
        public GrupoEquipamento( int codGrupoEquipamento, string descGrupoEquipamento, bool ativo)
        {
            CodGrupoEquipamento = codGrupoEquipamento;
            DescGrupoEquipamento = descGrupoEquipamento;
            Ativo = ativo;
        }
        public void AlterarCodigo(int codGrupoEquipamento)
        {
            CodGrupoEquipamento = codGrupoEquipamento;
        }
        public void AlterarDescricao(string descGrupoEquipamento)
        {
            DescGrupoEquipamento = descGrupoEquipamento;
        }
        public void Ativar() => Ativo = true;
        public void Desativar() => Ativo = false;
    }
}
