using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HeroesOE.Utilities;

namespace HeroesOE
{
	public class JsonBracketMatcher
	{
		public class Match
		{
			public Match(int o, int c) { O = o; C = c; Level = 0;  Tag = ""; FullTag = ""; }
			public Match(int o, int c, string tag) : this(o, c) { Tag = tag; }
			public int O { get; set; }
			public int C { get; set; }
			public int Level { get; set; }
			public string Tag { get; set; }
			public string FullTag { get; set; }
			public int Length { get { return C - O; } }
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
		public bool Valid { get; set; }
		public JsonBracketMatcher(string text)
		{
			Valid = FindMatchingBrackets(text, out matches);
			if (Valid)
			{
				matches.Sort((l, r) => l.O.CompareTo(r.O));
			}
			
			Rank();
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
			}
		}

		public static string Pad(int level)
		{
			return new string(' ', level * 2);
		}
		public void Print(int levels = 3)
		{
			if (!Valid) return;

			MatchStack stack = new();

			foreach (var match in matches)
			{
				// can close any number of levels on the stack
				while (match.O > stack.Peek().C)
				{
					int closed_level = stack.Level;
					var closed = stack.Pop();
					if (closed_level < levels) Debug.WriteLine(closed.CloseStr);
				}

				var level = stack.Push(match);
				if (level < levels) Debug.WriteLine(match.OpenStr);
			}
			// close remaining open brackets
			while(stack.Level >= 0)
			{
				var closed = stack.Pop();
				if (stack.Level <= levels) Debug.WriteLine(closed.CloseStr);
			}
		}

		public static string GetBracketTag(string input, int i)
		{
			// 'i' is the index of the bracket in input
			// we expect a quoted string tag before most brackets with tight format, e.g.: "<tag>":{
			const int min_tag_length = 3;	// this is a guess; works w/demo
			const int max_tag_length = 40;  // this is a guess; works w/demo

			if (input.Length < i) return "";
			if (i < min_tag_length + 3) return "";
			if (!bracketPairs.ContainsKey(input[i])) return "";
			if (input[i-2] != '"' || input[i-1] != ':') return "";

			int end = i - 3;
			var start = input.LastIndexOf('"', end);

			if (start == -1 || end - start > max_tag_length) return "";

			var tag = input.Substring(start + 1, end - start);
			return tag;
		}
		public static Dictionary<char, char> bracketPairs = new Dictionary<char, char>
		{
			{ '(', ')' },
			{ '[', ']' },
			{ '{', '}' }
		};

		public static bool FindMatchingBrackets(string input, out List<Match> matches)
		{
			matches = new List<Match>();
			var stack = new Stack<(char Type, int Index, string Tag)>();
			Stack<(int Parent, int Count)> ordinals = new();	// for storing array ordinals

			for (int i = 0; i < input.Length; i++)
			{
				char currentChar = input[i];

				if (bracketPairs.ContainsKey(currentChar))
				{
					var tag = GetBracketTag(input, i); // get the json tag

					// If it's an array opening bracket, store the array open index
					if (currentChar == '[')
					{
						ordinals.Push((i, 0));
						tag = $"{tag}[]";
					}

					if (currentChar == '{' && ordinals.Count > 0 && ordinals.Peek().Parent == stack.Peek().Index)
					{
						// if it's a new array item, add its index to tag and increment the array length
						var ary = ordinals.Pop();

						tag = $"{ary.Count}";	// tag should have been empty; enforce this implicitly

						ary.Count++;
						ordinals.Push(ary);
					}

					stack.Push((currentChar, i, tag));
				}
				else if (bracketPairs.ContainsValue(currentChar))
				{
					// It's a closing bracket
					if (stack.Count == 0)
					{
						// Unmatched closing bracket found
						return false;
					}

					// it it's closing an array, all we have to do is pop it
					if (currentChar == ']') ordinals.Pop();

					(char openType, int openIndex, string tag) = stack.Pop();

					// Check if the closing bracket matches the top of the stack
					if (currentChar != bracketPairs[openType])
					{
						// Mismatched bracket types
						return false;
					}

					// Match found, add the match to the list
					matches.Add(new(openIndex, i, tag));
				}
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
			public static NumericOffset Invalid { get { return new NumericOffset(-1, -1, 0.0); } }
		}
		public NumericOffset FindNumericOffset(string json, string meta_tag)
		{
			var full_tag = meta_tag.Substring(0, meta_tag.LastIndexOf('.'));
			var tag = $"\"{meta_tag.Substring(meta_tag.LastIndexOf('.') + 1)}\":";

			var no = NumericOffset.Invalid;
			int offset = -1;

			foreach (var match in matches)
			{
				if (match.FullTag == full_tag)
				{
					offset = match.O + 1;
				}
			}

			if (offset == 0) return NumericOffset.Invalid;

			offset = json.IndexOf(tag, offset);
			if (offset == -1) return NumericOffset.Invalid;

			if (tag.Contains("worldMovePoints")) 
				Debug.WriteLine($"******  worldMovePoints: '{json.Substring(offset - 8, 8)}'  '{json.Substring(offset, tag.Length)}'  '{json.Substring(offset + tag.Length, 10)}'");
			offset += tag.Length;

			no.Offset = offset;
			var comma = json.IndexOf(',', offset); if (comma == -1) comma = int.MaxValue;
			var close = json.IndexOf('}', offset); if (close == -1) close = int.MaxValue;
			no.Length = int.Min(comma, close) - offset;
			no.Value = Double.Parse(json.Substring(offset, no.Length));

			return no;
		}

		internal string GetTopLevelJson(byte[] quick, int v)
		{
			string json = Globals.encoding.GetString(quick, top_level[v].O, top_level[v].Length);
			if (!Json.JsonFilePaths.QuickJsonValidate(json)) return "";
			return json;
		}
	}
}
