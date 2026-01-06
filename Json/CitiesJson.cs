using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class CitiesJson
	{
		public class Cities
		{
			public Cities()
			{
				var tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.cities_json_path)).tokens;
				foreach (var token in tokens)
				{
					// TODO: load the city
					//Debug.WriteLine(token.sid);
				}
			}
		}
		public class Rootobject
		{
			public Token[] tokens { get; set; }
		}
		public class Token
		{
			public string sid { get; set; }
			public string text { get; set; }
		}
	}
}
