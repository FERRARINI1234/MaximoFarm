using MaximoFarm.Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MaximoFarm.Register.Application.Queries.ViewModels
{
	public class CadEstoqueViewModel
	{

        [JsonPropertyName("codigo")]
		public int CodCadEstoque { get; set; }

		[JsonPropertyName("descricao")]
		public string DescCadEstoque { get; set; }
	}
}
