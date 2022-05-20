
using MaximoFarm.Register.Domain.DomainObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Domain.Entities
{
    public class Safra
    {
        public int SafraId { get; private set; }
        public int CodSafra { get; private set; }
        public string DescSafra { get; private set; }

        public Safra( int codSafra, string descSafra)
        {
            CodSafra = codSafra;
            DescSafra = descSafra;
        }
        public void AlterarId(int safraId)
        {
            SafraId = safraId;
        }
        public void AlterarCodigo(int codSafra)
        {
            CodSafra = codSafra;
        }
        public void AlterarDescricao(string descSafra)
        {
            DescSafra = descSafra;
        }
    }
}
