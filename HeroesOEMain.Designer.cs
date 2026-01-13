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
			cmdOpenTempDir = new Button();
			cboSaveAllTags = new CheckBox();
			cmdClearFog = new Button();
			toolStripPlayerHeroes = new ToolStrip();
			toolStripPlayerCities = new ToolStrip();
			toolStripContainer1 = new ToolStripContainer();
			toolStripCities = new ToolStrip();
			toolStripHeroes = new ToolStrip();
			timerCheckHeroToolstrip = new System.Windows.Forms.Timer(components);
			toolStripContainer1.ContentPanel.SuspendLayout();
			toolStripContainer1.SuspendLayout();
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
			cmdClearScreenshots.Location = new Point(14, 16);
			cmdClearScreenshots.Name = "cmdClearScreenshots";
			cmdClearScreenshots.Size = new Size(126, 82);
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
			lbSide0.Location = new Point(534, 110);
			lbSide0.Name = "lbSide0";
			lbSide0.Size = new Size(392, 868);
			lbSide0.TabIndex = 1;
			lbSide0.SelectedIndexChanged += lbSide0_SelectedIndexChanged;
			// 
			// lbSide1
			// 
			lbSide1.Font = new Font("Lucida Sans Typewriter", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide1.FormattingEnabled = true;
			lbSide1.Location = new Point(932, 110);
			lbSide1.Name = "lbSide1";
			lbSide1.Size = new Size(392, 868);
			lbSide1.TabIndex = 1;
			lbSide1.SelectedIndexChanged += lbSide1_SelectedIndexChanged;
			// 
			// lbSide2
			// 
			lbSide2.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide2.FormattingEnabled = true;
			lbSide2.Location = new Point(1330, 110);
			lbSide2.Name = "lbSide2";
			lbSide2.Size = new Size(392, 865);
			lbSide2.TabIndex = 1;
			lbSide2.SelectedIndexChanged += lbSide2_SelectedIndexChanged;
			// 
			// lbSide3
			// 
			lbSide3.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide3.FormattingEnabled = true;
			lbSide3.Location = new Point(1728, 110);
			lbSide3.Name = "lbSide3";
			lbSide3.Size = new Size(392, 865);
			lbSide3.TabIndex = 1;
			// 
			// lblAdjust
			// 
			lblAdjust.BorderStyle = BorderStyle.FixedSingle;
			lblAdjust.Location = new Point(418, 32);
			lblAdjust.Name = "lblAdjust";
			lblAdjust.Size = new Size(297, 29);
			lblAdjust.TabIndex = 2;
			lblAdjust.Text = "lblAdjust";
			lblAdjust.TextAlign = ContentAlignment.TopRight;
			// 
			// txtAdjustValue
			// 
			txtAdjustValue.Location = new Point(534, 67);
			txtAdjustValue.Name = "txtAdjustValue";
			txtAdjustValue.Size = new Size(63, 31);
			txtAdjustValue.TabIndex = 3;
			txtAdjustValue.TextChanged += txtAdjustValue_TextChanged;
			// 
			// cmdAdjust
			// 
			cmdAdjust.Enabled = false;
			cmdAdjust.Location = new Point(603, 64);
			cmdAdjust.Name = "cmdAdjust";
			cmdAdjust.Size = new Size(112, 34);
			cmdAdjust.TabIndex = 4;
			cmdAdjust.Text = "Write";
			cmdAdjust.UseVisualStyleBackColor = true;
			cmdAdjust.Click += cmdAdjust_Click;
			// 
			// cboAutoRefresh
			// 
			cboAutoRefresh.AutoSize = true;
			cboAutoRefresh.Location = new Point(418, 110);
			cboAutoRefresh.Name = "cboAutoRefresh";
			cboAutoRefresh.Size = new Size(77, 29);
			cboAutoRefresh.TabIndex = 5;
			cboAutoRefresh.Text = "Auto";
			cboAutoRefresh.UseVisualStyleBackColor = true;
			cboAutoRefresh.CheckedChanged += cboAutoRefresh_CheckedChanged;
			// 
			// cmdOpenSaveDir
			// 
			cmdOpenSaveDir.Location = new Point(20, 134);
			cmdOpenSaveDir.Name = "cmdOpenSaveDir";
			cmdOpenSaveDir.Size = new Size(112, 34);
			cmdOpenSaveDir.TabIndex = 6;
			cmdOpenSaveDir.Text = "Save Dir...";
			cmdOpenSaveDir.UseVisualStyleBackColor = true;
			cmdOpenSaveDir.Click += cmdOpenSaveDir_Click;
			// 
			// lbBinaryShtuff
			// 
			lbBinaryShtuff.FormattingEnabled = true;
			lbBinaryShtuff.Location = new Point(6, 174);
			lbBinaryShtuff.Name = "lbBinaryShtuff";
			lbBinaryShtuff.Size = new Size(522, 629);
			lbBinaryShtuff.TabIndex = 7;
			// 
			// cmdRefresh
			// 
			cmdRefresh.Location = new Point(146, 59);
			cmdRefresh.Name = "cmdRefresh";
			cmdRefresh.Size = new Size(112, 34);
			cmdRefresh.TabIndex = 8;
			cmdRefresh.Text = "Refresh";
			cmdRefresh.UseVisualStyleBackColor = true;
			cmdRefresh.Click += cmdRefresh_Click;
			// 
			// cmdShowDiff
			// 
			cmdShowDiff.Location = new Point(146, 19);
			cmdShowDiff.Name = "cmdShowDiff";
			cmdShowDiff.Size = new Size(112, 34);
			cmdShowDiff.TabIndex = 9;
			cmdShowDiff.Text = "Diff...";
			cmdShowDiff.UseVisualStyleBackColor = true;
			cmdShowDiff.Click += cmdShowDiff_Click;
			// 
			// cmdOpenSide1InNotepad
			// 
			cmdOpenSide1InNotepad.Location = new Point(418, 67);
			cmdOpenSide1InNotepad.Name = "cmdOpenSide1InNotepad";
			cmdOpenSide1InNotepad.Size = new Size(36, 34);
			cmdOpenSide1InNotepad.TabIndex = 10;
			cmdOpenSide1InNotepad.Text = "...";
			cmdOpenSide1InNotepad.UseVisualStyleBackColor = true;
			cmdOpenSide1InNotepad.Click += cmdOpenSide1InNotepad_Click;
			// 
			// cmdOpenTempDir
			// 
			cmdOpenTempDir.Location = new Point(138, 121);
			cmdOpenTempDir.Name = "cmdOpenTempDir";
			cmdOpenTempDir.Size = new Size(112, 34);
			cmdOpenTempDir.TabIndex = 12;
			cmdOpenTempDir.Text = "Temp Dir...";
			cmdOpenTempDir.UseVisualStyleBackColor = true;
			cmdOpenTempDir.Click += cmdOpenTempDir_Click;
			// 
			// cboSaveAllTags
			// 
			cboSaveAllTags.AutoSize = true;
			cboSaveAllTags.Location = new Point(418, 139);
			cboSaveAllTags.Name = "cboSaveAllTags";
			cboSaveAllTags.Size = new Size(114, 29);
			cboSaveAllTags.TabIndex = 13;
			cboSaveAllTags.Text = "Save tags";
			cboSaveAllTags.UseVisualStyleBackColor = true;
			// 
			// cmdClearFog
			// 
			cmdClearFog.Location = new Point(264, 16);
			cmdClearFog.Name = "cmdClearFog";
			cmdClearFog.Size = new Size(112, 34);
			cmdClearFog.TabIndex = 14;
			cmdClearFog.Text = "Clear Fog";
			cmdClearFog.UseVisualStyleBackColor = true;
			// 
			// toolStripPlayerHeroes
			// 
			toolStripPlayerHeroes.AllowItemReorder = true;
			toolStripPlayerHeroes.Dock = DockStyle.None;
			toolStripPlayerHeroes.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			toolStripPlayerHeroes.ImageScalingSize = new Size(24, 24);
			toolStripPlayerHeroes.Location = new Point(176, 0);
			toolStripPlayerHeroes.Name = "toolStripPlayerHeroes";
			toolStripPlayerHeroes.Size = new Size(116, 25);
			toolStripPlayerHeroes.TabIndex = 15;
			toolStripPlayerHeroes.Text = "toolStripPlayer";
			// 
			// toolStripPlayerCities
			// 
			toolStripPlayerCities.Dock = DockStyle.None;
			toolStripPlayerCities.ImageScalingSize = new Size(24, 24);
			toolStripPlayerCities.Location = new Point(0, 0);
			toolStripPlayerCities.Name = "toolStripPlayerCities";
			toolStripPlayerCities.Size = new Size(116, 25);
			toolStripPlayerCities.TabIndex = 16;
			// 
			// toolStripContainer1
			// 
			toolStripContainer1.BottomToolStripPanelVisible = false;
			// 
			// toolStripContainer1.ContentPanel
			// 
			toolStripContainer1.ContentPanel.Controls.Add(toolStripCities);
			toolStripContainer1.ContentPanel.Controls.Add(toolStripHeroes);
			toolStripContainer1.ContentPanel.Controls.Add(toolStripPlayerHeroes);
			toolStripContainer1.ContentPanel.Size = new Size(225, 988);
			toolStripContainer1.ContentPanel.DragDrop += toolStripContainer1_ContentPanel_DragDrop;
			toolStripContainer1.Dock = DockStyle.Right;
			toolStripContainer1.LeftToolStripPanelVisible = false;
			toolStripContainer1.Location = new Point(1912, 0);
			toolStripContainer1.Name = "toolStripContainer1";
			toolStripContainer1.Size = new Size(225, 988);
			toolStripContainer1.TabIndex = 17;
			toolStripContainer1.TopToolStripPanelVisible = false;
			// 
			// toolStripCities
			// 
			toolStripCities.Dock = DockStyle.None;
			toolStripCities.ImageScalingSize = new Size(24, 24);
			toolStripCities.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			toolStripCities.Location = new Point(102, 315);
			toolStripCities.Name = "toolStripCities";
			toolStripCities.Size = new Size(27, 116);
			toolStripCities.TabIndex = 17;
			toolStripCities.Text = "toolStrip2";
			// 
			// toolStripHeroes
			// 
			toolStripHeroes.AllowItemReorder = true;
			toolStripHeroes.Dock = DockStyle.None;
			toolStripHeroes.ImageScalingSize = new Size(24, 24);
			toolStripHeroes.LayoutStyle = ToolStripLayoutStyle.VerticalStackWithOverflow;
			toolStripHeroes.Location = new Point(138, 120);
			toolStripHeroes.Name = "toolStripHeroes";
			toolStripHeroes.Size = new Size(27, 116);
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
			// HeroesOEMain
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2137, 988);
			Controls.Add(toolStripContainer1);
			Controls.Add(toolStripPlayerCities);
			Controls.Add(cmdClearFog);
			Controls.Add(cboSaveAllTags);
			Controls.Add(cmdOpenTempDir);
			Controls.Add(cmdOpenSide1InNotepad);
			Controls.Add(cmdShowDiff);
			Controls.Add(cmdRefresh);
			Controls.Add(lbBinaryShtuff);
			Controls.Add(cmdOpenSaveDir);
			Controls.Add(cboAutoRefresh);
			Controls.Add(cmdAdjust);
			Controls.Add(txtAdjustValue);
			Controls.Add(lblAdjust);
			Controls.Add(lbSide3);
			Controls.Add(lbSide2);
			Controls.Add(lbSide1);
			Controls.Add(lbSide0);
			Controls.Add(cmdClearScreenshots);
			Name = "HeroesOEMain";
			Text = "Heroes Olden Era Editor";
			Load += HeroesOEMain_Load;
			toolStripContainer1.ContentPanel.ResumeLayout(false);
			toolStripContainer1.ContentPanel.PerformLayout();
			toolStripContainer1.ResumeLayout(false);
			toolStripContainer1.PerformLayout();
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
		private Label lblAdjust;
		private System.Windows.Forms.Timer timer1;
		private TextBox txtAdjustValue;
		private Button cmdAdjust;
		private CheckBox cboAutoRefresh;
		private Button cmdOpenSaveDir;
		private ListBox lbBinaryShtuff;
		private Button cmdRefresh;
		private Button cmdShowDiff;
		private Button cmdOpenSide1InNotepad;
		private Button button1;
		private Button cmdOpenTempDir;
		private CheckBox cboSaveAllTags;
		private Button cmdClearFog;
		private ToolStrip toolStripPlayerHeroes;
		private ToolStrip toolStripPlayerCities;
		private ToolStripContainer toolStripContainer1;
		private ToolStrip toolStripCities;
		private ToolStrip toolStripHeroes;
		private System.Windows.Forms.Timer timerCheckHeroToolstrip;
	}
}
