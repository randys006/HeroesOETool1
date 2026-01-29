#define CHECK_TESTSAVEGAME

using HeroesOE.Json;
using HOETool;
using HOETool.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.Globals;
using static HeroesOE.Json.SaveGameJson3;
using static HeroesOE.JsonBracketMatcher;
using static HeroesOE.SaveGamePlayersJson;
using static HeroesOE.VGlobals;
using static HOETool.MapObjects;

namespace HeroesOE
{
	public class Testing
	{
		public static void InfoTest(string suite, string topic, string info)
		{
			VTest($"[INFO]: {suite,32}:{topic,40}:{info}");
		}
		public static bool TestSaveGame(bool save_tags = false)
		{
#if CHECK_TESTSAVEGAME
			try
			{
#endif
				Stopwatch sw = Stopwatch.StartNew();
				var save_game = SaveGame.GetMostRecentSaveGameName();
				InfoTest("TestSaveGame", @"GetCurrentSaveGameName", save_game);
				InfoTest("TestSaveGame", @"GetCurrentGameName", SaveGame.GetCurrentGameName(save_game));

				var quick = SaveGame.LoadCurrentQuicksave();
				InfoTest("TestSaveGame", @"Quicksave Bytes", $"{quick.Length}");
				VPerf($"Perf: Load quicksave time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
				if (quick == null || quick.Length == 0) { return false; }

				matcher = new JsonBracketMatcher(quick);
				VPerf($"Perf: Bktmatcher time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

				if (save_tags)
				{
					matcher.Print(100);
				}

				List<OrderedDictionary<int, JsonBracketMatcher.NumericOffset>> side_heroes = new();

				if (matcher.Valid)
				{
					quickbytes = quick;
					ParseQuickSave(quick, side_heroes);
					VPerf($"ParseQuickSave time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
				}
#if CHECK_TESTSAVEGAME
			}
			catch (Exception e)
			{

				int i = 42;
				return false;
			}   // ignore errors
#endif
			return true;
		}

		private static void ParseQuickSave(byte[] quick, List<OrderedDictionary<int, JsonBracketMatcher.NumericOffset>> side_heroes)
		{
			Stopwatch sw = Stopwatch.StartNew();

			var sg1 = new SaveGameJson1.SaveGame(matcher.GetTopLevelJson(quick, 1));
			VPerf($"Perf:       SG1 time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
			var sg3 = new SaveGameJson3.SaveGame(matcher.GetTopLevelJson(quick, 3));
			VPerf($"Perf:       SG3 time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			hero_list = sg3.sg.heroes.list;
			var game_objs = sg3.sg.objects;
			var map_objs = sg1.sg.objects;
			var squads = sg3.sg.squads;

			ResetHeroDisplays();
			sg3_json = null;

			// Add player basic info, resources etc.
			foreach (var player in sg3.sg.sides.players)
			{
				NextPlayerDisplay();
				var res = player.res;

				VSGSides($"sg3: Player {player.index}: {player.name}:");
				VSGSides($"     RES: {res.gold.value,7} {res.wood.value,4} {res.ore.value,4} {res.gemstones.value,4} {res.crystals.value,4} {res.mercury.value,4} {res.dust.value,4}");

				string player_meta = $"top_level_3.sides.array[].{player.index}.";
				string res_meta = player_meta + "res.";

				// misc player stats
				var currentLawsPoints = matcher.FindNumericOffset(quick, player_meta + "currentLawsPoints");
				AddHeroDisplayLine($"currentLawsPoints {player.currentLawsPoints}", currentLawsPoints);

				// resource stats
				var gold = matcher.FindNumericOffset(quick, res_meta + "gold.value");
				AddHeroDisplayLine($"gold {res.gold.value}", gold);

				var wood = matcher.FindNumericOffset(quick, res_meta + "wood.value");
				AddHeroDisplayLine($"wood {res.wood.value}", wood);

				var ore = matcher.FindNumericOffset(quick, res_meta + "ore.value");
				AddHeroDisplayLine($"ore {res.ore.value}", ore);

				var gemstones = matcher.FindNumericOffset(quick, res_meta + "gemstones.value");
				AddHeroDisplayLine($"gemstones {res.gemstones.value}", gemstones);

				var crystals = matcher.FindNumericOffset(quick, res_meta + "crystals.value");
				AddHeroDisplayLine($"crystals {res.crystals.value}", crystals);

				var mercury = matcher.FindNumericOffset(quick, res_meta + "mercury.value");
				AddHeroDisplayLine($"mercury {res.mercury.value}", mercury);

				var dust = matcher.FindNumericOffset(quick, res_meta + "dust.value");
				AddHeroDisplayLine($"dust {res.dust.value}", dust);

				// read hero indexes for this side
				side_heroes.Add(new());
				for (int i = 0; i < player.sideHeroes.heroes.Length; ++i)
				{
					var hero = player.sideHeroes.heroes[i];
					side_heroes.Last()[hero] = matcher.FindNumericOffset(quick, player_meta + $"sideHeroes.heroes[].{i}");
				}
			}
			VPerf($"Perf: Load sides time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			RewindHeroDisplays();

			// Add each side's heroes
			for (int s = 0; s < side_heroes.Count; ++s)
			{
				var hero_idxs = side_heroes[s];
				NextPlayerDisplay();
				AddHeroDisplayLine();

				VSGSides($"Heroes owned by player :");
				int h = 0;
				foreach (var idx in hero_idxs)
				{
					var hero = hero_list[idx.Key];
					var info = hero_infos.hero_infos[hero.configSid];
					info.ingame_index = idx.Key;
					string hero_idx_meta = $"top_level_3.sides.array[].{s}.sideHeroes.heroes[].{h}";
					info.no = idx.Value;
					AddHeroInfoToSide(info);

					string hero_meta = $"top_level_3.heroes.list[].{idx.Value.Value}.";
					string a_stats_meta = hero_meta + "additionalStats.";
					string party_meta = hero_meta + "party.units[].";
					IndentHeroDisplay(0);

					Json.HeroJson.MultiStats all_stats = new();
					all_stats.Accumulate(info.token.stats);
					all_stats.Accumulate(hero.statsByLevel);
					all_stats.Accumulate(hero.additionalStats);

					var name_level_line = $"{info.name,-26}:lvl {hero.currentLevel,2}";
					AddHeroDisplayLine(name_level_line);

					IndentHeroDisplay(2);

					var hero_node = matcher.FindNumericOffset(quick, hero_meta + @"node");
					var coords = MapObjects.Coords(hero.node);
					AddHeroDisplayLine($"Node: {hero.node} ({coords.Item1},{coords.Item2})", hero_node);
					// TODO: extract file and load binary into hex editor
					// TODO: load individual jsons from a file

					// only modify additional stats, but print all three plus the total
					var offence = matcher.FindNumericOffset(quick, a_stats_meta + "offence");
					AddHeroDisplayLine($"offence {all_stats.all_offences}", offence);

					var defence = matcher.FindNumericOffset(quick, a_stats_meta + "defence");
					AddHeroDisplayLine($"defence {all_stats.all_defences}", defence);

					var spellPower = matcher.FindNumericOffset(quick, a_stats_meta + "spellPower");
					AddHeroDisplayLine($"spellPower {all_stats.all_spellPowers}", spellPower);

					var intelligence = matcher.FindNumericOffset(quick, a_stats_meta + "intelligence");
					AddHeroDisplayLine($"intelligence {all_stats.all_intelligences}", intelligence);

					var luck = matcher.FindNumericOffset(quick, a_stats_meta + "luck");
					AddHeroDisplayLine($"luck {all_stats.all_lucks}", luck);

					var moral = matcher.FindNumericOffset(quick, a_stats_meta + "moral");
					AddHeroDisplayLine($"moral {all_stats.all_morals}", moral);

					var movementBonus = matcher.FindNumericOffset(quick, a_stats_meta + "movementBonus");
					AddHeroDisplayLine($"movementBonus {hero.additionalStats.movementBonus}", movementBonus);

					var spell_points = matcher.FindNumericOffset(quick, hero_meta + "mana");
					AddHeroDisplayLine($"mana {hero.mana}", spell_points);

					var movement = matcher.FindNumericOffset(quick, hero_meta + "worldMovePoints");
					AddHeroDisplayLine($"movement {hero.worldMovePoints}", movement);

					// units are displayed in order of slot. We need to remember their index to find the right no.
					var units = hero.party.units.ToList();
					int i = 0;
					foreach (var unit in units) unit.index = i++;
					units.Sort((x, y) => x.slotPos.CompareTo(y.slotPos));

					IndentHeroDisplay(4);
					foreach (var unit in units)
					{
						var stat = matcher.FindNumericOffset(quick, $"{party_meta}{unit.index}.stacks");
						AddHeroDisplayLine($"{unit.sid,-20} {unit.stacks}", stat);
						++i;
					}
				}
			}
			VPerf($"Perf: Load heroes time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			// Add each side's heroes
			for (int s = 0; s < side_heroes.Count; ++s)
			{
				var hero_idxs = side_heroes[s];
				NextPlayerDisplay();
				AddHeroDisplayLine();

				VSGSides($"Heroes owned by player :");
				//int h = 0;
				foreach (var idx in hero_idxs)
				{
					ListHero(quick/*, s, h*/, idx.Key, idx.Value, true);
				}
			}
			VPerf($"Perf: Load heroes time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			map_city_objs = new();
			map_city_info = new();
			squad_prox = new();

			// load active squads
			squad_infos = new();
			for (int i = 0; i < squads.list.Length; ++i)
			{
				var squad = squads.list[i];
				if (squad.idActive[0].active)
				{
					string squad_meta = $"top_level_3.squads.list[].{i}.";
					var info = new SquadInfo(squad);
					squad_infos[squad.id] = info;
					info.no = matcher.FindNumericOffset(quick, $"{squad_meta}node");

					for (int u = 0; u < squad.units.Length; ++u)
					{
						squad_infos[squad.id].units[u].no = matcher.FindNumericOffset(quick, $"{squad_meta}units[].{u}.amount");
					}
				}
			}
			VPerf($"Perf: Load active squads time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			foreach (var obj in map_objs)
			{
				if (obj.sid.Contains("_city"))
				{
					map_city_info.Add($"{obj.sid}:");
					var id_nodes = obj.ids.Zip(obj.nodes, (item1, item2) => (item1, new Node(item2))).ToArray();
					foreach (var id_node in id_nodes)
					{
						map_city_info.Add($"    {id_node.item1,3} {id_node.Item2.PrintCoords,-9}");
					}

					map_city_objs.Add(obj);
				}
				else if (obj.sid.Contains("mine_"))
				{
					var id_nodes = obj.ids.Zip(obj.nodes, (id, node) => (id, new Node(node))).ToArray();
					foreach (var id_node in id_nodes)
					{
						// ownerSide
						//res_mine_infos[id] = new ResMineInfo(...);
						// TODO: data to change mine type
					}

					var res_mines = game_objs.resMines;
					// TODO: add resMines
					// TODO: don't know how to interpret 'objectsByType[].<i>.type' yet

				}
				else if (obj.sid.Contains("resource_"))
				{
					var id_nodes = obj.ids.Zip(obj.nodes, (id, node) => (id, new Node(node))).ToArray();
					var res_objs = game_objs.resObjs;
					// TODO: import resources
					foreach (var id_node in id_nodes)
					{
						
					}
				}
			}
			VPerf($"Perf: Load map objs time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			game_city_obj = new();

			RewindHeroDisplays();

			for (int i = 0; i < game_objs.cityObjs.Length; ++i)
			{
				var city_obj = game_objs.cityObjs[i];
				game_city_obj.Add(city_obj);
				var buildings_obj = city_obj.buildings;

				current_side = city_obj.ownerSide;
				if (current_side == -1) current_side = unowned_player;

				AddCityDisplayLine();

				AddCityDisplayLine($"{city_obj.cityName,-24} : id {city_obj.idMapObject}"); // TODO: lookup actual city name
				AddCityNameToSide(city_obj.cityName);
				IndentHeroDisplay();

				var bases = sg3.GetBuildingBases(i);
				string cityobjs_meta = $"top_level_3.objects.cityObjs[].{i}.";
				string bldgs_meta = $"{cityobjs_meta}buildings.";
				AddCityDisplayLine($"todaysConstructionsCount : {city_obj.buildings.todaysConstructionsCount}", matcher.FindNumericOffset(quick, bldgs_meta + "todaysConstructionsCount"));

				foreach (var bldg in bases)
				{
					var bldg_meta = bldgs_meta + bldg.tag;
					AddCityDisplayLine($"{bldg.sid,-16} built: {bldg.isConstructed.ToString()}", matcher.FindTrueFalseOffset(quick, bldg_meta + "isConstructed"));
					IndentHeroDisplay(4);

					AddCityDisplayLine($"level        : {bldg.level}", matcher.FindNumericOffset(quick, bldg_meta + "level"));
					if (bldg is SaveGameJson3.Hire)
					{
						SaveGameJson3.Hire? hire = null;
						foreach (var h in buildings_obj.hires)
						{
							if (h.sid == bldg.sid)
							{
								hire = h;
								break;
							}
						}

						AddCityDisplayLine($"unit level   : {hire.assortment.unitSets[0].level}", matcher.FindNumericOffset(quick, bldg_meta + JsonStrings.hire_assortmentLevel));
					}

					IndentHeroDisplay(2);
				}

				IndentHeroDisplay(0);
			}
			VPerf($"Perf: Load city objs time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			sg3_json = sg3;
		}

		private static void ListHero(byte[] quick/*, int s, int h*/, int hero_index, NumericOffset no, bool owned)
		{
			var hero = hero_list[hero_index];
			var info = hero_infos.hero_infos[hero.configSid];
			info.ingame_index = hero_index;
			//string hero_idx_meta = $"top_level_3.sides.array[].{s}.sideHeroes.heroes[].{h}";
			info.no = no;
			AddHeroInfoToSide(info);

			string hero_meta = $"top_level_3.heroes.list[].{no.Value}.";
			string a_stats_meta = hero_meta + "additionalStats.";
			string party_meta = hero_meta + "party.units[].";
			IndentHeroDisplay(0);

			Json.HeroJson.MultiStats all_stats = new();
			all_stats.Accumulate(info.token.stats);
			all_stats.Accumulate(hero.statsByLevel);
			all_stats.Accumulate(hero.additionalStats);

			var name_level_line = $"{info.name,-26}:lvl {hero.currentLevel,2}";
			AddHeroDisplayLine(name_level_line);

			IndentHeroDisplay(2);

			var hero_node = matcher.FindNumericOffset(quick, hero_meta + @"node");
			var coords = MapObjects.Coords(hero.node);
			AddHeroDisplayLine($"Node: {hero.node} ({coords.Item1},{coords.Item2})", hero_node);
			// TODO: extract file and load binary into hex editor
			// TODO: load individual jsons from a file

			// only modify additional stats, but print all three plus the total
			var offence = matcher.FindNumericOffset(quick, a_stats_meta + "offence");
			AddHeroDisplayLine($"offence {all_stats.all_offences}", offence);

			var defence = matcher.FindNumericOffset(quick, a_stats_meta + "defence");
			AddHeroDisplayLine($"defence {all_stats.all_defences}", defence);

			var spellPower = matcher.FindNumericOffset(quick, a_stats_meta + "spellPower");
			AddHeroDisplayLine($"spellPower {all_stats.all_spellPowers}", spellPower);

			var intelligence = matcher.FindNumericOffset(quick, a_stats_meta + "intelligence");
			AddHeroDisplayLine($"intelligence {all_stats.all_intelligences}", intelligence);

			var luck = matcher.FindNumericOffset(quick, a_stats_meta + "luck");
			AddHeroDisplayLine($"luck {all_stats.all_lucks}", luck);

			var moral = matcher.FindNumericOffset(quick, a_stats_meta + "moral");
			AddHeroDisplayLine($"moral {all_stats.all_morals}", moral);

			var movementBonus = matcher.FindNumericOffset(quick, a_stats_meta + "movementBonus");
			AddHeroDisplayLine($"movementBonus {hero.additionalStats.movementBonus}", movementBonus);

			var spell_points = matcher.FindNumericOffset(quick, hero_meta + "mana");
			AddHeroDisplayLine($"mana {hero.mana}", spell_points);

			var movement = matcher.FindNumericOffset(quick, hero_meta + "worldMovePoints");
			AddHeroDisplayLine($"movement {hero.worldMovePoints}", movement);

			// units are displayed in order of slot. We need to remember their index to find the right no.
			var units = hero.party.units.ToList();
			int i = 0;
			foreach (var unit in units) unit.index = i++;
			units.Sort((x, y) => x.slotPos.CompareTo(y.slotPos));

			IndentHeroDisplay(4);
			foreach (var unit in units)
			{
				var stat = matcher.FindNumericOffset(quick, $"{party_meta}{unit.index}.stacks");
				AddHeroDisplayLine($"{unit.sid,-20} {unit.stacks}", stat);
				++i;
			}
		}
	}
}
