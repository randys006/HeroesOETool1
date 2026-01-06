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
