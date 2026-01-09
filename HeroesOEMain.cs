using HeroesOE.Json;
using System.Diagnostics;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Json;
using static HeroesOE.Globals;
using static HeroesOE.Json.HeroInfoJson;
using static HeroesOE.Screenshot.Screenshot;

namespace HeroesOE
{
	public partial class HeroesOEMain : Form
	{

		public HeroesOEMain()
		{
			InitializeComponent();

			// initialize tessaract


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

		private void timerQuicksave_Tick(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;

			Testing.TestSaveGame(); // writes updated hero_displays
			ListBox[] lbs = [lbSide0, lbSide1, lbSide2, lbSide3];

			int i = 0;
			foreach (var side in Globals.hero_display)
			{
				var lb = lbs[i++];
				lb.Items.Clear();
				foreach (var hero in side)
				{ lb.Items.Add(hero); }
			}
		}

		private void cmdAdjust_Click(object sender, EventArgs e)
		{
			//var prev = quicksave.Substring(current_no.Offset - 20, current_no.Length + 40);
			//var removed = quicksave.Remove(current_no.Offset, current_no.Length);
			//quicksave = removed.Insert(current_no.Offset, txtAdjustValue.Text);
			//Zip.WriteGZipFile(display_savegame, quicksave);

			var new_value = encoding.GetBytes(txtAdjustValue.Text);
			var prev = encoding.GetString(quickbytes, current_no.Offset - 20, current_no.Length + 40);

			Array.Copy(new_value, 0, quickbytes, current_no.Offset, current_no.Length);

			var now = encoding.GetString(quickbytes, current_no.Offset - 20, current_no.Length + 40);
			Zip.WriteBytesToGzip(quickbytes, quicksave_path);

			string prev_pbl = $"Adjust: idx={current_no.Offset,8} len={current_no.Length,4}";
			string now_pbl = new string(' ', prev_pbl.Length);
			Debug.WriteLine("{prev_pbl}{prev}'->'");
			Debug.WriteLine("{now_pbl}{now}");
		}

		private void UpdateSelectedPlayerValue(int player, int index)
		{
			var hd = hero_display[player][index];
			current_no = hero_metadata[player][index];

			lblAdjust.Text = hd;
			txtAdjustValue.Text = current_no.Value.ToString();
		}

		private void lbSide0_SelectedIndexChanged(object sender, EventArgs e)
		{
			UpdateSelectedPlayerValue(0, lbSide0.SelectedIndex);
		}

		private void txtAdjustValue_TextChanged(object sender, EventArgs e)
		{
			bool enabled = true;

			// TODO: figure out how to change length of values
			if (current_no.Length != txtAdjustValue.Text.Length) enabled = false;

			cmdAdjust.Enabled = enabled;
			cboAutoRefresh.Checked = false;
		}

		private void cboAutoRefresh_CheckedChanged(object sender, EventArgs e)
		{
			timerQuicksave.Enabled = cboAutoRefresh.Checked;
		}
	}
}
