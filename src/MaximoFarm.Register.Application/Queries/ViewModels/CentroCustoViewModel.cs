using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class CentroCustoViewModel
    {
        [JsonPropertyName("_id")]
        public int CentroCustoId { get; set; }

        [JsonPropertyName("codigo")]
        public int CodCentroCusto { get; set; }

        [JsonPropertyName("descricao")]
        public string DescCentroCusto { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; private set; }
    }
}
