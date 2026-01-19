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
using static HeroesOE.Json.HeroInfoJson;
using static HeroesOE.JsonBracketMatcher;
using static HOETool.MapObjects;
using static HeroesOE.VGlobals;
using static HeroesOE.Json.SaveGameJson3;

namespace HeroesOE
{
	public static class Globals
	{
		public static Encoding encoding = Encoding.UTF8;
		public static bool adjust_pending = false;

		public static DiffForm? diffForm = null;
		public static MapProximityForm? mapProxForm = null;

		public static List<Json.HeroJson.Token> hero_tokens = new List<Json.HeroJson.Token>();
		public static HeroInfoJson.HeroInfos hero_infos = new HeroInfoJson.HeroInfos();
		public static HeroSkillsJson.HeroSkills hero_skills = new HeroSkillsJson.HeroSkills();
		public static UnitsLogicJson.UnitsLogic units_logics = new UnitsLogicJson.UnitsLogic();

		public static int current_side = -1;
		public static int current_index = -1;
		public static int unowned_player = 4;
		public static int current_hero = -1;
		public static HeroJsonEntry[] hero_list = null;
		public static List<List<string>> side_display = new();
		public static List<List<NumericOffset>> side_metadata = new();
		public static Dictionary<int, SquadInfo> squad_infos = new();

		public static List<MapProximityObject> squad_prox = new();

		public static List<List<HeroInfo>> current_hero_infos = new();
		public static List<List<string>> current_city_names = new();
		public static NumericOffset? current_no = null;

		public static string quicksave_path = "";
		public static DateTime quicksave_time = DateTime.UnixEpoch;

		public static byte[] quickbytes = [];
		public static byte[] sg3bytes = [];
		public static JsonBracketMatcher? matcher = null;

		public static List<SaveGameJson1.Object> map_city_objs = new();
		public static List<string> map_city_info = new();
		public static List<SaveGameJson3.Cityobj> game_city_obj = new();

		public static void AddHeroInfo(HeroInfo hero) { current_hero_infos[current_side].Add(hero); }
		public static void AddCityName(string city) { current_city_names[current_side].Add(city); }
		internal static void NextPlayerDisplay() { if (side_display.Count <= ++current_side) AddPlayerDisplay(); hero_display_indent = 0; }
		public static int SelectLastPlayer() { current_side = side_display.Count - 1; hero_display_indent = 0; return current_side; }

		internal static void RewindHeroDisplays() { current_side = -1; hero_display_indent = 0; }
		// By default, we create 5 players. 4 is max for the demo, plus 1 to store unowned cities etc.
		public static void ResetHeroDisplays() { side_display.Clear(); side_metadata.Clear(); current_hero_infos.Clear(); current_city_names.Clear(); SelectLastPlayer(); for (int i = 0; i < 5; ++i) AddPlayerDisplay(); current_side = -1; }
		public static void AddPlayerDisplay() { side_display.Add(new()); side_metadata.Add(new()); current_hero_infos.Add(new()); current_city_names.Add(new()); SelectLastPlayer(); }
		public static int hero_display_indent = 0;
		public static void AddHeroDisplayLine(string line = null, NumericOffset meta = null)
		{
			if (current_side < 0 || current_side >= side_display.Count) throw new Exception("Invalid current_hero");
			if (string.IsNullOrEmpty(line)) line = "-------------------------------------------";
			else { line = $"{new string(' ', hero_display_indent)}{line}"; }

			VSGHeroes(line);
			side_display[current_side].Add(line);

			if (meta == null) meta = NumericOffset.Invalid;
			side_metadata[current_side].Add(meta);
		}
		public static void AddCityDisplayLine(string line = null, NumericOffset meta = null)
		{
			if (current_side < 0 || current_side >= side_display.Count) throw new Exception("Invalid current_hero");
			if (string.IsNullOrEmpty(line)) line = "-------------------------------------------";
			else { line = $"{new string(' ', hero_display_indent)}{line}"; }

			VSGCity(line);
			side_display[current_side].Add(line);

			if (meta == null) meta = NumericOffset.Invalid;
			side_metadata[current_side].Add(meta);
		}

		/// <summary>
		/// default indent adds two spaces
		/// </summary>
		/// <param name="indent"></param>
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
