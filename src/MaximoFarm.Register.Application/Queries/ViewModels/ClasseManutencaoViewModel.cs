using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
    public class ClasseManutencaoViewModel
    {
        [JsonPropertyName("_id")]
        public int ClasseManutencaoId { get;  set; }

        [JsonPropertyName("codigo")]
        public int CodClasseManutencao { get;  set; }

        [JsonPropertyName("descricao")]
        public string DescClasseManutencao { get;  set; }
    }
}
