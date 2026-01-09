using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

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

			JsonBracketMatcher matcher = new JsonBracketMatcher(quick);
			//matcher.Print(4);	// TEMPCODE
			List<List<int>> side_heroes = new();

			if (matcher.Valid)
			{
				Globals.quickbytes = quick;
				var sg3 = new SaveGameJson3.SaveGame3(matcher.GetTopLevelJson(quick, 3));

				foreach (var player in sg3.sg.sides.players)
				{
					Debug.WriteLine($"sg3: Player {player.index}: {player.name}:");
					var res = player.res;
					Debug.WriteLine($"     RES: {res.gold.value,7} {res.wood.value,4} {res.ore.value,4} {res.gemstones.value,4} {res.crystals.value,4} {res.mercury.value,4} {res.dust.value,4}");

					// read hero indexes for this side
					side_heroes.Add(new());
					foreach(var hero in player.sideHeroes.heroes)
					{
						side_heroes.Last().Add(hero);
					}
				}

				var hero_list = sg3.sg.heroes.list;

				Globals.ResetHeroDisplays();

				foreach (var hero_idxs in side_heroes)
				{
					Globals.AddHeroDisplay();

					Debug.WriteLine($"Heroes owned by player :");
					foreach(var idx in hero_idxs)
					{
						string hero_display = "";

						var hero = hero_list[idx];
						var stats = hero.statsByLevel;
						string hero_meta = $"top_level_3.heroes.list[].{idx}.";
						// TODO: need to add hero's base stats

						var name_level_line = $"  {hero.configSid,-26}: lvl {hero.currentLevel,2}";
						Globals.AddHeroDisplayLine(name_level_line);

						var stats_line = $"atk {stats.offence,2} def {stats.defence,2} pwr {stats.spellPower,2} int {stats.intelligence,2} lck {stats.luck} mrl {stats.moral}";
						Globals.AddHeroDisplayLine(stats_line);

						var spell_points_line = $"mana {hero.mana}";
						string spell_points_meta = hero_meta + "mana";
						var spell_points = matcher.FindNumericOffset(quick, spell_points_meta);
						Globals.AddHeroDisplayLine(spell_points_line, spell_points);

						var movement_line = $"movement {hero.worldMovePoints}";
						string movement_line_meta = hero_meta + "worldMovePoints";
						var movement = matcher.FindNumericOffset(quick, movement_line_meta);
						Globals.AddHeroDisplayLine(movement_line, movement);

						var units = hero.party.units.ToList();
						units.Sort((x, y) => x.slotPos.CompareTo(y.slotPos));

						foreach (var unit in units)
						{
							var unit_line = $"    {unit.sid,20} {unit.stacks}";
							hero_display += Environment.NewLine + unit_line;
							Globals.AddHeroDisplayLine(unit_line);
						}
					}
				}
			}
		}
	}
}
