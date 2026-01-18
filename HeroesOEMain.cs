using HeroesOE.Json;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using static HeroesOE.Globals;
using static HeroesOE.JsonBracketMatcher;
using static HeroesOE.Screenshot.Screenshot;
using static HeroesOE.Utilities;
using static HeroesOE.Json.JsonFilePaths;
using static HeroesOE.VGlobals;

namespace HeroesOE
{
	public partial class HeroesOEMain : Form
	{

		public HeroesOEMain()
		{
			InitializeComponent();

			timerQuicksave.Interval = 100;
			cboAutoRefresh.Checked = true;

			foreach (var hero_info_pair in hero_infos.hero_infos)
			{
				var hero_info = hero_info_pair.Value;

				// only operate on base tokens
				string path = HeroJson.Token.GetFactionHeroPath(hero_info.sid);
				if (string.IsNullOrEmpty(path)) continue;

				var token_file = File.ReadAllText(path);
				var hero_root = JsonSerializer.Deserialize<HeroJson.Rootobject>(token_file);
				hero_info.token = hero_root.tokens[0];

				string skills = "";
				foreach (var skill in hero_info.token.startSkills)
				{
					skills += $";{hero_skills.GetSkillName(skill.sid, skill.skillLevel),36}";
				}

				VHeroes($"{hero_info.ascii_name,32};{hero_info.sid,18};{hero_info.token.classType}{skills}");
			}

			//List<UnitsLogicJson.UnitsLogic> all_units = new();
			foreach (var city in city_defs)
			{
				foreach (var unit in city.units)
				{
					units_logics.units_logics[unit.unit_name] = unit;
					//all_units.Add(unit);
				}
			}
			//units_logics = all_units.ToArray();
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
			Offsetter offset = new Offsetter();

			VDev("--------- Parsing binary shtuff from quicksave ---------");
			// first print the matcher top-level offsets
			foreach (var match in matcher.top_level)
			{
				var line = $"{Hex24(match.O)}  {Hex24(match.Length)}  {Hex24(match.C)}";
				lb.Add(line);
				VDev(line);
			}
			lb.Add("------------------------------");
			{   // file starts with a byte followed by hex chars which must be a hash
				int len = text[offset++];
				var hash = Encoding.ASCII.GetString(text, offset.Bump(len), len);
				lb.Add(hash);
				VDev(hash);
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
				VDev(line);

				offset = matcher.top_level[i].C + 1;
			}
			VDev("---------  Done (binary shtuff from quicksave)  ---------");
		}
		private void SetAdjustPending(bool adjust)
		{
			// TODO: slick way to notify user of pending changes
			adjust_pending = adjust;
			if (adjust_pending)
			{
				cmdRefresh.Text = "Refresh*";
			}
			else
			{
				cmdRefresh.Text = "Refresh";
			}
		}
		private void timerQuicksave_Tick(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;

			var quick_save_time = File.GetLastWriteTimeUtc(SaveGame.CurrentQuickSave);
			if (quick_save_time > Globals.quicksave_time)
			{
				if (adjust_pending)	return;
				if (!Refresh()) timerQuicksave.Enabled = true;  // retry indefinitely if Refresh failed
			}
		}

		private void cmdAdjust_Click(object sender, EventArgs e)
		{
			// TODO: queue up multiple adjustments instead of refreshing immediately
			var new_value = encoding.GetBytes(txtAdjustValue.Text.Trim());
			if (new_value.Length <= 0) return;
			AdjustJsonValue(current_no, new_value);

			if (current_no.Tag.Length > 0)
			{
				var tokens = current_no.Tag.Split(";");
				if (tokens.Length > 1)
				{
					var val = current_no.Value;
					if (tokens[0] == "hire.level")
					{
						var cno = matcher.FindTrueFalseOffset(quickbytes, tokens[1]);
						AdjustJsonValue(cno, "1"u8.ToArray());
						var ano = matcher.FindNumericOffset(quickbytes, tokens[2]);
						AdjustJsonValue(ano, val == 1 ? "1"u8.ToArray() : "3"u8.ToArray());
					}
					else if (tokens[0].Contains("assortment.unitSets[]"))
					{
						var cno = matcher.FindTrueFalseOffset(quickbytes, tokens[1]);
						AdjustJsonValue(cno, val >= 1 ? "1"u8.ToArray() : "0"u8.ToArray());
						var lno = matcher.FindNumericOffset(quickbytes, tokens[2]);
						AdjustJsonValue(lno, val == 3 ? "2"u8.ToArray() : "1"u8.ToArray());
					}
					else if (tokens[0].Contains("hire.isConstructed"))
					{
						if (val == 0)
						{
							var lno = matcher.FindNumericOffset(quickbytes, tokens[1]);
							AdjustJsonValue(lno, "1"u8.ToArray());
							var ano = matcher.FindNumericOffset(quickbytes, tokens[2]);
							AdjustJsonValue(ano, "0"u8.ToArray());
						}
					}
				}
			}

			Refresh();
		}

