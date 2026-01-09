using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class HeroSkillsJson
	{
		public class HeroSkills
		{
			public Dictionary<string, string> skill_names = new Dictionary<string, string>();
			public HeroSkills()
			{
				var tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(JsonFilePaths.hero_skills_path)).tokens;
				foreach (var token in tokens)
				{
					skill_names[token.sid] = token.text;
				}

				Debug.WriteLine($"{skill_names.Count} skill names read");
			}

			public string GetSkillName(string sid, int level)
			{
				string skill = $"{sid}_name_{level}";
				return $"{skill_names[skill]}";
			}

			public static string GetClassNameFaction(string class_type, string faction)
			{
				string class_name = "";

				foreach (var name in Factions.factions2)
				{
					if (name.Contains(faction))
					{
						class_name = name;
						break;
					}
				}

				if (string.IsNullOrEmpty(class_name))
					throw new Exception("Invalid faction name given");

				class_name = $"{class_type}_{class_name}_name";
				return class_name;
			}

			public static string[] GetClassSidsAllFactions()
			{
				List<string> class_names = new();

				foreach (var type in HeroJson.class_types)
				{
					foreach (var faction in Factions.factions2)
					{
						class_names.Add(GetClassNameFaction(type, faction));
					}
				}

				return class_names.ToArray();
			}

			public static string[] GetClassesAllFactions()
			{
				List<string> classes = new();
				var sids = GetClassSidsAllFactions();

				foreach(var sid in sids)
				{
					classes.Add(Globals.hero_skills.skill_names[sid]);
				}

				return classes.ToArray();
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
