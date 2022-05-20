using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Modelos
    {
        public int ModeloId { get;private set; }
        public int CodModelo { get;private set; }
        public string DescModelo { get;private set; }

        public int CodMarca { get; set; }
        public Marcas Marcas { get; set; }

        public int CodMedida { get; set; }
        public Medidas Medidas { get; set; }

        public ICollection<Equipamentos> Equipamentos { get; set; }

        public Modelos(int codModelo, string descModelo)
        {
            CodModelo = codModelo;
            DescModelo = descModelo;
        }
    }
}