		private void AdjustJsonValue(NumericOffset? no, byte[]? new_value, bool write = true)
		{
			string dbg_prev = "";

			if (no != null)
			{
				no.Value = int.Parse(new_value);
				if (no is JsonBracketMatcher.TrueFalseOffset)
				{
					new_value = encoding.GetBytes(((TrueFalseOffset)no).StringValue);
				}

				int delta = new_value.Length - no.Length;

				dbg_prev = encoding.GetString(quickbytes, no.Offset - 20, no.Length + 40);

				if (delta == 0)
					Array.Copy(new_value, 0, quickbytes, no.Offset, no.Length);
				else
				{
					byte[] buf = new byte[quickbytes.Length + delta];
					int copy1 = no.Offset;
					int copy2 = new_value.Length;
					int copy3 = quickbytes.Length - no.Offset - no.Length;
					int total_bytes_to_copy = copy1 + copy2 + copy3;
					Debug.Assert(buf.Length == total_bytes_to_copy);

					// Adjust the stored length. The stored value seems to have a constant value added to the
					// length (0x0168E000), but don't have much data. We'll try just shifting the stored value.
					// TODO: json '1' only has a 3-byte length param. We don't use it yet so just hardcode a 4.
					int len_offset = matcher.FindTopLevelOpen(no.Offset) - 4;
					int json_len = BitConverter.ToInt32(quickbytes, len_offset);
					json_len += delta;
					WriteIntToBytes(quickbytes, json_len, len_offset);

					Buffer.BlockCopy(quickbytes, 0, buf, 0, copy1);
					Buffer.BlockCopy(new_value, 0, buf, copy1, copy2);
					Buffer.BlockCopy(quickbytes, copy1 + no.Length, buf, no.Offset + new_value.Length, copy3);

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
			}
			if (write)
			{
				Zip.WriteBytesToGzip(quickbytes, quicksave_path);
			}
			if (no != null)
			{
				var dbg_now = encoding.GetString(quickbytes, no.Offset - 20, no.Length + 40);
				string dbg_prev_pbl = $"Adjust: idx={no.Offset,8} len={no.Length,4}";
				string dbg_now_pbl = new string(' ', dbg_prev_pbl.Length);
				VDev($"{dbg_prev_pbl}{dbg_prev}'->'");
				VDev($"{dbg_now_pbl}{dbg_now}");
			}
		}

		private void UpdateSelectedPlayerValue(int player, int index)
		{
			if (player < 0 || player >= player_display.Count || index < 0 || index >= player_display[player].Count)
			{
				lblAdjust.Text = "";
				txtAdjustValue.Text = "";
				current_no = null;
				current_player = -1;
				current_index = -1;
				return;
			}

			var hd = player_display[player][index];
			current_no = player_metadata[player][index];
			current_player = player;
			current_index = index;

			lblAdjust.Text = hd;
			txtAdjustValue.Text = current_no.Value.ToString();

			// load heros and cities into toolstrips
			toolStripContainer1.RightToolStripPanel.Controls.Clear();
			toolStripHeroes.Items.Clear();
			foreach (var hero in current_hero_infos[current_player])
			{
				toolStripHeroes.Items.Add(hero.name);
				var item = toolStripHeroes.Items[toolStripHeroes.Items.Count - 1];
				item.TextAlign = ContentAlignment.MiddleLeft;
				item.Tag = hero.ingame_index;
				//item.MouseDown += new MouseEventHandler(toolStripHeroesItem_MouseDown);
			}
			toolStripContainer1.RightToolStripPanel.Controls.Add(toolStripHeroes);
			toolStripCities.Items.Clear();
			foreach (var city in current_city_names[current_player])
			{
				toolStripCities.Items.Add(city);
				toolStripCities.Items[toolStripCities.Items.Count - 1].TextAlign = ContentAlignment.MiddleLeft;
			}
			toolStripContainer1.RightToolStripPanel.Controls.Add(toolStripCities);
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
			SetAdjustPending(true);	// TODO: track old value for pending adjust
		}

		private void cboAutoRefresh_CheckedChanged(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;
		}

		private void cmdOpenSaveDir_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", Path.GetDirectoryName(display_savegame_path));
		}

