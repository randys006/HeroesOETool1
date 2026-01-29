

namespace HeroesOE
{
    partial class HeroesOEMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			timerScreenshot = new System.Windows.Forms.Timer(components);
			cmdClearScreenshots = new Button();
			timerQuicksave = new System.Windows.Forms.Timer(components);
			lbSide0 = new ListBox();
			lbSide1 = new ListBox();
			lbSide2 = new ListBox();
			lbSide3 = new ListBox();
			lblAdjust = new Label();
			timer1 = new System.Windows.Forms.Timer(components);
			txtAdjustValue = new TextBox();
			cmdAdjust = new Button();
			cboAutoRefresh = new CheckBox();
			cmdOpenSaveDir = new Button();
			lbBinaryShtuff = new ListBox();
			cmdRefresh = new Button();
			cmdShowDiff = new Button();
			cmdOpenSide1InNotepad = new Button();
			cmdTestStuff = new Button();
			cmdOpenTempDir = new Button();
			cboSaveAllTags = new CheckBox();
			cmdClearFog = new Button();
			toolStripContainer1 = new ToolStripContainer();
			toolStripCities = new ToolStrip();
			toolStripHeroes = new ToolStrip();
			timerCheckHeroToolstrip = new System.Windows.Forms.Timer(components);
			lbMapProximity = new ListBox();
			label1 = new Label();
			udProximity = new NumericUpDown();
			udX = new NumericUpDown();
			udZ = new NumericUpDown();
			lblNode = new Label();
			cmdShowMapProximity = new Button();
			cmdScreen = new Button();
			cboAllSaveGames = new CheckBox();
			toolStripContainer1.ContentPanel.SuspendLayout();
			toolStripContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)udProximity).BeginInit();
			((System.ComponentModel.ISupportInitialize)udX).BeginInit();
			((System.ComponentModel.ISupportInitialize)udZ).BeginInit();
			SuspendLayout();
			// 
			// timerScreenshot
			// 
			timerScreenshot.Enabled = true;
			timerScreenshot.Interval = 1000;
			timerScreenshot.Tick += timerScreenshot_Tick;
			// 
			// cmdClearScreenshots
			// 
			cmdClearScreenshots.Location = new Point(679, 19);
			cmdClearScreenshots.Margin = new Padding(2);
			cmdClearScreenshots.Name = "cmdClearScreenshots";
			cmdClearScreenshots.Size = new Size(88, 36);
			cmdClearScreenshots.TabIndex = 0;
			cmdClearScreenshots.Text = "Clear Screenshots";
			cmdClearScreenshots.UseVisualStyleBackColor = true;
			cmdClearScreenshots.Click += cmdClearScreenshots_Click;
			// 
			// timerQuicksave
			// 
			timerQuicksave.Enabled = true;
			timerQuicksave.Interval = 2000;
			timerQuicksave.Tick += timerQuicksave_Tick;
			// 
			// lbSide0
			// 
			lbSide0.Font = new Font("Lucida Sans Typewriter", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide0.FormattingEnabled = true;
			lbSide0.Location = new Point(374, 66);
			lbSide0.Margin = new Padding(2);
			lbSide0.Name = "lbSide0";
			lbSide0.Size = new Size(276, 520);
			lbSide0.TabIndex = 1;
			lbSide0.SelectedIndexChanged += lbSide0_SelectedIndexChanged;
			// 
			// lbSide1
			// 
			lbSide1.Font = new Font("Lucida Sans Typewriter", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide1.FormattingEnabled = true;
			lbSide1.Location = new Point(652, 66);
			lbSide1.Margin = new Padding(2);
			lbSide1.Name = "lbSide1";
			lbSide1.Size = new Size(276, 520);
			lbSide1.TabIndex = 1;
			lbSide1.SelectedIndexChanged += lbSide1_SelectedIndexChanged;
			// 
			// lbSide2
			// 
			lbSide2.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide2.FormattingEnabled = true;
			lbSide2.Location = new Point(931, 66);
			lbSide2.Margin = new Padding(2);
			lbSide2.Name = "lbSide2";
			lbSide2.Size = new Size(276, 514);
			lbSide2.TabIndex = 1;
			lbSide2.SelectedIndexChanged += lbSide2_SelectedIndexChanged;
			// 
			// lbSide3
			// 
			lbSide3.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide3.FormattingEnabled = true;
			lbSide3.Location = new Point(1210, 66);
			lbSide3.Margin = new Padding(2);
			lbSide3.Name = "lbSide3";
			lbSide3.Size = new Size(276, 514);
			lbSide3.TabIndex = 1;
			// 
			// lblAdjust
			// 
			lblAdjust.BorderStyle = BorderStyle.FixedSingle;
			lblAdjust.Location = new Point(293, 19);
			lblAdjust.Margin = new Padding(2, 0, 2, 0);
			lblAdjust.Name = "lblAdjust";
			lblAdjust.Size = new Size(208, 18);
			lblAdjust.TabIndex = 2;
			lblAdjust.Text = "lblAdjust";
			lblAdjust.TextAlign = ContentAlignment.TopRight;
			// 
			// txtAdjustValue
			// 
			txtAdjustValue.Location = new Point(374, 40);
			txtAdjustValue.Margin = new Padding(2);
			txtAdjustValue.Name = "txtAdjustValue";
			txtAdjustValue.Size = new Size(45, 23);
			txtAdjustValue.TabIndex = 3;
			txtAdjustValue.TextChanged += txtAdjustValue_TextChanged;
			// 
			// cmdAdjust
			// 
			cmdAdjust.Enabled = false;
			cmdAdjust.Location = new Point(422, 38);
			cmdAdjust.Margin = new Padding(2);
			cmdAdjust.Name = "cmdAdjust";
			cmdAdjust.Size = new Size(78, 20);
			cmdAdjust.TabIndex = 4;
			cmdAdjust.Text = "Write";
			cmdAdjust.UseVisualStyleBackColor = true;
			cmdAdjust.Click += cmdAdjust_Click;
			// 
			// cboAutoRefresh
			// 
			cboAutoRefresh.Location = new Point(293, 38);
			cboAutoRefresh.Margin = new Padding(2);
			cboAutoRefresh.Name = "cboAutoRefresh";
			cboAutoRefresh.Size = new Size(52, 22);
			cboAutoRefresh.TabIndex = 5;
			cboAutoRefresh.Text = "Auto";
			cboAutoRefresh.UseVisualStyleBackColor = true;
			cboAutoRefresh.CheckedChanged += cboAutoRefresh_CheckedChanged;
			// 
			// cmdOpenSaveDir
			// 
			cmdOpenSaveDir.Location = new Point(8, 7);
			cmdOpenSaveDir.Margin = new Padding(2);
			cmdOpenSaveDir.Name = "cmdOpenSaveDir";
			cmdOpenSaveDir.Size = new Size(78, 20);
			cmdOpenSaveDir.TabIndex = 6;
			cmdOpenSaveDir.Text = "Save Dir...";
			cmdOpenSaveDir.UseVisualStyleBackColor = true;
			cmdOpenSaveDir.Click += cmdOpenSaveDir_Click;
			// 
			// lbBinaryShtuff
			// 
			lbBinaryShtuff.FormattingEnabled = true;
			lbBinaryShtuff.Location = new Point(4, 449);
			lbBinaryShtuff.Margin = new Padding(2);
			lbBinaryShtuff.Name = "lbBinaryShtuff";
			lbBinaryShtuff.Size = new Size(367, 139);
			lbBinaryShtuff.TabIndex = 7;
			// 
			// cmdRefresh
			// 
			cmdRefresh.Location = new Point(505, 38);
			cmdRefresh.Margin = new Padding(2);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.Size = new Size(78, 20);
			cmdRefresh.TabIndex = 8;
			cmdRefresh.Text = "Refresh";
			cmdRefresh.UseVisualStyleBackColor = true;
			cmdRefresh.Click += cmdRefresh_Click;
			// 
			// cmdShowDiff
			// 
			cmdShowDiff.Location = new Point(91, 7);
			cmdShowDiff.Margin = new Padding(2);
			cmdShowDiff.Name = "cmdShowDiff";
			cmdShowDiff.Size = new Size(78, 20);
			cmdShowDiff.TabIndex = 9;
			cmdShowDiff.Text = "Diff...";
			cmdShowDiff.UseVisualStyleBackColor = true;
			cmdShowDiff.Click += cmdShowDiff_Click;
			// 
			// cmdOpenSide1InNotepad
			// 
			cmdOpenSide1InNotepad.Location = new Point(214, 66);
			cmdOpenSide1InNotepad.Margin = new Padding(2);
			cmdOpenSide1InNotepad.Name = "cmdOpenSide1InNotepad";
			cmdOpenSide1InNotepad.Size = new Size(60, 32);
			cmdOpenSide1InNotepad.TabIndex = 10;
			cmdOpenSide1InNotepad.Text = "Jsons...";
			cmdOpenSide1InNotepad.UseVisualStyleBackColor = true;
			cmdOpenSide1InNotepad.Click += cmdOpenSide1InNotepad_Click;
			// 
			// cmdTestStuff
			// 
			cmdTestStuff.Location = new Point(214, 31);
			cmdTestStuff.Margin = new Padding(2);
			cmdTestStuff.Name = "cmdTestStuff";
			cmdTestStuff.Size = new Size(60, 32);
			cmdTestStuff.TabIndex = 25;
			cmdTestStuff.Text = "Testing!";
			cmdTestStuff.UseVisualStyleBackColor = true;
			cmdTestStuff.Click += cmdTestStuff_Click;
			// 
			// cmdOpenTempDir
			// 
			cmdOpenTempDir.Location = new Point(8, 31);
			cmdOpenTempDir.Margin = new Padding(2);
			cmdOpenTempDir.Name = "cmdOpenTempDir";
			cmdOpenTempDir.Size = new Size(78, 20);
			cmdOpenTempDir.TabIndex = 12;
			cmdOpenTempDir.Text = "Temp Dir...";
			cmdOpenTempDir.UseVisualStyleBackColor = true;
			cmdOpenTempDir.Click += cmdOpenTempDir_Click;
			// 
			// cboSaveAllTags
			// 
			cboSaveAllTags.Location = new Point(293, 80);
			cboSaveAllTags.Margin = new Padding(2);
			cboSaveAllTags.Name = "cboSaveAllTags";
			cboSaveAllTags.Size = new Size(75, 22);
			cboSaveAllTags.TabIndex = 13;
			cboSaveAllTags.Text = "Save tags";
			cboSaveAllTags.UseVisualStyleBackColor = true;
			// 
			// cmdClearFog
			// 
			cmdClearFog.Location = new Point(174, 7);
			cmdClearFog.Margin = new Padding(2);
			cmdClearFog.Name = "cmdClearFog";
			cmdClearFog.Size = new Size(78, 20);
			cmdClearFog.TabIndex = 14;
			cmdClearFog.Text = "Clear Fog";
			cmdClearFog.UseVisualStyleBackColor = true;
			// 
			// toolStripContainer1
			// 
			toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			toolStripContainer1.ContentPanel.Controls.Add(toolStripCities);
			toolStripContainer1.ContentPanel.Controls.Add(toolStripHeroes);
			toolStripContainer1.ContentPanel.Margin = new Padding(2);
			toolStripContainer1.ContentPanel.Size = new Size(158, 593);
			toolStripContainer1.ContentPanel.DragDrop += toolStripContainer1_ContentPanel_DragDrop;
			toolStripContainer1.Dock = DockStyle.Right;
			toolStripContainer1.LeftToolStripPanelVisible = false;
			toolStripContainer1.Location = new Point(1338, 0);
			toolStripContainer1.Margin = new Padding(2);
			toolStripContainer1.Name = "toolStripContainer1";
			toolStripContainer1.Size = new Size(158, 593);
			toolStripContainer1.TabIndex = 17;
			toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// toolStripCities
			// 
			toolStripCities.Dock = DockStyle.None;
			toolStripCities.ImageScalingSize = new Size(24, 24);
			toolStripCities.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			toolStripCities.Location = new Point(71, 189);
			toolStripCities.Name = "toolStripCities";
			toolStripCities.Size = new Size(26, 111);
			toolStripCities.TabIndex = 17;
			toolStripCities.Text = "toolStrip2";
			// 
			// toolStripHeroes
			// 
			toolStripHeroes.AllowItemReorder = true;
			toolStripHeroes.Dock = DockStyle.None;
			toolStripHeroes.ImageScalingSize = new Size(24, 24);
			toolStripHeroes.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			toolStripHeroes.Location = new Point(97, 72);
			toolStripHeroes.Name = "toolStripHeroes";
			toolStripHeroes.Size = new Size(26, 111);
			toolStripHeroes.TabIndex = 16;
			toolStripHeroes.ItemClicked += toolStripHeroes_ItemClicked;
			toolStripHeroes.DragDrop += toolStripHeroes_DragDrop;
			toolStripHeroes.DragEnter += toolStripHeroes_DragEnter;
			toolStripHeroes.MouseDown += toolStripHeroes_MouseDown;
			// 
			// timerCheckHeroToolstrip
			// 
			timerCheckHeroToolstrip.Enabled = true;
			timerCheckHeroToolstrip.Interval = 50;
			timerCheckHeroToolstrip.Tick += timerCheckHeroToolstrip_Tick;
			// 
			// lbMapProximity
			// 
			lbMapProximity.FormattingEnabled = true;
			lbMapProximity.Location = new Point(4, 104);
			lbMapProximity.Margin = new Padding(2);
			lbMapProximity.Name = "lbMapProximity";
			lbMapProximity.Size = new Size(367, 349);
			lbMapProximity.TabIndex = 7;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(8, 83);
			label1.Margin = new Padding(2, 0, 2, 0);
			label1.Name = "label1";
			label1.Size = new Size(60, 15);
			label1.TabIndex = 18;
			label1.Text = "Proximity:";
			// 
			// udProximity
			// 
			udProximity.Increment = new decimal(new int[] { 5, 0, 0, 0 });
			udProximity.Location = new Point(72, 82);
			udProximity.Margin = new Padding(2);
			udProximity.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
			udProximity.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
			udProximity.Name = "udProximity";
			udProximity.Size = new Size(46, 23);
			udProximity.TabIndex = 19;
			udProximity.Value = new decimal(new int[] { 25, 0, 0, 0 });
			// 
			// udX
			// 
			udX.Increment = new decimal(new int[] { 5, 0, 0, 0 });
			udX.Location = new Point(505, 19);
			udX.Margin = new Padding(2);
			udX.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
			udX.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
			udX.Name = "udX";
			udX.Size = new Size(46, 23);
			udX.TabIndex = 20;
			udX.Value = new decimal(new int[] { 25, 0, 0, 0 });
			udX.ValueChanged += udX_ValueChanged;
			// 
			// udZ
			// 
			udZ.Increment = new decimal(new int[] { 5, 0, 0, 0 });
			udZ.Location = new Point(555, 19);
			udZ.Margin = new Padding(2);
			udZ.Maximum = new decimal(new int[] { 400, 0, 0, 0 });
			udZ.Minimum = new decimal(new int[] { 1, 0, 0, int.MinValue });
			udZ.Name = "udZ";
			udZ.Size = new Size(46, 23);
			udZ.TabIndex = 21;
			udZ.Value = new decimal(new int[] { 25, 0, 0, 0 });
			udZ.ValueChanged += udZ_ValueChanged;
			// 
			// lblNode
			// 
			lblNode.Location = new Point(606, 22);
			lblNode.Margin = new Padding(2, 0, 2, 0);
			lblNode.Name = "lblNode";
			lblNode.Size = new Size(62, 16);
			lblNode.TabIndex = 22;
			// 
			// cmdShowMapProximity
			// 
			cmdShowMapProximity.Location = new Point(91, 31);
			cmdShowMapProximity.Margin = new Padding(2);
			cmdShowMapProximity.Name = "cmdShowMapProximity";
			cmdShowMapProximity.Size = new Size(78, 20);
			cmdShowMapProximity.TabIndex = 23;
			cmdShowMapProximity.Text = "Proximity...";
			cmdShowMapProximity.UseVisualStyleBackColor = true;
			cmdShowMapProximity.Click += cmdShowMapProximity_Click;
			// 
			// cmdScreen
			// 
			cmdScreen.Location = new Point(91, 58);
			cmdScreen.Margin = new Padding(2);
			cmdScreen.Name = "cmdScreen";
			cmdScreen.Size = new Size(78, 20);
			cmdScreen.TabIndex = 24;
			cmdScreen.Text = "Screen...";
			cmdScreen.UseVisualStyleBackColor = true;
			cmdScreen.Click += cmdScreen_Click;
			// 
			// cboAllSaveGames
			// 
			cboAllSaveGames.Location = new Point(293, 58);
			cboAllSaveGames.Margin = new Padding(2);
			cboAllSaveGames.Name = "cboAllSaveGames";
			cboAllSaveGames.Size = new Size(52, 22);
			cboAllSaveGames.TabIndex = 5;
			cboAllSaveGames.Text = "All";
			cboAllSaveGames.UseVisualStyleBackColor = true;
			cboAllSaveGames.CheckedChanged += cboAllSaveGames_CheckedChanged;
			// 
			// HeroesOEMain
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1496, 593);
			Controls.Add(cmdScreen);
			Controls.Add(cmdShowMapProximity);
			Controls.Add(lblNode);
			Controls.Add(udZ);
			Controls.Add(udX);
			Controls.Add(udProximity);
			Controls.Add(label1);
			Controls.Add(toolStripContainer1);
			Controls.Add(cmdClearFog);
			Controls.Add(cboSaveAllTags);
			Controls.Add(cmdOpenTempDir);
			Controls.Add(cmdOpenSide1InNotepad);
			Controls.Add(cmdTestStuff);
			Controls.Add(cmdShowDiff);
			Controls.Add(cmdRefresh);
			Controls.Add(lbMapProximity);
			Controls.Add(lbBinaryShtuff);
			Controls.Add(cmdOpenSaveDir);
			Controls.Add(cboAllSaveGames);
			Controls.Add(cboAutoRefresh);
			Controls.Add(cmdAdjust);
			Controls.Add(txtAdjustValue);
			Controls.Add(lblAdjust);
			Controls.Add(lbSide3);
			Controls.Add(lbSide2);
			Controls.Add(lbSide1);
			Controls.Add(lbSide0);
			Controls.Add(cmdClearScreenshots);
			Margin = new Padding(2);
			Name = "HeroesOEMain";
			Text = "Heroes Olden Era Editor";
			Load += HeroesOEMain_Load;
			toolStripContainer1.ContentPanel.ResumeLayout(false);
			toolStripContainer1.ContentPanel.PerformLayout();
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)udProximity).EndInit();
			((System.ComponentModel.ISupportInitialize)udX).EndInit();
			((System.ComponentModel.ISupportInitialize)udZ).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Timer timerScreenshot;
		private Button cmdClearScreenshots;
		private System.Windows.Forms.Timer timerQuicksave;
		private ListBox lbSide0;
		private ListBox lbSide1;
		private ListBox lbSide2;
		private ListBox lbSide3;
		private System.Windows.Forms.Timer timer1;
		private CheckBox cboAutoRefresh;
		private Button cmdOpenSaveDir;
		private ListBox lbBinaryShtuff;
		private Button cmdRefresh;
		private Button cmdShowDiff;
		private Button cmdOpenSide1InNotepad;
		private Button cmdTestStuff;
		private Button cmdShowMapProximity;
		private Button cmdOpenTempDir;
		private CheckBox cboSaveAllTags;
		private Button cmdClearFog;
		private ToolStripContainer toolStripContainer1;
		private ToolStrip toolStripCities;
		private ToolStrip toolStripHeroes;
		private System.Windows.Forms.Timer timerCheckHeroToolstrip;
		private ListBox lbMapProximity;
		private Label label1;
		private NumericUpDown udProximity;
		public TextBox txtAdjustValue;
		public Label lblAdjust;
		public Button cmdAdjust;
		public NumericUpDown udX;
		public NumericUpDown udZ;
		public Label lblNode;
		private Button cmdScreen;
		private CheckBox cboAllSaveGames;
	}
}
