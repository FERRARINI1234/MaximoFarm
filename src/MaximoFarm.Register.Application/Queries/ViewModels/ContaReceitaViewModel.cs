using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class ContaReceitaViewModel
    {
        [JsonPropertyName("_id")]
        public int ContaReceitaId { get; private set; }

        [JsonPropertyName("codigo")]
        public int CodContaReceita { get; private set; }

        [JsonPropertyName("descricao")]
        public string DescContaReceita { get; private set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; private set; }
    }
}