		private bool Refresh()
		{
			var sw = Stopwatch.StartNew();

			var last_player = current_player;
			if (!Testing.TestSaveGame(cboSaveAllTags.Checked)) return false; // TODO: refactor from Testing. Writes updated hero_displays

			lbBinaryShtuff.Items.Clear();
			//FindBinaryShtuff(quickbytes, matcher);
			VPerf($"Perf: TestSaveGame time: {sw.Elapsed.TotalNanoseconds * 1E-6}"); sw.Restart();

			// clear listboxes
			ListBox[] lbs = [lbSide0, lbSide1, lbSide2, lbSide3, lbBinaryShtuff, lbMapProximity];
			foreach (var l in lbs) { l.Items.Clear(); l.BeginUpdate(); }

			// load player display lines into listboxes
			int i = 0;
			foreach (var side in Globals.player_display)
			{
				var lb = lbs[i++];
				foreach (var line in side) { lb.Items.Add(line); }
			}

			// load extra display lines into their listbox
			foreach (var info in map_city_info)
			{
				lbBinaryShtuff.Items.Add(info);
			}

			foreach (var l in lbs) { l.EndUpdate(); }

			current_player = last_player;
			if (current_player < 0) return false;

			if (lbs[current_player].Items.Count > current_index)
				lbs[current_player].SelectedIndex = current_index;
			else
			{
				current_player = -1;
				current_index = -1;
			}
			if (current_player < 0) return false;
			UpdateSelectedPlayerValue(current_player, current_index);

			cboSaveAllTags.Checked = false;
			SetAdjustPending(false);

			return true;
		}

		private void cmdRefresh_Click(object sender, EventArgs e)
		{
			if (!Refresh()) timerQuicksave.Enabled = true;  // retry if failed
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
			{
				var sg0 = new SaveGameJson0.SaveGame(matcher.GetTopLevelJson(quickbytes, 0));
				var out_path = temp_path + @"quicksave_sg0.json";
				sg0.Write(out_path, quicksave_path, quicksave_time);
				var nppp = FindNotepadPlusPlusPath();
				if (String.IsNullOrEmpty(nppp)) nppp = "notepad.exe";
				Process.Start(nppp, out_path);
			}
			{
				var sg1 = new SaveGameJson1.SaveGame(matcher.GetTopLevelJson(quickbytes, 1));
				var out_path = temp_path + @"quicksave_sg1.json";
				sg1.Write(out_path, quicksave_path, quicksave_time);
				var nppp = FindNotepadPlusPlusPath();
				if (String.IsNullOrEmpty(nppp)) nppp = "notepad.exe";
				Process.Start(nppp, out_path);
			}
			{
				var sg2 = new SaveGameJson0.SaveGame(matcher.GetTopLevelJson(quickbytes, 2));
				var out_path = temp_path + @"quicksave_sg2.json";
				sg2.Write(out_path, quicksave_path, quicksave_time);
				var nppp = FindNotepadPlusPlusPath();
				if (String.IsNullOrEmpty(nppp)) nppp = "notepad.exe";
				Process.Start(nppp, out_path);
			}
			{
				var sg3 = new SaveGameJson3.SaveGame(matcher.GetTopLevelJson(quickbytes, 3));
				var out_path = temp_path + @"quicksave_sides.json";
				sg3.Write(out_path, quicksave_path, quicksave_time);
				var nppp = FindNotepadPlusPlusPath();
				if (String.IsNullOrEmpty(nppp)) nppp = "notepad.exe";
				Process.Start(nppp, out_path);
			}
		}

		private void cmdOpenTempDir_Click(object sender, EventArgs e)
		{
			Process.Start("explorer.exe", temp_path);
		}

		private void HeroesOEMain_Load(object sender, EventArgs e)
		{

		}

		private void toolStripContainer1_ContentPanel_DragDrop(object sender, DragEventArgs e)
		{
			if (sender == toolStripHeroes)
			{
				// TODO: write new list of heroes
				int i = 42;
			}
		}

