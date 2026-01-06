using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static HeroesOE.Json.UnitsLogicJson;

namespace HeroesOE.Json
{
	public class UnitsAbilityJson
	{
		public class UnitsAbility
		{
			public UnitsAbility()
			{
				var tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.units_ability_path)).tokens;
				foreach (var token in tokens)
				{
					//// used to have Dictionary<string, UnitsLogic> units = new Dictionary<string, UnitsLogic>();
					//var unit_logic = new UnitsLogic(token.sid);
					//if (unit_logic != null)
					//{
					//	units[token.sid] = unit_logic;
					//}

					units[token.sid] = token.text;
				}

				Debug.WriteLine($"{units.Count} Unit names/abilities read");
			}

			public Dictionary<string, string> units = new Dictionary<string, string>();
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
