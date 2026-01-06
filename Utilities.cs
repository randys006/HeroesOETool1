using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE
{
	public class Utilities
	{
		public class CsvBuilder
		{
			public CsvBuilder() { sb = new StringBuilder(); }

			public StringBuilder sb;
			public CsvBuilder App(object value) { App(value.ToString()); return this; }
			public CsvBuilder App(int value) { if (value == int.MinValue) Sep(); else App(value.ToString()); return this; }
			public CsvBuilder App(string value) { sb.Append(value); sb.Append(","); return this; }
			public CsvBuilder Sep() { sb.Append(","); return this; }
			public CsvBuilder Cr() { sb.AppendLine(""); return this; }
			public string String() { return sb.ToString(); }
		}
		public static string ToAscii(string utf)
		{
			StringBuilder sb = new StringBuilder("");

			for (int i = 0; i < utf.Length; ++i)
			{
				char c = utf[i];
				if (c >= ' ' && c <= '~')
				{
					sb.Append(c);
					continue;
				}
				
				int ic = (int)c;
				switch(ic)
				{
					case 228:
					case 246:
					case 252:
						sb.Append(c);
						break;
					case 8209:  // short hyphen
						sb.Append('-');
						break;
					case 8217:  // fancy tic
						sb.Append('\'');
						break;
					default:
						Debug.WriteLine($"---------- ToAscii found a '{c}' ({ic})");
						break;
				}
			}

			return sb.ToString();
		}
	}
}
