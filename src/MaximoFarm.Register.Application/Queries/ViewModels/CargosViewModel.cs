using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class CargosViewModel
    {
        [JsonPropertyName("_id")]
        public int CargoId { get; set; }

        [JsonPropertyName("codigo")]
        public int CodCargo { get; set; }

        [JsonPropertyName("descricao")]
        public string DescCargo { get; set; }
    }
}
