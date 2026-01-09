using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using static HeroesOE.JsonBracketMatcher;

namespace HeroesOE
{
	public static class Globals
	{
		public static Encoding encoding = Encoding.UTF8;
		public static string temp_path = System.IO.Path.GetTempPath() + @"\HOETool";

		public static List<HeroJson.Token> hero_tokens = new List<HeroJson.Token>();
		public static HeroInfoJson.HeroInfos hero_infos = new HeroInfoJson.HeroInfos();
		public static HeroSkillsJson.HeroSkills hero_skills = new HeroSkillsJson.HeroSkills();

		public static int current_hero = -1;
		public static List<List<string>> hero_display = new();
		public static List<List<NumericOffset>> hero_metadata = new();
		public static NumericOffset current_no = null;
		public static string quicksave_path = "";
		public static byte[] quickbytes = [];
		public static int SelectLastHero() { current_hero = hero_display.Count - 1; return current_hero; }
		public static void ResetHeroDisplays() { hero_display.Clear(); hero_metadata.Clear(); SelectLastHero(); }
		public static void AddHeroDisplay() { hero_display.Add(new()); hero_metadata.Add(new()); SelectLastHero(); }
		public static void AddHeroDisplayLine(string line, NumericOffset meta = null)
		{
			if (current_hero < 0 || current_hero >= hero_display.Count) throw new Exception("Invalid current_hero");
			Debug.WriteLine(line);
			hero_display[current_hero].Add(line);

			if (meta == null) meta = NumericOffset.Invalid;
			hero_metadata[current_hero].Add(meta);
		}
		public static string display_savegame_path = "";

		public static CitiesJson.Cities cities = new CitiesJson.Cities();
		public static City[] city_defs = new City[]{
			new City(new HumanCityJson()),
			new City(new DungeonCityJson()),
			new City(new UndeadCityJson()),
			new City(new UnfrozenCityJson())
		};
		public static UndeadCityJson.UndeadCity undead_city = new UndeadCityJson.UndeadCity();
	}
}
