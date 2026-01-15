using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static HeroesOE.Globals;

namespace HeroesOE.Json
{
	public class HeroInfoJson
	{
		private const string heroInfo_path = @"C:\Program Files (x86)\Steam\steamapps\common\Heroes of Might & Magic Olden Era Demo\HeroesOE_Data\StreamingAssets\Lang\english\texts\heroInfo.json";

		public class HeroInfos
		{
			// maps an sid such as 'necro_hero_4' to their name 'Kel'Ghul'+data, stats etc.
			public Dictionary<string, HeroInfo> hero_infos = new Dictionary<string, HeroInfo>();

			public HeroInfos()
			{
				var tokens = JsonSerializer.Deserialize<Rootobject>(File.ReadAllText(heroInfo_path)).tokens;

				HeroInfo hero_info = new HeroInfo(tokens[0]);

				// this relies on order: 'spec_description' must be last
				foreach (var token in tokens)
				{
					var tag = token.GetTag();
					if (string.IsNullOrEmpty(tag))
					{
						hero_info = new HeroInfo(token);
					}
					else if (tag == "motto")
					{
						hero_info.motto = token.text;
					}
					else if (tag == "description")
					{
						hero_info.description = token.text;
					}
					else if (tag == "spec_name")
					{
						hero_info.spec_name = token.text;
					}
					else if (tag == "spec_description")
					{
						hero_info.spec_description = token.text;
						hero_infos[hero_info.sid] = hero_info;
					}
				}

				VHeroes($"{hero_infos.Count} heroInfos read");
			}
		}

		public class HeroInfo
		{
			public HeroInfo(Token token)
			{
				sid = token.sid;
				faction = token.GetFaction();
				name = token.text;
				ascii_name = Utilities.ToAscii(token.text);
			}

			public string sid;
			public string faction;
			public string name;
			public string motto;
			public string description;
			public string spec_name;
			public string spec_description;
			public string ascii_name;
			public int ingame_index;    // the hero's index in the currently-loaded savegame
			public JsonBracketMatcher.NumericOffset no;

			public HeroJson.Token? token;
		}

		public class Rootobject
		{
			public Token[] tokens { get; set; }
			// base token is: <faction>_hero_<id>
			// tokens for each hero are:	<base>
			//								<base>_motto
			//								<base>_description
			//								<base>_spec_name
			//								<base>_spec_description
		}

		public class Token
		{
			public string GetFaction()
			{
				return sid.Substring(0, sid.IndexOf('_'));
			}

			public string GetTag()
			{
				var tag_index = 0;

				try
				{
					tag_index = sid
						.Select((c, i) => new { Character = c, Index = i }) // Project characters with their indices
						.Where(x => x.Character == '_')             // Filter for the target character
						.ElementAtOrDefault(2).Index;             // Get the Nth (occurrence - 1 due to 0-based indexing) match
				}
				catch
				{
					return "";
				}

				return sid.Substring(tag_index + 1);
			}

			public string sid { get; set; }
			public string text { get; set; }
		}
	}
}
