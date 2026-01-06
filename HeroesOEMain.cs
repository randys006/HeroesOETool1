using HeroesOE.Json;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text.Json;
using static HeroesOE.Json.HeroInfoJson;

namespace HeroesOE
{
    public partial class HeroesOEMain : Form
    {
		private List<HeroJson.Token> hero_tokens = new List<HeroJson.Token>();
		private HeroInfoJson.HeroInfos hero_infos = new HeroInfoJson.HeroInfos();
		private HeroSkillsJson.HeroSkills hero_skills = new HeroSkillsJson.HeroSkills();

		private CitiesJson.Cities cities = new CitiesJson.Cities();
		private City[] city_defs = new City[]{
			new City(new HumanCityJson()),
			new City(new DungeonCityJson()),
			new City(new UndeadCityJson()),
			new City(new UnfrozenCityJson())
		};
		private UndeadCityJson.UndeadCity undead_city = new UndeadCityJson.UndeadCity();

		public HeroesOEMain()
        {
            InitializeComponent();

			foreach (var hero_info_pair in hero_infos.hero_infos)
			{
				var hero_info = hero_info_pair.Value;

				// only operate on base tokens
				string path = HeroJson.Token.GetFactionHeroPath(hero_info.sid);
				if (string.IsNullOrEmpty(path)) continue;

				var token_file = File.ReadAllText(path);
				var hero_root = JsonSerializer.Deserialize<HeroJson.Rootobject>(token_file);
				var hero_token = hero_root.tokens[0];

				string skills = "";
				foreach (var skill in hero_token.startSkills)
				{
					skills += $";{hero_skills.GetSkillName(skill.sid, skill.skillLevel),36}";
				}

				Debug.WriteLine($"{hero_info.ascii_name,32};{hero_info.sid,18};{hero_token.classType}{skills}");
			}

			foreach (var city in city_defs)
			{
				//city.ParseHires();
			}
		}
	}
}
