using HeroesOE;
using HeroesOE.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOETool
{
	public partial class DiffForm : Form
	{
		public static JsonBracketMatcher? left;
		public static JsonBracketMatcher? rite;
		public static byte[]? left_game;
		public static byte[]? rite_game;

		public DiffForm(string initial)
		{
			InitializeComponent();
			txtLeftFile.Text = initial;
			OpenFile(txtLeftFile);
		}

		private void SelectFile(TextBox tb)
		{
			if (openFileDialog1.ShowDialog() != DialogResult.OK) return;

			tb.Text = openFileDialog1.FileName;

			OpenFile(tb);
		}

		private void OpenFile(TextBox tb)
		{
			bool is_left = tb.Tag == "Left";
			if (!File.Exists(tb.Text)) { SystemSounds.Asterisk.Play(); return; }

			var game = SaveGame.ReadSaveGame(tb.Text);
			if (game == null) { SystemSounds.Asterisk.Play(); return; }

			var matcher = new JsonBracketMatcher(game);
			if (!matcher.Valid) { SystemSounds.Asterisk.Play(); return; }

			if (is_left)
			{
				left = matcher;
				left_game = game;
				if (rite == null) return;
			}
			else
			{
				rite = matcher;
				rite_game = game;
				if (left == null) return;
			}

			Refresh();
		}

		private void Refresh()
		{
			if (left == null || rite == null) { SystemSounds.Asterisk.Play(); return; }

			// TODO: compare top level 1 (the map)
			//var left1 = new SaveGameJson1.SaveGame1(left.GetTopLevelJson(left_game, 1));
			//var rite1 = new SaveGameJson1.SaveGame1(rite.GetTopLevelJson(rite_game, 1));

			// top level 2 isn't interesting
			//var left2 = new SaveGameJson2.SaveGame2(left.GetTopLevelJson(left_game, 2));
			//var rite2 = new SaveGameJson2.SaveGame2(rite.GetTopLevelJson(rite_game, 2));

			var left3 = new SaveGameJson3.SaveGame3(left.GetTopLevelJson(left_game, 3)).sg.heroes.list;
			var rite3 = new SaveGameJson3.SaveGame3(rite.GetTopLevelJson(rite_game, 3)).sg.heroes.list;

			lbLeft.Items.Clear();
			lbRite.Items.Clear();
			List<string> left_diffs = new();
			List<string> rite_diffs = new();
			// try brute-force reflection
			Utilities.DeepCompare(left3, rite3, left_diffs, rite_diffs);
			lbLeft.Items.AddRange(left_diffs.ToArray());
			lbRite.Items.AddRange(rite_diffs.ToArray());
		}

		private void cmdOpenLeft_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select left file for compare";
			SelectFile(txtLeftFile);
		}

		private void cmdRefreshLeft_Click(object sender, EventArgs e)
		{
			OpenFile(txtLeftFile);
		}

		private void cmdOpenRight_Click(object sender, EventArgs e)
		{
			openFileDialog1.Title = "Select right file for compare";
			SelectFile(txtRightFile);
		}

		private void cmdRefreshRight_Click(object sender, EventArgs e)
		{
			OpenFile(txtRightFile);
		}
	}
}
