using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class CidadeViewModel
    {
        [JsonPropertyName("_id")]
        public int CidadeId { get; private set; }

        [JsonPropertyName("codigo")]
        public int CodCidade { get; private set; }

        [JsonPropertyName("descricao")]
        public string DescCidade { get; private set; }

        [JsonPropertyName("cod_estado")]
        public int CodEstado { get; set; }
    }
}
