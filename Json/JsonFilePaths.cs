using HOETool.Properties;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	public class JsonFilePaths
	{
		public static bool QuickJsonValidate(string json) { return !string.IsNullOrEmpty(json) && json[0] == '{' && json[json.Length - 1] == '}'; }
		public static string temp_path = System.IO.Path.GetTempPath() + @"HOETool\";
		public static Dictionary<string, MemoryStream> ExtractZipFromMemoryStream(MemoryStream zipStream)
		{
			// Set the position to the beginning of the stream if it's not already
			zipStream.Seek(0, SeekOrigin.Begin);

			var extractedFiles = new Dictionary<string, MemoryStream>();

			// Open the archive in Read mode
			using (var archive = new ZipArchive(zipStream, ZipArchiveMode.Read))
			{
				foreach (ZipArchiveEntry entry in archive.Entries)
				{
					var full_name = entry.FullName.Replace(Path.AltDirectorySeparatorChar, Path.DirectorySeparatorChar);
					if (!full_name.Contains("DB")) continue;
					if (!full_name.Contains(cities_folder) && !full_name.Contains(units_folder)
						&& !full_name.Contains(heroes_skills_file) && !full_name.Contains(heroes_subskills_file)
						&& !full_name.Contains(heroes_folder)
						) continue;

					var entryStream = entry.Open(); // Get the stream for the entry
					var fileMemoryStream = new MemoryStream();

					// Copy the entry's data to a new MemoryStream
					entryStream.CopyTo(fileMemoryStream);
					fileMemoryStream.Seek(0, SeekOrigin.Begin); // Reset stream position for later reading

					extractedFiles.Add(full_name, fileMemoryStream);
					// Process the fileMemoryStream here (e.g., read text, process data, etc.)
					// Example: Reading as a string
					// using (var reader = new StreamReader(fileMemoryStream, Encoding.UTF8, true, 1024, true))
					// {
					//     string fileContent = reader.ReadToEnd();
					// }
				}
			}

			return extractedFiles;
		}
		public static void CheckResources()
		{
			if (!Directory.Exists(temp_path)) Directory.CreateDirectory(temp_path);
			if (!Directory.Exists(Tess.tessdata_path)) Directory.CreateDirectory(Tess.tessdata_path);
			if (!Directory.Exists(coredb_path))
			{
				using (MemoryStream stream = new MemoryStream(Resources.Core))
				{
					var unzipped_streams = ExtractZipFromMemoryStream(stream);

					//var temp_zip = temp_path + "core.zip";
					var core_path = temp_path + @"Core\";
					foreach (var unzipped in unzipped_streams)
					{
						var file_path = core_path + unzipped.Key;
						var dir = Path.GetDirectoryName(file_path);
						if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);

						try
						{
							using (FileStream fileStream = File.Create(file_path))
							{
								unzipped.Value.CopyTo(fileStream);
							}

							// 5. Copy the resource stream to a temporary physical file
							//using (FileStream tempFileStream = File.Create(temp_zip))
							//{
							//	stream.CopyTo(tempFileStream);
							//}

							//// 6. Extract the temporary zip file
							//ZipFile.ExtractToDirectory(temp_zip, core_path);
							Debug.WriteLine($"Successfully extracted '{file_path}'.");
						}
						catch (IOException ex)
						{
							Console.WriteLine($"An IO error occurred: {ex.Message}");
						}
						catch (UnauthorizedAccessException ex)
						{
							Console.WriteLine($"Access denied to the destination folder: {ex.Message}");
						}
						finally
						{
							// 7. Clean up the temporary zip file
							//if (File.Exists(temp_zip))
							//{
							//	File.Delete(temp_zip);
							//}
						}
						//Zip.SaveInMemoryZipToDisk(stream, temp_path + "core.tar");
					}
				}
			}
		}

		// TODO: most paths need to become Properties so they can adapt to the user's system
		private static string coredb_path = temp_path + @"Core\DB\";
		private const string assets_path = @"C:\Program Files (x86)\Steam\steamapps\common\Heroes of Might & Magic Olden Era Demo\HeroesOE_Data\StreamingAssets\";
		private const string install_path = assets_path + @"Lang\english\";
		public static string ref_path = temp_path + @"Ref\";

		private static string cities_folder = @"objects_logic\cities\";
		private static string cities_path = coredb_path + cities_folder;
		private const string texts_path = install_path + @"texts\";
		private static string units_folder =  @"units\units_logics\";
		public static string units_logics_path = coredb_path + units_folder;

		public const string hero_skills_path = texts_path + @"heroSkills.json";
		private static string heroes_skills_file =  @"heroes_skills\skills\skills.json";
		public static string heroes_skills_path = coredb_path + heroes_skills_file;
		private static string heroes_subskills_file = @"heroes_skills\sub_skills\sub_skills.json";
		public static string heroes_subskills_path = coredb_path + heroes_subskills_file;
		public const string heroInfo_path = texts_path + @"heroInfo.json";
		private static string heroes_folder = @"heroes\";
		public static string heroes_path = coredb_path + heroes_folder;

		public const string cities_json_path = texts_path + @"cities.json";
		public static string dungeon_city_path = cities_path + @"dungeon_city.json";
		public static string human_city_path = cities_path + @"human_city.json";
		public static string undead_city_path = cities_path + @"undead_city.json";
		public static string unfrozen_city_path = cities_path + @"unfrozen_city.json";

		public const string units_ability_path = texts_path + @"unitsAbility.json";
		public static string dungeon_units_path = units_logics_path + @"dungeon\";
		public static string human_units_path = units_logics_path + @"human\";
		public static string undead_units_path = units_logics_path + @"undead\";
		public static string unfrozen_units_path = units_logics_path + @"unfrozen\";
	}
}
