using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class CicloViewModel
    {
        [JsonPropertyName("_id")]
        public int CicloId { get; set; }

        [JsonPropertyName("codigo")]
        public int CodCiclo { get; set; }

        [JsonPropertyName("descricao")]
        public string DescCiclo { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
