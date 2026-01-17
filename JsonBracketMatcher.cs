using HOETool.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.Globals;
using static HeroesOE.Json.UnitsLogicJson;
using static HeroesOE.Utilities;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static HeroesOE.VGlobals;

namespace HeroesOE
{
	public class JsonBracketMatcher
	{
		public const int max_tag_bytes = 42;        // this is a guess; works w/demo
		public const int max_tag_length = 40;		// this is a guess; works w/demo
		public const int max_numeric_length = 24;
		public class Match
		{
			public Match(int o, int c) { O = o; C = c; Level = 0;  Tag = ""; FullTag = ""; }
			public Match(int o, int c, string tag) : this(o, c) { Tag = tag; }
			public int O { get; set; }
			public int C { get; set; }
			public int Level { get; set; }
			public string Tag { get; set; }
			public string FullTag { get; set; }
			public int Length { get { return C - O + 1; } }
			public string OpenStr
			{
				get
				{   // <pad><open><length><tag>
					var str = $"{Pad(Level)}{Utilities.Hex24(O)}";
					str = $"{str,-28}{Utilities.Hex24(Length),-20}";
					var open = $"{str,-48} {Tag,-40}{FullTag}";
					return open;
				}
			}
			public string CloseStr
			{
				get
				{   // <pad><open><length><tag>
					var str = $"{Pad(Level)}{Utilities.Hex24(C)}";
					var close = $"{str,-48}/{Tag,-40}{FullTag}";
					return close;
				}
			}
		}
		public List<Match> matches;
		public List<Match> top_level;
		public Dictionary<string, int> all_open_offsets;
		public bool Valid { get; set; }
		public int GetOffsetFromFullTag(string full_tag)
		{
			if (!all_open_offsets.ContainsKey(full_tag)) return -1;
			return all_open_offsets[full_tag];
		}
		public JsonBracketMatcher(byte[] text)
		{
			// TODO: Valid is not correct
			Stopwatch sw = Stopwatch.StartNew();
			Valid = FindMatchingBrackets(text);
			VPerf($"Perf: BKTM find time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
			if (Valid)
			{
				matches.Sort((l, r) => l.O.CompareTo(r.O));
				VPerf($"Perf: BKTM SORT time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
			}

			Rank();
			VPerf($"Perf: BKTM RANK time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();
		}

		public void Rank()
		{
			if (!Valid) return;

			MatchStack stack = new();
			top_level = [];

			foreach (var match in matches)
			{
				// any number of levels on the stack can be closed
				while (match.O > stack.Peek().C)
				{
					stack.Pop();
				}

				// every match opens a new level
				match.Level = stack.Push(match);

				// top-level items get a special tag
				if (match.Level == 0)
				{
					match.Tag = $"top_level_{top_level.Count}";
					top_level.Add(match);
				}

				all_open_offsets[match.FullTag] = match.O;
			}
		}

		public static string Pad(int level)
		{
			return new string(' ', level * 2);
		}
		public void Print(int levels = 3)
		{
			if (!Valid) return;

			using (StreamWriter tag_file = new StreamWriter(@"C:\Users\randy\source\HeroesOE\Ref\all_savegame_tags.txt"))
			{
				MatchStack stack = new();

				foreach (var match in matches)
				{
					// can close any number of levels on the stack
					while (match.O > stack.Peek().C)
					{
						int closed_level = stack.Level;
						var closed = stack.Pop();
						if (closed_level < levels) tag_file.WriteLine(closed.CloseStr);
					}

					var level = stack.Push(match);
					if (level < levels) tag_file.WriteLine(match.OpenStr);
				}
				// close remaining open brackets
				while (stack.Level >= 0)
				{
					var closed = stack.Pop();
					if (stack.Level <= levels) tag_file.WriteLine(closed.CloseStr);
				}
			}
		}

		public static string GetBracketTag(byte[] bytes, int i)
		{
			// New, more performant strategy. Assumes no multibyte in tags and just blindly search backwards.
			if (bytes[--i] != (byte)':') return "";
			if (bytes[--i] != (byte)'\"') return "";

			int p = --i;
			while (bytes[p-1] != (byte)'\"') p--;
			return encoding.GetString(bytes, p, i-p+1);

			//var len = max_tag_bytes;
			//if (len > i) len = i;
			//var input = encoding.GetString(bytes, i-len, len+1);    // TODO: GetBracketTag could have issues since it
			//														// might jump backwards inside a multibyte character
			//len = input.Length;	// adjust len to chars
			//int bkt = len - 1;

			//// 'i' is the index of the bracket in input

			//// we expect a quoted string tag before most brackets with tight format, e.g.: "<tag>":{
			//// many of these checks never fire, so commented out
			////const int min_tag_length = 3;	// this is a guess; works w/demo

			////if (len < bkt) return "";
			////if (bkt < min_tag_length + 3) return "";
			////if (!bracketPairs.ContainsKey(input[bkt])) return "";
			//if (input[bkt - 2] != '"' || input[bkt - 1] != ':') return "";

			//int end = bkt - 3;
			//var start = input.LastIndexOf('"', end);

			////if (start == -1 || end - start > max_tag_length) return "";

			//var tag = input.Substring(start + 1, end - start);
			//return tag;
		}
		public static Dictionary<char, char> bracketPairs = new Dictionary<char, char>
		{
			{ '(', ')' },
			{ '[', ']' },
			{ '{', '}' }
		};
		public const byte oparen = (byte)'(';
		public const byte ocurly = (byte)'{';
		public const byte osqr = (byte)'[';
		public const byte cparen = (byte)')';
		public const byte ccurly = (byte)'}';
		public const byte csqr = (byte)']';

		public bool FindMatchingBrackets(byte[] input)
		{
			matches = new();
			all_open_offsets = new();
			var stack = new Stack<(char Type, int Index, string Tag)>();
			Stack<(int Parent, int Count)> ordinals = new();    // for storing array ordinals

			//var bytesConsumed = 1;	// encoding could have variable-length characters
			for (int i = 0; i < input.Length; i++)
			{
				//var bytesConsumed = encoding.GetCharCount(input, i, 1);
				var b = input[i];
				if (b > 0x80)    // check UTF8 multibyte (only if in json)
				{
					if (stack.Count == 0) continue;
					++i;		// >= 2 bytes
					if (b > 0xC0)
					{
						++i;        // >= 3 bytes
						if (b > 0xC8)
						{
							++i;	// 4 bytes
						}
					}
				}
				else
				{
					switch (b)
					{
						case oparen:
							stack.Push(('(', i, GetBracketTag(input, i)));
							continue;
						case cparen:
							if (stack.Count == 0) return false; // check for unmatched closing bracket
							{
								(char openType, int openIndex, string tag) = stack.Pop();
								if (openType != '(') return false; // check for mismatched bracket
								matches.Add(new(openIndex, i, tag));
							}
							continue;
						case ocurly:
							if (ordinals.Count > 0 && ordinals.Peek().Parent == stack.Peek().Index)
							{
								// if it's a new array item, add its index to tag and increment the array length
								var ary = ordinals.Pop();
								var tag = $"{ary.Count}";   // tag should be empty; enforce this implicitly
								ary.Count++;
								ordinals.Push(ary);
								stack.Push(('{', i, tag));
							}
							else
								stack.Push(('{', i, GetBracketTag(input, i)));
							continue;
						case ccurly:
							if (stack.Count == 0) return false; // check for unmatched closing bracket
							{
								(char openType, int openIndex, string tag) = stack.Pop();
								if (openType != '{') return false; // check for mismatched bracket
								matches.Add(new(openIndex, i, tag));
							}
							continue;
						case osqr:
							ordinals.Push((i, 0));
							stack.Push(('[', i, $"{GetBracketTag(input, i)}[]"));
							continue;
						case csqr:
							if (stack.Count == 0) return false; // check for unmatched closing bracket
							ordinals.Pop();
							{
								(char openType, int openIndex, string tag) = stack.Pop();
								if (openType != '[') return false; // check for mismatched bracket
								matches.Add(new(openIndex, i, tag));
							}
							continue;
					}
				}
				//	char currentChar = encoding.GetChars(input, i, 1)[0];

				//if (bracketPairs.ContainsKey(currentChar))
				//{
				//	var tag = GetBracketTag(input, i); // get the json tag

				//	// If it's an array opening bracket, store the array open index
				//	if (currentChar == '[')
				//	{
				//		ordinals.Push((i, 0));
				//		tag = $"{tag}[]";
				//	}

				//	if (currentChar == '{' && ordinals.Count > 0 && ordinals.Peek().Parent == stack.Peek().Index)
				//	{
				//		// if it's a new array item, add its index to tag and increment the array length
				//		var ary = ordinals.Pop();

				//		tag = $"{ary.Count}";	// tag should have been empty; enforce this implicitly

				//		ary.Count++;
				//		ordinals.Push(ary);
				//	}

				//	stack.Push((currentChar, i, tag));
				//}
				//else if (bracketPairs.ContainsValue(currentChar))
				//{
				//	// It's a closing bracket
				//	if (stack.Count == 0)
				//	{
				//		// Unmatched closing bracket found
				//		return false;
				//	}

				//	// it it's closing an array, all we have to do is pop it
				//	if (currentChar == ']') ordinals.Pop();

				//	(char openType, int openIndex, string tag) = stack.Pop();

				//	// Check if the closing bracket matches the top of the stack
				//	if (currentChar != bracketPairs[openType])
				//	{
				//		// Mismatched bracket types
				//		return false;
				//	}

				//	// Match found, add the match to the list
				//	matches.Add(new(openIndex, i, tag));
				//	all_open_offsets[tag] = openIndex;
				//}
				// Ignore any other characters
			}

			// If the stack is empty after iteration, all brackets were matched
			return stack.Count == 0;
		}

		public class NumericOffset
		{
			public NumericOffset(int offset, int length, double value) { Offset = offset; Length = length; Value = value; }
			public int Offset { get; set; }
			public int Length { get; set; }
			public double Value { get; set; }
			public string Tag { get; set; }
			public static NumericOffset Invalid { get { return new NumericOffset(-1, -1, 0); } }

		}
		public class TrueFalseOffset : NumericOffset
		{
			public TrueFalseOffset(int offset, int length, double value) : base(offset, length, value) { }
			public bool BoolValue { get { return (Value == 0) ? false : true; } set { if (value) Value = 1; else Value = 0; } }
			public string StringValue { get { return Value == 0 ? "false" : "true"; } }
			public static TrueFalseOffset Invalid { get { return new TrueFalseOffset(-1, -1, 0.0); } }
		}
		public static int FindStringInBytes(byte[] sourceBytes, string searchString, int startIndex, bool skip = false)
		{
			// 1. Convert the search string to its byte pattern using the correct encoding
			byte[] searchBytes = encoding.GetBytes(searchString);

			var offset = sourceBytes.IndexOf(searchBytes, startIndex);
			if (offset == -1) return -1;

			if (skip) offset += searchBytes.Length;

			return offset;
		}

		// an offset's tag contains info about other matches that also need to be updated
		private void UpdateOffsetTag(string meta_tag, NumericOffset no)
		{
			List<string> updates = new ();
			var tag = "";

			if (meta_tag.Contains("hires[]."))
			{
				int len = meta_tag.IndexOf("hires[].") + 8;	// advance past the next '.'
				len = meta_tag.IndexOf('.', len) + 1;       // include the index and the '.' after it

				string hires_tag = meta_tag.Substring(0, len);
				string isConstructed_tag = $"{hires_tag}{JsonStrings.building_isConstructed}";
				string level_tag = $"{hires_tag}{JsonStrings.building_level}";
				string assortmentLevel_tag = $"{hires_tag}{JsonStrings.hire_assortmentLevel}";

				if (meta_tag.Contains(JsonStrings.building_isConstructed))
				{
					tag = $"hire.{JsonStrings.building_isConstructed}";
					updates.AddRange([level_tag, assortmentLevel_tag]);
				}
				else if (meta_tag.Contains(JsonStrings.hire_assortmentLevel))
				{
					tag = $"hire.{JsonStrings.hire_assortmentLevel}";
					updates.AddRange([isConstructed_tag, level_tag]);
				}
				else if (meta_tag.Contains(JsonStrings.building_level))
				{
					tag = $"hire.{JsonStrings.building_level}";
					updates.AddRange([isConstructed_tag, assortmentLevel_tag]);
				}
			}

			foreach (string update in updates)
			{
				tag = $"{tag};{update}";
			}

			no.Tag = tag;
		}

		public TrueFalseOffset FindTrueFalseOffset(byte[] json, string meta_tag)
		{
			var full_tag = meta_tag.Substring(0, meta_tag.LastIndexOf('.'));
			var tag = $"\"{meta_tag.Substring(meta_tag.LastIndexOf('.') + 1)}\":";

			var tfo = TrueFalseOffset.Invalid;
			if (full_tag.Contains("hires[].5"))
			{
				int i = 42;
			}

			int offset = GetOffsetFromFullTag(full_tag) + 1;

			//foreach (var match in matches)
			//{
			//	if (match.FullTag.EndsWith("hires[].5") && full_tag.EndsWith("hires[].5"))
			//	{
			//		int i = 42;
			//	}
			//	if (match.FullTag == full_tag)
			//	{
			//		offset = match.O + 1;
			//		break;
			//	}
			//}

			if (offset <= 0) return TrueFalseOffset.Invalid;

			offset = FindStringInBytes(json, tag, offset, true);
			if (offset == -1) return TrueFalseOffset.Invalid;

			tfo.Offset = offset;
			var check = encoding.GetChars(json, offset, 4000);
			var comma = FindStringInBytes(json, ",", offset); if (comma == -1) comma = int.MaxValue;
			var close = FindStringInBytes(json, "}", offset); if (close == -1) close = int.MaxValue;
			tfo.Length = int.Min(comma, close) - offset;
			tfo.BoolValue = bool.Parse(Globals.encoding.GetString(json, offset, tfo.Length));
			if (full_tag.EndsWith("hires[].5"))
			{
				int i = 42;
			}
			UpdateOffsetTag(meta_tag, tfo);

			return tfo;
		}

		public NumericOffset FindNumericOffset(byte[] json, string meta_tag)
		{
			var full_tag = meta_tag.Substring(0, meta_tag.LastIndexOf('.'));

			var no = NumericOffset.Invalid;
			int offset = GetOffsetFromFullTag(full_tag) + 1;

			if (offset <= 0) return NumericOffset.Invalid;

			if (Char.IsDigit((char)json[offset]))
			{   // it's a numeric array, just skip commas
				int idx = int.Parse(meta_tag.Substring(meta_tag.LastIndexOf('.') + 1));
				for (int i = 0; i < idx; ++i)
				{
					offset = json.IndexOf(","u8.ToArray(), offset) + 1;
				}
			}
			else
			{
				var tag = $"\"{meta_tag.Substring(meta_tag.LastIndexOf('.') + 1)}\":";
				offset = FindStringInBytes(json, tag, offset, true);
				if (offset == -1) return NumericOffset.Invalid;
			}

			no.Offset = offset;
			var check = encoding.GetChars(json, offset, 400);

			no.Length = json.FirstCommaOrClose(offset) - offset;
			no.Value = Double.Parse(Globals.encoding.GetString(json, offset, no.Length));
			UpdateOffsetTag(meta_tag, no);

			return no;
		}

		public NumericOffset FindValueOffset(byte[] json, string meta_tag)
		{
			var full_tag = meta_tag.Substring(0, meta_tag.LastIndexOf('.'));
			var tag = $"\"{meta_tag.Substring(meta_tag.LastIndexOf('.') + 1)}\":";

			var no = NumericOffset.Invalid;
			int offset = -1;

			while (true)
			{
				if (offset > 0) break;
				foreach (var match in matches)
				{
					if (match.FullTag == full_tag)
					{
						offset = match.O + 1;
						break;
					}
					if (match.FullTag.Contains("sides."))
					{
						int i = 42;
					}
				}

			}

			if (offset <= 0) return NumericOffset.Invalid;

			int found_offset = FindStringInBytes(json, tag, offset, true);
			if (found_offset == -1)
			{   // if failed, try again without the quotes
				offset = FindStringInBytes(json, tag.Substring(1, tag.Length - 2), offset, true);
				if (offset == -1) return NumericOffset.Invalid;
			}
			else offset = found_offset;

			no.Offset = offset;
			var check = encoding.GetChars(json, offset, 400);
			var comma = FindStringInBytes(json, ",", offset); if (comma == -1) comma = int.MaxValue;
			var close = FindStringInBytes(json, "}", offset); if (close == -1) close = int.MaxValue;
			no.Length = int.Min(comma, close) - offset;
			no.Value = Double.Parse(Globals.encoding.GetString(json, offset, no.Length));
			UpdateOffsetTag(meta_tag, no);

			return no;
		}

		internal string GetTopLevelJson(byte[] quick, int v)
		{
			string json = "";
			for (int retry = 0; retry < 5; ++retry)
			{
				try
				{
					json = Globals.encoding.GetString(quick, top_level[v].O, top_level[v].Length);
					break;
				}
				catch { } // ignore; the game is probably writing the file
			}

			if (!Json.JsonFilePaths.QuickJsonValidate(json)) return "";
			return json;
		}

		internal int FindTopLevelOpen(int offset)
		{
			foreach(var json in top_level)
			{
				if (json.C > offset) return json.O;
			}

			return -1;
		}
	}
}
