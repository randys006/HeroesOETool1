using IronOcr;
using IronSoftware;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Tesseract;
using static HeroesOE.Json.HeroSkillsJson;
using Image = SixLabors.ImageSharp.Image;
using Rectangle = SixLabors.ImageSharp.Rectangle;

namespace HeroesOE.Screenshot
{
	public class Screenshot
	{
		public const string screenshot_path = @"C:\Program Files (x86)\Steam\userdata\11101802\760\remote\3241970\screenshots";

		public static Rectangle city_title_region = new Rectangle(x: 813, y: 60, width: 942, height: 35);
		public static Rectangle hero_class_region = new Rectangle(x: 1058, y: 153, width: 530, height: 33);

		public static void ClearScreenshots()
		{
			var jpgs = Directory.GetFiles(screenshot_path, @"*.jpg");

			foreach (var jpg in jpgs)
			{
				File.Delete(jpg);
			}

			prev_shots = new Dictionary<string, string>();
		}

		public static string[] ScanForNewScreenshots()
		{
			List<string> new_shots = new List<string>();

			// TODO: ScanForUpdates algorithm:
			// scans every 100ms for new .jpg files
			// TODO checks all savegame folders 

			var jpgs = Directory.GetFiles(screenshot_path, @"*.jpg");

			foreach (var jpg in jpgs)
			{
				if (!prev_shots.ContainsKey(jpg))
				{
					new_shots.Add(jpg);
					// TODO: figure out how to save previous screenshots
				}
			}

			return new_shots.ToArray();
		}

		public static string CharacterizeScreenshot(string shot)
		{
			string shot_type = "unknown";

			var pixes = GetImagePixes(shot, new Rectangle[]{ city_title_region, hero_class_region });

			foreach (var pix in pixes)
			{
				var text = Tess.GetPixText(pix);
				if (string.IsNullOrEmpty(text)) continue;

				if (text.Contains("CONSTRUCT NEW BUILDINGS"))
					return "city.build";

				// TODO: check all hero classes for match
				foreach (var hero_class in HeroSkills.GetClassesAllFactions())
				{
					if (text == hero_class)
					{
						Debug.WriteLine($"Hero screenshot identified: {hero_class}");
						return "hero";
					}
				}
			}

			return shot_type;
		}

		public static Pix[] GetImagePixes(string shot, Rectangle[] rects)
		{
			List<Pix> pix = new();

			var image = Image.Load<Rgba32>(shot);

			foreach (var rect in rects)
			{
				var imgrect = image.Clone(ctx => ctx.Crop(rect));
				using (var ms = new System.IO.MemoryStream())
				{
					// Save the ImageSharp image to a well-known format like PNG in memory
					// PNG supports the alpha channel properly.
					imgrect.SaveAsPng(ms);
					ms.Position = 0; // Rewind the stream

					// Use Tesseract's built-in memory loader
					// This method detects the format from the stream content
					Pix pixImage = Pix.LoadFromMemory(ms.ToArray());
					pix.Add(pixImage);
				}
				//byte[] data = new byte[sizeof(Rgba32) * width * height];
				//imgrect.CopyPixelDataTo(data, 0, data.Length);
			}

			return pix.ToArray();
		}

		public static void ParseCityBuildScreen(string shot)
		{
			var nameRegion = new Rectangle(x: 790, y: 1141, width: 271, height: 33);
			var uniqueRegion = new Rectangle(x: 288, y: 241, width: 176, height: 58);

			var pixes = GetImagePixes(shot, new Rectangle[] {nameRegion, uniqueRegion});
			foreach (var pix in pixes)
			{
				Debug.WriteLine(Tess.GetPixText(pix));
			}
		}

		// prev_shots: <path, game_name>
		static Dictionary<string, string> prev_shots = new();
	}
}
