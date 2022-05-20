using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Estados
    {
        public int EstadoId { get; private set; }
        public int CodEstado { get; private set; }
        public string DescEstado { get; private set; }
        public string DescAbrevEstado { get; private set; }

        public ICollection<Cidades> Cidades { get; set; }

        public Estados(int codEstado, string descEstado, string descAbrevEstado)
        {
            CodEstado = codEstado;
            DescEstado = descEstado;
            DescAbrevEstado = descAbrevEstado;
        }

        public void AlterarCodigo(int codEstado)
        {
            CodEstado = codEstado;
        }

        public void AlterarDescricao(string descEstado)
        {
            DescEstado = descEstado;
        }

        public void AlterarAbreviacao(string descAbrevEstado)
        {
            DescAbrevEstado = descAbrevEstado;
        }
    }
}
