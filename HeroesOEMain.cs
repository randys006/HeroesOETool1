using HeroesOE.Json;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using static HeroesOE.Globals;
using static HeroesOE.Utilities;
using static HeroesOE.Json.HeroInfoJson;
using static HeroesOE.Screenshot.Screenshot;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Eventing.Reader;

namespace HeroesOE
{
	public partial class HeroesOEMain : Form
	{

		public HeroesOEMain()
		{
			InitializeComponent();

			timerQuicksave.Interval = 100;
			cboAutoRefresh.Checked = true;
			if (!Directory.Exists(temp_path)) Directory.CreateDirectory(temp_path);

			foreach (var hero_info_pair in hero_infos.hero_infos)
			{
				var hero_info = hero_info_pair.Value;

				// only operate on base tokens
				string path = HeroJson.Token.GetFactionHeroPath(hero_info.sid);
				if (string.IsNullOrEmpty(path)) continue;

				var token_file = File.ReadAllText(path);
				var hero_root = JsonSerializer.Deserialize<HeroJson.Rootobject>(token_file);
				var hero_token = hero_root.tokens[0];

				string skills = "";
				foreach (var skill in hero_token.startSkills)
				{
					skills += $";{hero_skills.GetSkillName(skill.sid, skill.skillLevel),36}";
				}

				Debug.WriteLine($"{hero_info.ascii_name,32};{hero_info.sid,18};{hero_token.classType}{skills}");
			}

			foreach (var city in city_defs)
			{
				//city.ParseHires();
			}
		}

		private void timerScreenshot_Tick(object sender, EventArgs e)
		{
			//var new_shots = ScanForNewScreenshots();
			//foreach (var new_shot in new_shots)
			//{
			//	//Image shot = Image.FromFile(new_shot);
			//	var shot_type = CharacterizeScreenshot(new_shot);
			//	if (shot_type == "city.build")
			//		ParseCityBuildScreen(new_shot);
			//}
		}

		private void cmdClearScreenshots_Click(object sender, EventArgs e)
		{
			ClearScreenshots();
		}

		private void FindBinaryShtuff(byte[] text, JsonBracketMatcher matcher)
		{
			// look before top level jsons
			var lb = lbBinaryShtuff.Items;
			lb.Clear();
			Offsetter offset = new Offsetter();

			Debug.WriteLine("--------- Parsing binary shtuff from quicksave ---------");
			// first print the matcher top-level offsets
			foreach (var match in matcher.top_level)
			{
				var line = $"{Hex24(match.O)}  {Hex24(match.Length)}  {Hex24(match.C)}";
				lb.Add(line);
				Debug.WriteLine(line);
			}
			lb.Add("------------------------------");
			{   // file starts with a byte followed by hex chars which must be a hash
				int len = text[offset++];
				var hash = Encoding.ASCII.GetString(text, offset.Bump(len), len);
				lb.Add(hash);
				Debug.WriteLine(hash);
			}
			{   // next, a byte followed by ascii chars which is the version
				int len = text[offset++];
				var ver = Encoding.ASCII.GetString(text, offset.Bump(len), len);
				lb.Add(ver.ToString());
			}
			// look between blocks
			for (int i = 0; i < matcher.top_level.Count; i++)
			{
				int len = matcher.top_level[i].O - offset;

				string hex = PrintHexRange(text, offset, len);

				int int0 = 0;
				//BitConverter.ToInt32(text, offset.Bump(4));

				string line = $"Before json {i}: {len} bytes: ";
				line = line + Encoding.UTF8.GetCharCount(text, offset, 1) + " ";
				line = line + Encoding.UTF32.GetCharCount(text, offset, 1) + " ";
				line = line + Encoding.Unicode.GetCharCount(text, offset, 1) + " ";
				line = line + ": " + hex;

				lb.Add(line);
				Debug.WriteLine(line);

				offset = matcher.top_level[i].C + 1;
			}
			Debug.WriteLine("---------  Done (binary shtuff from quicksave)  ---------");
		}

		private void timerQuicksave_Tick(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;

			var quick_save_time = File.GetLastWriteTimeUtc(SaveGame.CurrentQuickSave);
			if (quick_save_time > Globals.quicksave_time) Refresh();
		}

