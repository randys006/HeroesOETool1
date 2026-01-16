using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE
{
	public partial class Globals
	{
		public static Verbosity verbosity = Verbosity.Perf | Verbosity.Heroes | Verbosity.SGHeroes | Verbosity.City;

		[Flags]
		public enum Verbosity
		{
			None = 0,
			GUI = 0x0001,
			Perf = 0x0002,
			Dev = 0x0004,
			Heroes = 0x0100,
			Players = 0x0200,
			City = 0x0400,
			Units = 0x0800,
			SGSides = 0x010000,
			SGHeroes = 0x020000,
			SGCity = 0x040000,
		}
		public static string GetTempFile() { return temp_path + Path.GetFileName(Path.GetTempFileName()) + ".log"; }
		public static StreamWriter debug_file_writer = new StreamWriter(GetTempFile(), true);
		public static void Output(string line)
		{
#if DEBUG
			Debug.WriteLine(line);
#endif
			debug_file_writer.WriteLine(line);
		}
		public static void VGui(string line) { if ((verbosity & Verbosity.GUI) != Verbosity.None) Output($"{"GUI",-10}: {line}"); }
		public static void VPerf(string line) { if ((verbosity & Verbosity.Perf) != Verbosity.None) Output($"{"Perf",-10}: {line}"); }
		public static void VDev(string line) { if ((verbosity & Verbosity.Dev) != Verbosity.None) Output($"{"Dev",-10}: {line}"); }
		public static void VTest(string line) { if (verbosity != Verbosity.None) Output($"{"TEST",-10}: {line}"); }
		public static void VTrace(string line) { Output($"{"TRACE",-10}: {line}"); }
		public static void VHeroes(string line) { if ((verbosity & Verbosity.Heroes) != Verbosity.None) Output($"{"Heroes",-10}: {line}"); }
		public static void VPlayers(string line) { if ((verbosity & Verbosity.Players) != Verbosity.None) Output($"{"Players",-10}: {line}"); }
		public static void VCity(string line) { if ((verbosity & Verbosity.City) != Verbosity.None) Output($"{"City",-10}: {line}"); }
		public static void VUnits(string line) { if ((verbosity & Verbosity.Units) != Verbosity.None) Output($"{"Units",-10}: {line}"); }
		public static void VSGSides(string line) { if ((verbosity & Verbosity.SGSides) != Verbosity.None) Output($"{"SGSides",-10}: {line}"); }
		public static void VSGHeroes(string line) { if ((verbosity & Verbosity.SGHeroes) != Verbosity.None) Output($"{"SGHeroes",-10}: {line}"); }
		public static void VSGCity(string line) { if ((verbosity & Verbosity.SGCity) != Verbosity.None) Output($"{"SGCity",-10}: {line}"); }

	}
}
