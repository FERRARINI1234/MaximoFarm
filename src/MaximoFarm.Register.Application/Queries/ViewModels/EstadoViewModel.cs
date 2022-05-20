using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class EstadoViewModel
    {
        [JsonPropertyName("_id")]
        public int EstadoId { get; private set; }

        [JsonPropertyName("codigo")]
        public int CodEstado { get; private set; }

        [JsonPropertyName("descricao")]
        public string DescEstado { get; private set; }

        [JsonPropertyName("descricao_abrevida")]
        public string DescAbrevEstado { get; private set; }
    }
}
