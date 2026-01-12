using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class JsonFilePaths
	{
		public static bool QuickJsonValidate(string json) { return !string.IsNullOrEmpty(json) && json[0] == '{' && json[json.Length - 1] == '}'; }

		private const string coredb_path = @"C:\Users\randy\source\HeroesOE\Core\DB\";
		private const string install_path = @"C:\Program Files (x86)\Steam\steamapps\common\Heroes of Might & Magic Olden Era Demo\HeroesOE_Data\StreamingAssets\Lang\english\";

		private const string cities_path = coredb_path + @"objects_logic\cities\";
		private const string texts_path = install_path + @"texts\";
		public const string units_logics_path = coredb_path + @"units\units_logics\";

		public const string hero_skills_path = texts_path + @"heroSkills.json";
		public const string heroes_skills_path = coredb_path + @"heroes_skills\skills\skills.json";
		public const string heroes_subskills_path = coredb_path + @"heroes_skills\sub_skills\sub_skills.json";

		public const string cities_json_path = texts_path + @"cities.json";
		public const string dungeon_city_path = cities_path + @"dungeon_city.json";
		public const string human_city_path = cities_path + @"human_city.json";
		public const string undead_city_path = cities_path + @"undead_city.json";
		public const string unfrozen_city_path = cities_path + @"unfrozen_city.json";

		public const string units_ability_path = texts_path + @"unitsAbility.json";
		public const string dungeon_units_path = units_logics_path + @"dungeon\";
		public const string human_units_path = units_logics_path + @"human\";
		public const string undead_units_path = units_logics_path + @"undead\";
		public const string unfrozen_units_path = units_logics_path + @"unfrozen\";
	}
}
