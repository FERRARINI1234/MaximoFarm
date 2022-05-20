using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class ContaDebitoViewModel
    {
        [JsonPropertyName("_id")]
        public int ContaDebitoId { get;  set; }

        [JsonPropertyName("codigo")]
        public int CodContaDebito { get;  set; }

        [JsonPropertyName("descricao")]
        public string DescContaDebito { get;  set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get;  set; }
    }
}
