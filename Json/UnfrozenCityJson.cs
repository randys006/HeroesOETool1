using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class UnfrozenCityJson : CityJsonBase
	{
		public class UnfrozenCity
		{
			public UnfrozenCity()
			{
				tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.unfrozen_city_path)).tokens;
				foreach (var token in tokens)
				{
					// TODO: parse UnfrozenCity
					Debug.WriteLine(token.id);
				}
			}

			public UnfrozenToken[] tokens;
		}

		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public UnfrozenToken[] tokens { get; set; }
		}

		public class UnfrozenToken : CityTokenBase
		{
			public new Artifactmarket[] artifactMarkets { get; set; }
			public new Herobonusbank[] heroBonusBanks { get; set; }
			public new Portalsummoning[] portalSummonings { get; set; }
		}
	}
}
