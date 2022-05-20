using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Cargos
    {
        public int CargoId { get;private set; }
        public int CodCargo { get; private set; }
        public string DescCargo { get; private set; }

        public Cargos( int codCargo, string descCargo)
        {
            
            CodCargo = codCargo;
            DescCargo = descCargo;
        }

        public void AlterarId(int cargoId)
        {
            CargoId = cargoId;
        }
        public void AlterarCodigo(int codCargo)
        {
            CodCargo = codCargo;
        }
        public void AlterarDescricao(string descCargo)
        {
            DescCargo = descCargo;
        }
    }
}
