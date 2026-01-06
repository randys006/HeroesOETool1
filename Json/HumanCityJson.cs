using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class HumanCityJson : CityJsonBase
	{
		public class HumanCity
		{
			public HumanCity()
			{
				tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.human_city_path)).tokens;

				foreach (var token in tokens)
				{
					// TODO: parse HumanCity
					Debug.WriteLine(token.id);
				}

			}

			public HumanToken[] tokens;
		}
	}
	public class Rootobject
	{
		[System.Text.Json.Serialization.JsonPropertyName("array")]
		public HumanToken[] tokens { get; set; }
	}

	public class HumanToken : CityTokenBase
	{
		public new Artifactmarket[] artifactMarkets { get; set; }
		public new Intelligence[] intelligences { get; set; }
		public new Trainingrange[] trainingRanges { get; set; }
	}
}

