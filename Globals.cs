using HeroesOE.Json;
using HOETool;
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
		public static string temp_path = System.IO.Path.GetTempPath() + @"HOETool\";
		
		public static DiffForm? diffForm = null;

		public static List<HeroJson.Token> hero_tokens = new List<HeroJson.Token>();
		public static HeroInfoJson.HeroInfos hero_infos = new HeroInfoJson.HeroInfos();
		public static HeroSkillsJson.HeroSkills hero_skills = new HeroSkillsJson.HeroSkills();

		public static int current_player = -1;
		public static int current_index = -1;
		public static List<List<string>> player_display = new();
		public static List<List<NumericOffset>> player_metadata = new();
		public static NumericOffset? current_no = null;
		public static string quicksave_path = "";
		public static DateTime quicksave_time = DateTime.UnixEpoch;

		public static byte[] quickbytes = [];
		public static JsonBracketMatcher? matcher = null;

		internal static void NextPlayerDisplay() { if (player_display.Count <= ++current_player) AddPlayerDisplay(); }
		public static int SelectLastPlayer() { current_player = player_display.Count - 1; return current_player; }

		internal static void RewindHeroDisplays() { current_player = -1; }
		public static void ResetHeroDisplays() { player_display.Clear(); player_metadata.Clear(); SelectLastPlayer(); }
		public static void AddPlayerDisplay() { player_display.Add(new()); player_metadata.Add(new()); SelectLastPlayer(); }
		public static void AddHeroDisplayLine(string line, NumericOffset meta = null)
		{
			if (current_player < 0 || current_player >= player_display.Count) throw new Exception("Invalid current_hero");
			Debug.WriteLine(line);
			player_display[current_player].Add(line);

			if (meta == null) meta = NumericOffset.Invalid;
			player_metadata[current_player].Add(meta);
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