		private void toolStripHeroes_DragDrop(object sender, DragEventArgs e)
		{
			VGui("toolStripHeroes_DragDrop: DragDrop");

			// TODO: write new list of heroes
			ToolStripItem draggedItem = (ToolStripItem)e.Data.GetData(typeof(ToolStripItem));
			List<int> ts_hero_idxs = new();
			foreach (ToolStripItem item in toolStripHeroes.Items)
			{
				ts_hero_idxs.Add((int)item.Tag);
			}

			List<int> hero_idxs = new();
			foreach (var info in current_hero_infos[current_player])
			{
				hero_idxs.Add(info.ingame_index);
			}

			bool reload = false;
			var ts_game = ts_hero_idxs.Zip(hero_idxs, (ts, game) => (Ts: ts, Game: game));

			foreach (var pair in ts_game)
			{
				Debug.WriteLine($"ts: {pair.Ts,-2} game: {pair.Game,-2}");
				reload |= pair.Ts != pair.Game;
			}

			if (reload)
			{
				int i = 42;
			}
		}

		private void toolStripHeroes_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				VGui("toolStripHeroes_MouseDown: left button down");
				ToolStripItem item = sender as ToolStripItem;
				if (item != null)
				{
					// Start the drag operation
					item.DoDragDrop(item, DragDropEffects.Move);
					VGui("toolStripHeroes_MouseDown: Starting DragDrop");
				}
			}
		}

		private void toolStripHeroes_DragEnter(object sender, DragEventArgs e)
		{
			// Check if the dragged item is the correct type
			if (e.Data.GetDataPresent(typeof(ToolStripItem)))
			{
				VGui("toolStripHeroes_DragEnter: effect move");
				e.Effect = DragDropEffects.Move; // Must set an effect for DragDrop to fire
			}
			else
			{
				VGui("toolStripHeroes_DragEnter: effect none");
				e.Effect = DragDropEffects.None;
			}
		}

		private void toolStripHeroesItem_MouseDown(object sender, MouseEventArgs e)
		{
			VGui("toolStripHeroesItem_MouseDown: ItemMouseDown");
			if ((Control.MouseButtons & MouseButtons.Left) != 0)
			{
				VGui("toolStripHeroesItem_MouseDown: ItemMouseDown, left button down");
				ToolStripItem item = sender as ToolStripItem;
				if (item != null)
				{
					// Start the drag operation
					item.DoDragDrop(item, DragDropEffects.Move);
					VGui("toolStripHeroesItem_MouseDown: Starting DragDrop");
				}
			}
		}

		private void toolStripHeroes_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			VGui("toolStripHeroes_ItemClicked: ItemClicked");
			if ((Control.MouseButtons & MouseButtons.Left) != 0)
			{
				VGui("toolStripHeroes_ItemClicked: ItemClicked, left button down");
				ToolStripItem item = sender as ToolStripItem;
				if (item != null)
				{
					// Start the drag operation
					item.DoDragDrop(item, DragDropEffects.Move);
					VGui("toolStripHeroes_ItemClicked: Starting DragDrop");
				}
			}
		}

		private void timerCheckHeroToolstrip_Tick(object sender, EventArgs e)
		{
			// TODO: write new list of heroes
			if (current_player < 0 || toolStripHeroes.Items.Count == 0) return;
			List<int> ts_hero_idxs = new();
			foreach (ToolStripItem item in toolStripHeroes.Items)
			{
				ts_hero_idxs.Add((int)item.Tag);
			}

			List<int> hero_idxs = new();
			List<NumericOffset> nos = new();
			foreach (var info in current_hero_infos[current_player])
			{
				hero_idxs.Add(info.ingame_index);
				nos.Add(info.no);
			}

			bool reload = false;
			var ts_game = ts_hero_idxs.Zip(hero_idxs, (ts, game) => (Ts: ts, Game: game));

			foreach (var pair in ts_game)
			{
				VGui($"ts: {pair.Ts,-2} game: {pair.Game,-2}");
				reload |= pair.Ts != pair.Game;
			}

			if (reload)
			{
				var tsg_no = ts_game.Zip(nos, (tsg, no) => (Tsg: tsg, No: no));
				foreach (var pair in tsg_no)
				{
					if (pair.Tsg.Ts != pair.Tsg.Game)
						AdjustJsonValue(pair.No, encoding.GetBytes(pair.Tsg.Ts.ToString()), false);
				}

				AdjustJsonValue(null, null);
				//var side_heroes_meta = $""
				//foreach (var match in matcher.matches)
				//{
				//	if (match.FullTag.Contains(""))
				//}
				Refresh();

			}
		}
	}
}