		private void cmdAdjust_Click(object sender, EventArgs e)
		{
			//var prev = quicksave.Substring(current_no.Offset - 20, current_no.Length + 40);
			//var removed = quicksave.Remove(current_no.Offset, current_no.Length);
			//quicksave = removed.Insert(current_no.Offset, txtAdjustValue.Text);
			//Zip.WriteGZipFile(display_savegame, quicksave);

			var new_value = encoding.GetBytes(txtAdjustValue.Text.Trim());
			if (new_value.Length <= 0) return;
			int delta = new_value.Length - current_no.Length;

			var dbg_prev = encoding.GetString(quickbytes, current_no.Offset - 20, current_no.Length + 40);

			if (delta == 0)
				Array.Copy(new_value, 0, quickbytes, current_no.Offset, current_no.Length);
			else
			{
				byte[] buf = new byte[quickbytes.Length + delta];
				int copy1 = current_no.Offset;
				int copy2 = new_value.Length;
				int copy3 = quickbytes.Length - current_no.Offset - current_no.Length;
				int total_bytes_to_copy = copy1 + copy2 + copy3;
				Debug.Assert(buf.Length == total_bytes_to_copy);

				// Adjust the stored length. The stored value seems to have a constant value added to the
				// length (0x0168E000), but don't have much data. We'll try just shifting the stored value.
				// TODO: json '1' only has a 3-byte length param. We don't use it yet so just hardcode a 4.
				int len_offset = matcher.FindTopLevelOpen(current_no.Offset) - 4;
				int json_len = BitConverter.ToInt32(quickbytes, len_offset);
				json_len += delta;
				WriteIntToBytes(quickbytes, json_len, len_offset);

				Buffer.BlockCopy(quickbytes, 0, buf, 0, copy1);
				Buffer.BlockCopy(new_value, 0, buf, copy1, copy2);
				Buffer.BlockCopy(quickbytes, copy1 + current_no.Length, buf, current_no.Offset + new_value.Length, copy3);

				// verify
				//for (int i = 0; i < new_value.Length; ++i)
				//{
				//	Debug.Assert(buf[current_no.Offset + i] == new_value[i]);
				//}
				//for (int i = new_value.Length; i < new_value.Length + 4; ++i)
				//{
				//	Debug.Assert(buf[current_no.Offset + i] == quickbytes[current_no.Offset + i - delta]);
				//}

				quickbytes = buf;
			}

			var dbg_now = encoding.GetString(quickbytes, current_no.Offset - 20, current_no.Length + 40);
			Zip.WriteBytesToGzip(quickbytes, quicksave_path);

			string dbg_prev_pbl = $"Adjust: idx={current_no.Offset,8} len={current_no.Length,4}";
			string dbg_now_pbl = new string(' ', dbg_prev_pbl.Length);
			Debug.WriteLine("{prev_pbl}{dbg_prev}'->'");
			Debug.WriteLine("{now_pbl}{dbg_now}");

			Refresh();
		}

		private void UpdateSelectedPlayerValue(int player, int index)
		{
			if (index < 0)
			{
				lblAdjust.Text = "";
				txtAdjustValue.Text = "";
				current_no = null;
			}

			var hd = player_display[player][index];
			current_no = player_metadata[player][index];

			lblAdjust.Text = hd;
			txtAdjustValue.Text = current_no.Value.ToString();
		}

		private void lbSide0_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSelectedPlayerValue(0, lbSide0.SelectedIndex);
		}

		private void lbSide1_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSelectedPlayerValue(1, lbSide1.SelectedIndex);
		}

		private void lbSide2_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSelectedPlayerValue(2, lbSide2.SelectedIndex);
		}

		private void txtAdjustValue_TextChanged(object sender, EventArgs e)
		{
			bool enabled = true;

			cmdAdjust.Enabled = enabled;
			cboAutoRefresh.Checked = false;
		}

		private void cboAutoRefresh_CheckedChanged(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;
		}

		private void cmdOpenSaveDir_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", Path.GetDirectoryName(display_savegame_path));
		}

		private void Refresh()
		{
			Testing.TestSaveGame(); // TODO: refactor from Testing. Writes updated hero_displays
									//FindBinaryShtuff(quickbytes, matcher);

			ListBox[] lbs = [lbSide0, lbSide1, lbSide2, lbSide3];
			foreach (var l in lbs) { l.Items.Clear(); }

			int i = 0;
			foreach (var side in Globals.player_display)
			{
				var lb = lbs[i++];
				foreach (var hero in side) { lb.Items.Add(hero); }
			}
		}

		private void cmdRefresh_Click(object sender, EventArgs e)
		{
			Refresh();
		}

		private void cmdShowDiff_Click(object sender, EventArgs e)
		{
			if (diffForm == null)
			{
				diffForm = new HOETool.DiffForm(quicksave_path);
			}
			diffForm.Show();
		}

		private void cmdOpenSide1InNotepad_Click(object sender, EventArgs e)
		{
			var sg3 = new SaveGameJson3.SaveGame3(matcher.GetTopLevelJson(quickbytes, 3));
			var out_path = temp_path + @"quicksave_sides.json";
			sg3.Write(out_path, quicksave_path, quicksave_time);
			var nppp = FindNotepadPlusPlusPath();
			if (String.IsNullOrEmpty(nppp)) nppp = "notepad.exe";
			Process.Start(nppp, out_path);

			// TODO: save sg3 json; open it
		}

		private void cmdOpenTempDir_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", temp_path);
		}
	}
}
