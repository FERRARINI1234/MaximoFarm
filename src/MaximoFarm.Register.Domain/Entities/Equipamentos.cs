using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Equipamentos
    {
        public int CodEquipamento { get; private set; }
        public int AnoFabricacao { get; private set; }
        public string Placa { get; private set; }
        public string Chassi { get; private set; }
        public int Renavan { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public DateTime DataAquisicao { get; private set; }
        public bool Ativo { get; private set; }

        //EF Relations       

        public int CodTipoEquipamento { get; set; }
        public TipoEquipamento TipoEquipamento { get; set; }

        public int CodFornecedor { get; set; }
        public Fornecedores Fornecedores { get; set; }

        public int CodCentroCusto { get; set; }
        public CentroCusto CentroCusto { get; set; }

        public int CodGrupoEquipamento { get; set; }
        public GrupoEquipamento GrupoEquipamento { get; set; }

        public int CodModelo { get; set; }
        public Modelos Modelos { get; set; }

        public Equipamentos()
        {
        }
    }
}

