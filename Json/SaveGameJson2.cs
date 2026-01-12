using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HeroesOE.Json
{
	internal class SaveGameJson2
	{
		public class SaveGame
		{
			public SaveGame(string json)
			{
				sg = JsonSerializer.Deserialize<Rootobject>(json);
			}

			public void Write(string out_path, string save_path, DateTime dateTime)
			{
				Wrapper wrapper = new Wrapper();
				wrapper.Description = "This is the 2th json blob from the following savegame file.";
				wrapper.Path = save_path;
				wrapper.WrittenDateTimeUtc = dateTime.ToUniversalTime().ToString();
				wrapper.rootobject = sg;

				var options = new JsonSerializerOptions { WriteIndented = true, IndentCharacter = '\t', IndentSize = 1 };
				var json = JsonSerializer.Serialize<Wrapper>(wrapper, options);
				File.WriteAllText(out_path, json);
			}

			public Rootobject sg;
		}

		public class Wrapper
		{
			public string Description { get; set; }
			public string Path { get; set; }
			public string WrittenDateTimeUtc { get; set; }
			public Rootobject rootobject { get; set; }
		}

		// this is the 3rd json blob in the quicksavegame
		public class Rootobject
		{
			public int[] bytes_ { get; set; }
		}
	}
}
