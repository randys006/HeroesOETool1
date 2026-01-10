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
			lbSide0.ItemHeight = 18;
			lbSide0.Location = new Point(534, 110);
			lbSide0.Name = "lbSide0";
			lbSide0.Size = new Size(500, 688);
			lbSide0.TabIndex = 1;
			lbSide0.SelectedIndexChanged += lbSide0_SelectedIndexChanged;
			// 
			// lbSide1
			// 
			lbSide1.Font = new Font("Lucida Sans Typewriter", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide1.FormattingEnabled = true;
			lbSide1.ItemHeight = 18;
			lbSide1.Location = new Point(1040, 110);
			lbSide1.Name = "lbSide1";
			lbSide1.Size = new Size(500, 688);
			lbSide1.TabIndex = 1;
			lbSide1.SelectedIndexChanged += lbSide1_SelectedIndexChanged;
			// 
			// lbSide2
			// 
			lbSide2.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide2.FormattingEnabled = true;
			lbSide2.ItemHeight = 21;
			lbSide2.Location = new Point(1546, 110);
			lbSide2.Name = "lbSide2";
			lbSide2.Size = new Size(500, 676);
			lbSide2.TabIndex = 1;
			lbSide2.SelectedIndexChanged += lbSide2_SelectedIndexChanged;
			// 
			// lbSide3
			// 
			lbSide3.Font = new Font("Lucida Sans", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
			lbSide3.FormattingEnabled = true;
			lbSide3.ItemHeight = 21;
			lbSide3.Location = new Point(2258, 16);
			lbSide3.Name = "lbSide3";
			lbSide3.Size = new Size(206, 760);
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
			cmdOpenSaveDir.Location = new Point(20, 121);
			cmdOpenSaveDir.Name = "cmdOpenSaveDir";
			cmdOpenSaveDir.Size = new Size(112, 34);
			cmdOpenSaveDir.TabIndex = 6;
			cmdOpenSaveDir.Text = "SaveDir";
			cmdOpenSaveDir.UseVisualStyleBackColor = true;
			cmdOpenSaveDir.Click += cmdOpenSaveDir_Click;
			// 
			// lbBinaryShtuff
			// 
			lbBinaryShtuff.FormattingEnabled = true;
			lbBinaryShtuff.ItemHeight = 25;
			lbBinaryShtuff.Location = new Point(6, 174);
			lbBinaryShtuff.Name = "lbBinaryShtuff";
			lbBinaryShtuff.Size = new Size(522, 629);
			lbBinaryShtuff.TabIndex = 7;
			// 
			// cmdRefresh
			// 
			cmdRefresh.Location = new Point(418, 64);
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
			cmdOpenSide1InNotepad.Location = new Point(998, 69);
			cmdOpenSide1InNotepad.Name = "cmdOpenSide1InNotepad";
			cmdOpenSide1InNotepad.Size = new Size(36, 34);
			cmdOpenSide1InNotepad.TabIndex = 10;
			cmdOpenSide1InNotepad.Text = "...";
			cmdOpenSide1InNotepad.UseVisualStyleBackColor = true;
			cmdOpenSide1InNotepad.Click += cmdOpenSide1InNotepad_Click;
			// 
			// HeroesOEMain
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(2476, 810);
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
			Text = "HeroesOE Editor";
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
	}
}
