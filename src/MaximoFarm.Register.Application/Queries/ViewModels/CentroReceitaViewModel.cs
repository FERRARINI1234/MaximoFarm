using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class CentroReceitaViewModel
    {
        [JsonPropertyName("_id")]
        public int CentroReceitaId { get; set; }

        [JsonPropertyName("codigo")]
        public int CodCentroReceita { get; set; }

        [JsonPropertyName("descricao")]
        public string DescCentroReceita { get; set; }

        [JsonPropertyName("ativo")]
        public bool Ativo { get; set; }
    }
}
