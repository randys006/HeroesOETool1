namespace HeroesOE
{
	partial class CityForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tabControl1 = new TabControl();
			tabPage1 = new TabPage();
			tabPage2 = new TabPage();
			tabControl2 = new TabControl();
			Demon = new TabPage();
			Dungeon = new TabPage();
			Human = new TabPage();
			Nature = new TabPage();
			Undead = new TabPage();
			Unfrozen = new TabPage();
			tabControl1.SuspendLayout();
			tabPage1.SuspendLayout();
			tabControl2.SuspendLayout();
			SuspendLayout();
			// 
			// tabControl1
			// 
			tabControl1.Controls.Add(tabPage1);
			tabControl1.Controls.Add(tabPage2);
			tabControl1.Location = new Point(158, 17);
			tabControl1.Name = "tabControl1";
			tabControl1.SelectedIndex = 0;
			tabControl1.Size = new Size(1099, 884);
			tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			tabPage1.Controls.Add(tabControl2);
			tabPage1.Location = new Point(4, 34);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new Padding(3);
			tabPage1.Size = new Size(1091, 846);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "FACTIONS";
			tabPage1.UseVisualStyleBackColor = true;
			// 
			// tabPage2
			// 
			tabPage2.Location = new Point(4, 34);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new Padding(3);
			tabPage2.Size = new Size(1091, 846);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "CITIES";
			tabPage2.UseVisualStyleBackColor = true;
			// 
			// tabControl2
			// 
			tabControl2.Controls.Add(Demon);
			tabControl2.Controls.Add(Dungeon);
			tabControl2.Controls.Add(Human);
			tabControl2.Controls.Add(Nature);
			tabControl2.Controls.Add(Undead);
			tabControl2.Controls.Add(Unfrozen);
			tabControl2.Location = new Point(-4, 6);
			tabControl2.Name = "tabControl2";
			tabControl2.SelectedIndex = 0;
			tabControl2.Size = new Size(1108, 840);
			tabControl2.TabIndex = 0;
			// 
			// Demon
			// 
			Demon.Location = new Point(4, 34);
			Demon.Name = "Demon";
			Demon.Padding = new Padding(3);
			Demon.Size = new Size(1100, 802);
			Demon.TabIndex = 0;
			Demon.Text = "DEMON";
			Demon.UseVisualStyleBackColor = true;
			// 
			// Dungeon
			// 
			Dungeon.Location = new Point(4, 34);
			Dungeon.Name = "Dungeon";
			Dungeon.Padding = new Padding(3);
			Dungeon.Size = new Size(1100, 802);
			Dungeon.TabIndex = 1;
			Dungeon.Text = "DUNGEON";
			Dungeon.UseVisualStyleBackColor = true;
			// 
			// Human
			// 
			Human.Location = new Point(4, 34);
			Human.Name = "Human";
			Human.Size = new Size(1100, 802);
			Human.TabIndex = 2;
			Human.Text = "HUMAN";
			Human.UseVisualStyleBackColor = true;
			// 
			// Nature
			// 
			Nature.Location = new Point(4, 34);
			Nature.Name = "Nature";
			Nature.Size = new Size(1100, 802);
			Nature.TabIndex = 3;
			Nature.Text = "NATURE";
			Nature.UseVisualStyleBackColor = true;
			// 
			// Undead
			// 
			Undead.Location = new Point(4, 34);
			Undead.Name = "Undead";
			Undead.Size = new Size(1100, 802);
			Undead.TabIndex = 4;
			Undead.Text = "UNDEAD";
			Undead.UseVisualStyleBackColor = true;
			// 
			// Unfrozen
			// 
			Unfrozen.Location = new Point(4, 34);
			Unfrozen.Name = "Unfrozen";
			Unfrozen.Size = new Size(1100, 802);
			Unfrozen.TabIndex = 5;
			Unfrozen.Text = "UNFROZEN";
			Unfrozen.UseVisualStyleBackColor = true;
			// 
			// CityForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1278, 914);
			Controls.Add(tabControl1);
			Name = "CityForm";
			Text = "CityForm";
			tabControl1.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabControl2.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private TabControl tabControl1;
		private TabPage tabPage1;
		private TabControl tabControl2;
		private TabPage Demon;
		private TabPage Dungeon;
		private TabPage tabPage2;
		private TabPage Human;
		private TabPage Nature;
		private TabPage Undead;
		private TabPage Unfrozen;
	}
}