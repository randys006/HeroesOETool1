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

		public class MultiStats
		{
			public List<int> offences = new();
			public List<int> defences = new();
			public List<int> spellPowers = new();
			public List<int> intelligences = new();
			public List<int> lucks = new();
			public List<int> morals = new();
			public void Accumulate(Stats stats)
			{
				offences.Add(stats.offence);
				defences.Add(stats.defence);
				spellPowers.Add(stats.spellPower);
				intelligences.Add(stats.intelligence);
				lucks.Add(stats.luck);
				morals.Add(stats.moral);
			}
			public void Accumulate(SaveGameJson3.Statsbylevel stats)
			{
				offences.Add(stats.offence);
				defences.Add(stats.defence);
				spellPowers.Add(stats.spellPower);
				intelligences.Add(stats.intelligence);
				lucks.Add(stats.luck);
				morals.Add(stats.moral);
			}
			public void Accumulate(SaveGameJson3.Additionalstats1 stats)
			{
				offences.Add(stats.offence);
				defences.Add(stats.defence);
				spellPowers.Add(stats.spellPower);
				intelligences.Add(stats.intelligence);
				lucks.Add(stats.luck);
				morals.Add(stats.moral);
			}
			public int offence { get { return offences.Sum(); } }
			public int defence {  get { return defences.Sum(); } }
			public int spellPower { get { return spellPowers.Sum(); } }
			public int intelligence { get { return intelligences.Sum(); } }
			public int luck { get { return lucks.Sum(); } }
			public int moral { get { return morals.Sum(); } }
			public string Print(List<int> list)
			{
				StringBuilder sb = new StringBuilder();
				sb.Append(list.Sum()).Append(" (");

				foreach (int i in list)
				{
					sb.Append(i).Append('+');
				}

				sb.Remove(sb.Length - 1, 1);
				sb.Append(")");

				return sb.ToString();
			}
			public string all_offences { get { return Print(offences); } }
			public string all_defences { get { return Print(defences); } }
			public string all_spellPowers { get { return Print(spellPowers); } }
			public string all_intelligences { get { return Print(intelligences); } }
			public string all_lucks { get { return Print(lucks); } }
			public string all_morals { get { return Print(morals); } }
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
