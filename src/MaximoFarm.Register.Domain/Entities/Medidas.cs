using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Medidas
    {
        public int MedidaId { get;private set; }
        public int CodMedida { get; private set; }
        public string DescAbrevMedida { get; private set; }
        public string DescMedida { get; private set; }

        //EF Relations
        public ICollection<Modelos> Modelos { get; set; }
        public ICollection<Variedades> Variedades { get; set; }
        public ICollection<Insumos> Insumos { get; set; }
        public ICollection<Materiais> Materiais { get; set; }

        public Medidas(int codMedida, string descAbrevMedida, string descMedida)
        {
            CodMedida = codMedida;
            DescAbrevMedida = descAbrevMedida;
            DescMedida= descMedida;
        }
        public void AlterarCodigo(int codMedida)
        {
            CodMedida = codMedida;
        }
        public void AltearDescricao(string descAbrevMedida)
        {
            DescAbrevMedida = descAbrevMedida;
        }
    }
}
