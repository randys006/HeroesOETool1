using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class HeroesSkillsJson
	{

		public class Rootobject
		{
			[System.Text.Json.Serialization.JsonPropertyName("array")]
			public Token[] tokens { get; set; }
		}

		public class Token
		{
			public string id { get; set; }
			public string name { get; set; }
			public string desc { get; set; }
			public string skillType { get; set; }
			public Parametersperlevel[] parametersPerLevel { get; set; }
			public string icon { get; set; }
		}

		public class Parametersperlevel
		{
			public string icon { get; set; }
			public string name { get; set; }
			public string desc { get; set; }
			public Bonus[] bonuses { get; set; }
			public string[] subSkills { get; set; }
		}

		public class Bonus
		{
			public string type { get; set; }
			public string[] parameters { get; set; }
			public string[] receivers { get; set; }
			public string receiverAllegiance { get; set; }
		}

	}
}
