using HOETool.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tesseract;

namespace HeroesOE
{
	public static class Tess
	{
		public static string tessdata_path = Globals.temp_path + @"\tessdata";
		// there must be a 'tessdata' directory underneath tessdata_root
		public static TesseractEngine? Init(string tessdata_root)
		{
			string tessdata_path = tessdata_root + @"\tessdata";
			if (!Directory.Exists(tessdata_root) || !Directory.Exists(tessdata_path))
			{
				try
				{
					Directory.CreateDirectory(tessdata_root);
					using (MemoryStream stream = new MemoryStream(Resources.tessdata))
					{
						Zip.SaveInMemoryZipToDisk(stream, tessdata_root);
					}
				}
				catch { return engine; }
			}

			if (engine != null) engine.Dispose();
			TesseractEngine te = new TesseractEngine(tessdata_root, "eng", EngineMode.Default);
			engine = te;

			return engine;
		}
		public static string GetPixText(Pix pix)
		{
			Process(pix);
			var text = tess.GetText().Trim();
			return text;
		}

		public static string GetText()
		{
			if (tess == null) throw new Exception("No Pix has been loaded");
			return tess.GetText().Trim();
		}

		public static void Process(Pix pix)
		{
			if (tess != null) tess.Dispose();

			tess = Tess.engine.Process(pix);
			if (tess == null) throw new Exception("Unable to process Pix");
		}

		public static Page? tess;
		public static TesseractEngine? engine = Init(tessdata_path);
	}
}
