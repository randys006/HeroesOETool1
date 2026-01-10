using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.Globals;

namespace HeroesOE
{
	public class Testing
	{
		public static void InfoTest(string suite, string topic, string info)
		{
			Debug.WriteLine($"[INFO]: {suite, 32}:{topic, 40}:{info}");
		}
		public static void TestSaveGame()
		{
			var save_game = SaveGame.GetCurrentSaveGameName();
			InfoTest("TestSaveGame", @"GetCurrentSaveGameName", save_game);
			InfoTest("TestSaveGame", @"GetCurrentGameName", SaveGame.GetCurrentGameName(save_game));

			var quick = SaveGame.LoadCurrentQuicksave();
			InfoTest("TestSaveGame", @"Quicksave Bytes", $"{quick.Length}");
			if (quick == null) { return; }

			matcher = new JsonBracketMatcher(quick);

			//matcher.Print(4);	// TEMPCODE
			List<List<int>> side_heroes = new();

			if (matcher.Valid)
			{
				quickbytes = quick;
				var sg3 = new SaveGameJson3.SaveGame3(matcher.GetTopLevelJson(quick, 3));

				ResetHeroDisplays();

				foreach (var player in sg3.sg.sides.players)
				{
					NextPlayerDisplay();
					var res = player.res;

					Debug.WriteLine($"sg3: Player {player.index}: {player.name}:");
					Debug.WriteLine($"     RES: {res.gold.value,7} {res.wood.value,4} {res.ore.value,4} {res.gemstones.value,4} {res.crystals.value,4} {res.mercury.value,4} {res.dust.value,4}");

					string player_meta = $"top_level_3.sides.array[].{player.index}.";
					string res_meta = player_meta + "res.";

					// misc player stats
					var currentLawsPoints_line = $"currentLawsPoints {player.currentLawsPoints}";
					string currentLawsPoints_meta = player_meta + "currentLawsPoints";
					var currentLawsPoints = matcher.FindNumericOffset(quick, currentLawsPoints_meta);
					AddHeroDisplayLine(currentLawsPoints_line, currentLawsPoints);

					// resource stats
					var gold_line = $"gold {res.gold.value}";
					string gold_meta = res_meta + "gold.value";
					var gold = matcher.FindNumericOffset(quick, gold_meta);
					AddHeroDisplayLine(gold_line, gold);

					var wood_line = $"wood {res.wood.value}";
					string wood_meta = res_meta + "wood.value";
					var wood = matcher.FindNumericOffset(quick, wood_meta);
					AddHeroDisplayLine(wood_line, wood);

					var ore_line = $"ore {res.ore.value}";
					string ore_meta = res_meta + "ore.value";
					var ore = matcher.FindNumericOffset(quick, ore_meta);
					AddHeroDisplayLine(ore_line, ore);

					var gemstones_line = $"gemstones {res.gemstones.value}";
					string gemstones_meta = res_meta + "gemstones.value";
					var gemstones = matcher.FindNumericOffset(quick, gemstones_meta);
					AddHeroDisplayLine(gemstones_line, gemstones);

					var crystals_line = $"crystals {res.crystals.value}";
					string crystals_meta = res_meta + "crystals.value";
					var crystals = matcher.FindNumericOffset(quick, crystals_meta);
					AddHeroDisplayLine(crystals_line, crystals);

					var mercury_line = $"mercury {res.mercury.value}";
					string mercury_meta = res_meta + "mercury.value";
					var mercury = matcher.FindNumericOffset(quick, mercury_meta);
					AddHeroDisplayLine(mercury_line, mercury);

					var dust_line = $"dust {res.dust.value}";
					string dust_meta = res_meta + "dust.value";
					var dust = matcher.FindNumericOffset(quick, dust_meta);
					AddHeroDisplayLine(dust_line, dust);

					// read hero indexes for this side
					side_heroes.Add(new());
					foreach(var hero in player.sideHeroes.heroes)
					{
						side_heroes.Last().Add(hero);
					}
				}

				var hero_list = sg3.sg.heroes.list;
				RewindHeroDisplays();

				foreach (var hero_idxs in side_heroes)
				{
					NextPlayerDisplay();

					Debug.WriteLine($"Heroes owned by player :");
					foreach(var idx in hero_idxs)
					{
						string hero_display = "";

						var hero = hero_list[idx];
						var stats = hero.statsByLevel;

						string hero_meta = $"top_level_3.heroes.list[].{idx}.";
						// TODO: stats don't match. Need to add hero's base stats?

						var name_level_line = $"  {hero.configSid,-26}: lvl {hero.currentLevel,2}";
						AddHeroDisplayLine(name_level_line);

						var stats_line = $"atk {stats.offence,2} def {stats.defence,2} pwr {stats.spellPower,2} int {stats.intelligence,2} lck {stats.luck} mrl {stats.moral}";
						AddHeroDisplayLine(stats_line);

						var spell_points_line = $"mana {hero.mana}";
						string spell_points_meta = hero_meta + "mana";
						var spell_points = matcher.FindNumericOffset(quick, spell_points_meta);
						AddHeroDisplayLine(spell_points_line, spell_points);

						var movement_line = $"movement {hero.worldMovePoints}";
						string movement_line_meta = hero_meta + "worldMovePoints";
						var movement = matcher.FindNumericOffset(quick, movement_line_meta);
						AddHeroDisplayLine(movement_line, movement);

						var units = hero.party.units.ToList();
						units.Sort((x, y) => x.slotPos.CompareTo(y.slotPos));

						string party_meta = hero_meta + "party.units[].";
						int i = 0;
						foreach (var unit in units)
						{
							var unit_line = $"    {unit.sid,20} {unit.stacks}";
							hero_display += Environment.NewLine + unit_line;
							string unit_line_meta = $"{party_meta}{i}.stacks";
							var stat = matcher.FindNumericOffset(quick, unit_line_meta);
							AddHeroDisplayLine(unit_line, stat);
							++i;
						}
					}
				}
			}
		}
	}
}
