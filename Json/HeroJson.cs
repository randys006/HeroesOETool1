using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class HeroJson
	{
		private const string heroes_path = @"C:\Users\randy\source\HeroesOE\Core\DB\heroes\";

		public static string[] class_types = ["might", "magic"];

		// Factions:
		// human -> humans
		// necro -> necros
		// unfrozen -> unfrozen
		// nature -> ???
		// demon -> ???
		// dungeon -> dungeon
		// cam -> (campaign, ignore)
		private static readonly Dictionary<string, string> heroSid_to_folder = new Dictionary<string, string>
		{
			{ "hum", "humans\\"},
			{ "nec", "necros\\"},
			{ "unf", "unfrozen\\"},
			{ "nat", "" },
			{ "dem", "" },
			{ "dun", "dungeon\\"},
			{ "cam", "" }
		};

		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public Token[] tokens { get; set; }
		}

		public class Token
		{
			public static string GetFactionHeroPath(string _id)
			{
				if (_id.Count(c => c == '_') > 2) return "";
				var folder = heroSid_to_folder[_id.Substring(0, 3)];
				if (string.IsNullOrEmpty(folder)) return "";

				string path = heroes_path + folder + _id + ".json";
				return path;
			}

			public string id { get; set; }
			public string mesh { get; set; }
			public string[] mounts { get; set; }
			public string icon { get; set; }
			public string fraction { get; set; }
			public string nativeBiome { get; set; }
			public string classType { get; set; }
			public string skillsRollVariant { get; set; }
			public int costGold { get; set; }
			public int startLevel { get; set; }
			public float[] attacksTimesBefore { get; set; }
			public Startsquad[] startSquad { get; set; }
			public Startsquadalt[] startSquadAlt { get; set; }
			public string specialization { get; set; }
			public Stats stats { get; set; }
			public Statsroll[] statsRolls { get; set; }
			public Startskill[] startSkills { get; set; }
			public object[] startMagics { get; set; }
		}

		public class Stats
		{
			public int viewRadius { get; set; }
			public int statsNum { get; set; }
			public int magicCastsPerRound { get; set; }
			public bool enableTactics { get; set; }
			public bool enableHeroNativeBiome { get; set; }
			public int offence { get; set; }
			public int defence { get; set; }
			public int spellPower { get; set; }
			public int intelligence { get; set; }
			public int luck { get; set; }
			public int moral { get; set; }
		}

		public class Startsquad
		{
			public string sid { get; set; }
			public int min { get; set; }
			public int max { get; set; }
		}

		public class Startsquadalt
		{
			public string sid { get; set; }
			public int min { get; set; }
			public int max { get; set; }
		}

		public class Statsroll
		{
			public int levelFrom { get; set; }
			public Rollchance[] rollChances { get; set; }
		}

		public class Rollchance
		{
			public int v { get; set; }
			public int c { get; set; }
		}

		public class Startskill
		{
			public string sid { get; set; }
			public int skillLevel { get; set; }
		}

	}
}
