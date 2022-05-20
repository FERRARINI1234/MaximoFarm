using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class SafraViewModel
    {
        [JsonPropertyName("_id")]
        public int SafraId { get; private set; }

        [JsonPropertyName("codigo")]
        public int CodSafra { get; private set; }

        [JsonPropertyName("descricao")]
        public string DescSafra { get; private set; }

    }
}
