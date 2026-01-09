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
		/*
		 [System.Text.Json.Serialization.JsonPropertyName("array")]
		*/
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
		public static string Hex24(int i) { return $"{i,0:D8} (0x{i,0:X6})";  }
		public class MatchStack
		{
			public MatchStack()
			{
				// add a boundary match which is always outermost indexes
				stack.Push(new (int.MinValue, int.MaxValue));
			}
			public int Count { get { return stack.Count; } }
			public int Push(JsonBracketMatcher.Match match)
			{
				stack.Push(match);
				match.Level = Level;

				StringBuilder sb = new StringBuilder();
				foreach (var m in stack.Reverse())
				{
					sb.Append(m.Tag);
					sb.Append('.');
				}

				sb.Remove(0, 1);	// remove the . from the boundary
				sb.Remove(sb.Length - 1, 1);	// remove the trailing .
				match.FullTag = sb.ToString();

				return Level;
			}
			public JsonBracketMatcher.Match Peek() { return stack.Peek(); }
			public JsonBracketMatcher.Match Pop() { return stack.Pop(); }
			public int Level { get { return stack.Count - 2; } }
			Stack<JsonBracketMatcher.Match> stack = new();
		}
	}
}
