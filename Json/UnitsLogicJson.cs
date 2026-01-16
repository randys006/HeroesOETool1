using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static HeroesOE.Utilities;

namespace HeroesOE.Json
{
	// TODO: generalize UnitsLogic to all units and simplify
	// C:\Users\randy\source\HeroesOE\Core\DB\units\units_logics\undead\skeleton_upg_alt_l.json
	public class UnitsLogicJson
	{
		public class UnitsLogic
		{
			public Dictionary<string, UnitsLogic> units_logics;
			public UnitsLogic()
			{
				// TODO: refactor UnitsLogic so it can fill itself
				units_logics = new Dictionary<string, UnitsLogic>();
			}
			public UnitsLogic(string sid, Unitshire? units_hire = null)
			{
				var unit_logic_path = GetUnitLogicPath(sid);

				if (string.IsNullOrWhiteSpace(unit_logic_path)) { throw new Exception(@"could not find path for unit '{sid}'"); }

				tok = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(unit_logic_path)).tokens[0];
				this.units_hire = units_hire;
				this.unit_name = units_ability.units[sid + "_name"];
			}
			public static string GetUnitLogicPath(string sid)
			{
				string[] units_factions =
				{
					@"demons\",
					@"dungeon\",
					@"humans\",
					@"nature\",
					@"neutral\",
					@"undead\",
					@"unfrozen\"
				};

				string logic_name = sid + "_l.json";
				string logic_path = "";

				foreach (var fac in units_factions)
				{
					string path = JsonFilePaths.units_logics_path + fac + logic_name;
					if (File.Exists(path))
					{
						logic_path = path;
						break;
					}
				}

				return logic_path;
			}

			public UnitLogicsToken tok;
			public Unitshire? units_hire;
			public string unit_name;
			public static UnitsAbilityJson.UnitsAbility units_ability = new UnitsAbilityJson.UnitsAbility();

			public string GetStatsCsv(int weekly)
			{
				CsvBuilder csv = new CsvBuilder();
				var st = tok.stats;
				csv.App(GetGold())
					.App(weekly)
					.App(GetGems())
					.App(GetCrystals())
					.App(GetMercury())
					.App(st.hp)
					.App(st.damageMin)
					.App(st.damageMax)
					.App(st.offence)
					.App(st.defence)
					.App(st.luck)
					.App(st.moral)
					.App(st.speed)
					.App(st.initiative)
					;

				return csv.String();
			}

			public int GetCost(string tag)
			{
				int cost = int.MinValue;
				Costresarray[] cost_array = tok.unitCost.costResArray;
				foreach (Costresarray json in cost_array)
				{
					if (json.name == tag)
					{
						cost = json.cost;
						break;
					}
				}

				return cost;
			}

			public int GetCost0(string tag)
			{
				int cost = GetCost(tag);

				if (cost == int.MaxValue) cost = 0;

				return cost;
			}

			public int GetGold() { return GetCost("gold"); }
			public int GetMercury() { return GetCost("mercury"); }
			public int GetCrystals() { return GetCost("crystals"); }
			public int GetGems() { return GetCost("gemstones"); }

		}
		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public UnitLogicsToken[] tokens { get; set; }
		}
		public class UnitLogicsToken
		{
			public string id { get; set; }
			public int squadValue { get; set; }
			public int expBonus { get; set; }
			public int tier { get; set; }
			public string fraction { get; set; }
			public string nativeBiome { get; set; }
			public string ai { get; set; }
			public string[] tags { get; set; }
			public string baseSid { get; set; }
			public Unitcost unitCost { get; set; }
			public Stats stats { get; set; }
			public Passive[] passives { get; set; }
			public Defaultattack[] defaultAttacks { get; set; }
			public Alternativeattack[] alternativeAttacks { get; set; }
			public Counterattack[] counterAttacks { get; set; }
			public object[] abilities { get; set; }
			public string unit_name { get; set; }
		}

		public class Unitcost
		{
			public Costresarray[] costResArray { get; set; }
		}

		public class Costresarray
		{
			public string name { get; set; }
			public int cost { get; set; }
		}

		public class Stats
		{
			public int hp { get; set; }
			public int offence { get; set; }
			public int defence { get; set; }
			public int damageMin { get; set; }
			public int damageMax { get; set; }
			public int initiative { get; set; }
			public int speed { get; set; }
			public int luck { get; set; }
			public int moral { get; set; }
			public int energyPerCast { get; set; }
			public int energyPerRound { get; set; }
			public int energyPerTakeDamage { get; set; }
			public int actionPoints { get; set; }
			public int numCounters { get; set; }
			public int moralMin { get; set; }
			public int moralMax { get; set; }
			public int luckMin { get; set; }
			public int luckMax { get; set; }
			public Indmgmods inDmgMods { get; set; }
			public Outdmgmods outDmgMods { get; set; }
		}

		public class Indmgmods
		{
			public object[] list { get; set; }
		}

		public class Outdmgmods
		{
			public object[] list { get; set; }
		}

		public class Passive
		{
			public Data data { get; set; }
		}

		public class Data
		{
			public Immunity[] immunities { get; set; }
			public Disabler[] disablers { get; set; }
		}

		public class Immunity
		{
			public string type { get; set; }
			public string[] tags { get; set; }
		}

		public class Disabler
		{
			public string mech { get; set; }
		}

		public class Defaultattack
		{
			public string attackType_ { get; set; }
			public object[] selfMechanics { get; set; }
			public Damagedealer damageDealer { get; set; }
		}

		public class Damagedealer
		{
			public int shootRange { get; set; }
			public int shootThreshold { get; set; }
			public int shootRedCount { get; set; }
			public float shootDmgBuff { get; set; }
			public string[] tags { get; set; }
			public string attackPatternSid { get; set; }
			public Casttargetparams castTargetParams { get; set; }
			public Affecttargetparams affectTargetParams { get; set; }
			public string damageTarget_ { get; set; }
			public string damageType_ { get; set; }
			public float statDmgMult { get; set; }
			public object[] targetMechanics { get; set; }
		}

		public class Casttargetparams
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

		public class Affecttargetparams
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

		public class Alternativeattack
		{
			public string attackType_ { get; set; }
			public object[] selfMechanics { get; set; }
			public Damagedealer1 damageDealer { get; set; }
		}

		public class Damagedealer1
		{
			public string[] tags { get; set; }
			public string attackPatternSid { get; set; }
			public Casttargetparams1 castTargetParams { get; set; }
			public Affecttargetparams1 affectTargetParams { get; set; }
			public string damageTarget_ { get; set; }
			public string damageType_ { get; set; }
			public float statDmgMult { get; set; }
			public object[] targetMechanics { get; set; }
		}

		public class Casttargetparams1
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

		public class Affecttargetparams1
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

		public class Counterattack
		{
			public string attackType_ { get; set; }
			public object[] selfMechanics { get; set; }
			public Damagedealer2 damageDealer { get; set; }
		}

		public class Damagedealer2
		{
			public string[] tags { get; set; }
			public bool triggerCounter { get; set; }
			public string attackPatternSid { get; set; }
			public Casttargetparams2 castTargetParams { get; set; }
			public Affecttargetparams2 affectTargetParams { get; set; }
			public string damageTarget_ { get; set; }
			public string damageType_ { get; set; }
			public float statDmgMult { get; set; }
			public object[] targetMechanics { get; set; }
		}

		public class Casttargetparams2
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

		public class Affecttargetparams2
		{
			public string[] targetTags { get; set; }
			public string castTarget_ { get; set; }
			public string targetCondition_ { get; set; }
			public string selection { get; set; }
		}

	}
}
