using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class DungeonCityJson : CityJsonBase
	{
		public class DungeonCity
		{
			public DungeonCity()
			{
				tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.dungeon_city_path)).tokens;
				foreach (var token in tokens)
				{
					// TODO: parse DungeonCity
					Debug.WriteLine(token.id);
				}
			}

			public DungeonToken[] tokens;
		}
		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public DungeonToken[] tokens { get; set; }
		}

		public class DungeonToken : CityTokenBase
		{

			public new Artifactmarket[] artifactMarkets { get; set; }
			public new Herobonusbank[] heroBonusBanks { get; set; }
			public new Artifactchanger[] artifactChangers { get; set; }
		}
	}
}