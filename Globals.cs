using HeroesOE.Json;
using HOETool;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Contracts;
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
		public static int unowned_player = 4;
		public static List<List<string>> player_display = new();
		public static List<List<NumericOffset>> player_metadata = new();
		public static NumericOffset? current_no = null;

		public static string quicksave_path = "";
		public static DateTime quicksave_time = DateTime.UnixEpoch;

		public static byte[] quickbytes = [];
		public static JsonBracketMatcher? matcher = null;

		public static List<SaveGameJson1.Object> map_city_objs = new();
		public static List<string> map_city_info = new();
		public static List<SaveGameJson3.Cityobj> game_city_obj = new();

		internal static void NextPlayerDisplay() { if (player_display.Count <= ++current_player) AddPlayerDisplay(); hero_display_indent = 0; }
		public static int SelectLastPlayer() { current_player = player_display.Count - 1; hero_display_indent = 0; return current_player; }

		internal static void RewindHeroDisplays() { current_player = -1; hero_display_indent = 0; }
		// By default, we create 5 players. 4 is max for the demo, plus 1 to store unowned cities etc.
		public static void ResetHeroDisplays() { player_display.Clear(); player_metadata.Clear(); SelectLastPlayer(); for (int i = 0; i < 5; ++i) AddPlayerDisplay(); current_player = -1; }
		public static void AddPlayerDisplay() { player_display.Add(new()); player_metadata.Add(new()); SelectLastPlayer(); }
		public static int hero_display_indent = 0;
		public static void AddHeroDisplayLine(string line = null, NumericOffset meta = null)
		{
			if (current_player < 0 || current_player >= player_display.Count) throw new Exception("Invalid current_hero");
			if (string.IsNullOrEmpty(line)) line = "-------------------------------------------";
			else { line = $"{new string(' ', hero_display_indent)}{line}"; }

			Debug.WriteLine(line);
			player_display[current_player].Add(line);

			if (meta == null) meta = NumericOffset.Invalid;
			player_metadata[current_player].Add(meta);
		}
		public static void IndentHeroDisplay(int indent = -1)
		{
			if (indent < 0) hero_display_indent += 2;
			else hero_display_indent = indent;
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
