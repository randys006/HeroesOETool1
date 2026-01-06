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
	public class UndeadCityJson : CityJsonBase
	{
		public class UndeadCity
		{
			public UndeadCity()
			{
				tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.undead_city_path)).tokens;
				foreach (var token in tokens)
				{
					// TODO: parse undead city
					Debug.WriteLine(token.id);
				}

			}
			public UndeadToken[] tokens;
		}
		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public UndeadToken[] tokens { get; set; }
		}

		public class UndeadToken : CityTokenBase
		{
			public new Manafountain[] manaFountains { get; set; }
			public new Unitsconverter[] unitsConverters { get; set; }
		}
	}
}
