using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOE
{
	public class Utilities
	{
		public static string PrintHexRange(byte[] data, int offset, int length)
		{
			// Use LINQ to get the specified segment of the byte array
			byte[] range = data.Skip(offset).Take(length).ToArray();

			// Convert the segment to a hex string
			string hexString = Convert.ToHexString(range);

			return hexString;
		}
		public static void WriteIntToBytes(byte[] targetArray, int value, int index)
		{
			// 1. Convert the integer to a 4-byte array (machine-specific endianness)
			byte[] bytesToWrite = BitConverter.GetBytes(value);

			// 2. Copy the 4 bytes into the target array at the specified start index
			//    SourceArray, SourceIndex, DestinationArray, DestinationIndex, Length
			Buffer.BlockCopy(bytesToWrite, 0, targetArray, index, sizeof(int));
		}
		/*
		 [System.Text.Json.Serialization.JsonPropertyName("array")]
		*/
		public class Offsetter
		{
			int offset = 0;
			int last = 0;
			bool post = false;
			public Offsetter(int start = 0) { offset = start; }
			public int Bump(int bump) { last = offset; offset += bump; return last; }
			public int Debump(int bump) { last = offset; offset -= bump; return last; }
			public static implicit operator int(Offsetter o) { int i = o.post ? o.last : o.offset; o.post = false; return i; }
			public static Offsetter operator ++(Offsetter o) { o.Bump(1); o.post = true; return o; }
			public static Offsetter operator --(Offsetter o) { o.Debump(1); o.post = true; return o; }

			public static implicit operator Offsetter(int v) { return new Offsetter(v); }
		}
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
				switch (ic)
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
		public static string Hex24(int i) { return $"{i,0:D8} (0x{i,0:X6})"; }
		public class MatchStack
		{
			public MatchStack()
			{
				// add a boundary match which is always outermost indexes
				stack.Push(new(int.MinValue, int.MaxValue));
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

				sb.Remove(0, 1);    // remove the . from the boundary
				sb.Remove(sb.Length - 1, 1);    // remove the trailing .
				match.FullTag = sb.ToString();

				return Level;
			}
			public JsonBracketMatcher.Match Peek() { return stack.Peek(); }
			public JsonBracketMatcher.Match Pop() { return stack.Pop(); }
			public int Level { get { return stack.Count - 2; } }
			Stack<JsonBracketMatcher.Match> stack = new();
		}
		public static string FindNotepadPlusPlusPath()
		{
			// Notepad++ installer typically creates a key here with an empty name value containing the path.
			string[] registryKeys = new string[]
			{
			@"SOFTWARE\Notepad++", // For 64-bit on 64-bit systems, or 32-bit on 32-bit systems
            @"SOFTWARE\Wow6432Node\Notepad++" // For 32-bit on 64-bit systems
			};

			foreach (var keyPath in registryKeys)
			{
				using (RegistryKey key = Registry.LocalMachine.OpenSubKey(keyPath))
				{
					if (key != null)
					{
						// The install path is often stored in the default (empty name) value of the key.
						object installDir = key.GetValue("");
						if (installDir != null && !string.IsNullOrEmpty(installDir.ToString()))
						{
							string nppExePath = Path.Combine(installDir.ToString(), "notepad++.exe");
							if (File.Exists(nppExePath))
							{
								return nppExePath;
							}
						}
					}
				}
			}

			// Fallback: Check standard program file locations if registry fails
			string programFiles = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
			string programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);

			string[] commonPaths = new string[]
			{
			Path.Combine(programFiles, "Notepad++", "notepad++.exe"),
			Path.Combine(programFilesX86, "Notepad++", "notepad++.exe")
			};

			foreach (var path in commonPaths)
			{
				if (File.Exists(path))
				{
					return path;
				}
			}

			return null; // Notepad++ installation path not found
		}
		public static bool DeepCompare(object obj1, object obj2, List<string> out1, List<string> out2)
		{
			// This was written by AI and I added the Lists for output. It doesn't work very well :(
			if (ReferenceEquals(obj1, obj2)) return true;
			if (ReferenceEquals(obj1, null) || ReferenceEquals(obj2, null)) return false;
			if (obj1.GetType() != obj2.GetType()) return false;

			Type type = obj1.GetType();

			// Handle primitive types and strings directly
			if (Type.GetTypeCode(type) != TypeCode.Object || type == typeof(string))
			{
				if (!obj1.Equals(obj2))
				{
					var prim = "Primitive: ";
					out1.Add(prim + obj1.ToString());
					out2.Add(prim + out2.ToString());
				}
				return obj1.Equals(obj2);
			}

			// Handle collections
			if (typeof(IEnumerable).IsAssignableFrom(type))
			{
				if (!(obj1 is IEnumerable enum1) || !(obj2 is IEnumerable enum2)) return false;
				var enumerator1 = enum1.GetEnumerator();
				var enumerator2 = enum2.GetEnumerator();
				while (enumerator1.MoveNext() && enumerator2.MoveNext())
				{
					if (!DeepCompare(enumerator1.Current, enumerator2.Current, out1, out2))
					{
						var en = $"IEnumerable: ";
						out1.Add(enumerator1.Current.ToString());
						out2.Add(enumerator2.Current.ToString());
						return false;
					}
				}
				// Ensure both collections ended at the same time
				return !enumerator1.MoveNext() && !enumerator2.MoveNext();
			}

			// Handle complex objects via reflection
			PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
			foreach (var property in properties)
			{
				if (!DeepCompare(property.GetValue(obj1), property.GetValue(obj2), out1, out2))
				{
					var prop = $"Property '{property.Name}': ";
					out1.Add(prop + property.GetValue(obj1).ToString());
					out2.Add(prop + property.GetValue(obj2).ToString());
					return false;
				}
			}

			// Optionally, compare fields as well
			FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Instance);
			foreach (var field in fields)
			{
				if (!DeepCompare(field.GetValue(obj1), field.GetValue(obj2), out1, out2))
				{
					var fld = $"Field: ";
					out1.Add(fld + field.GetValue(obj1).ToString());
					out2.Add(fld + field.GetValue(obj2).ToString());
					return false;
				}
			}

			return true;
		}
	}
}
