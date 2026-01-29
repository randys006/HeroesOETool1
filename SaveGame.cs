using System;
using System.Collections.Generic;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE
{
	internal class SaveGame
	{
		public const string saves_path = @"C:\Users\randy\AppData\LocalLow\Unfrozen\HeroesOE\saves\Singleplayer";

		public static string GetMostRecentSaveGameName(bool quick = false)
		{
			// list all folders
			// parse each folder, compare the timestamp of most recent changed file
			// return the folder name containing the most recent file
			string save_game = "";
			DateTime recent_date = DateTime.UnixEpoch;

			var games = Directory.GetDirectories(saves_path);
			foreach (var game in games)
			{
				var saves = Directory.GetFiles(game, @"*.saveskirmish");
				foreach (var save in saves)
				{
					var date = File.GetLastAccessTimeUtc(save);
					if (date > recent_date)
					{
						recent_date = date;
						save_game = save;
					}
				}
			}

			most_recent_save_game = save_game;
			return save_game;
		}

		public static string GetCurrentGameName(string save_game = "")
		{
			// TODO: GetCurrentGameName algorithm
			if (string.IsNullOrEmpty(save_game))
				save_game = GetMostRecentSaveGameName();

			return Path.GetDirectoryName(save_game);
		}

		public static byte[] LoadCurrentQuicksave()
		{
			var game_path = CurrentQuickSave;
			var quick = ReadSaveGame(game_path);
			Globals.display_savegame_path = game_path;
			Globals.quicksave_path = game_path;
			Globals.quicksave_time = File.GetLastWriteTimeUtc(game_path);

			return quick;
		}

		public static byte[] ReadSaveGame(string save_game)
		{
			var save = Zip.ReadGZipFileToBytes(save_game);
			return save;
		}

		public static string? save_game;
		public static string? last_autosave_day;
		private static string? most_recent_save_game;

		public static string CurrentQuickSave { get { return GetCurrentGameName() + @"\quicksave.saveskirmish"; } }

	}
}
