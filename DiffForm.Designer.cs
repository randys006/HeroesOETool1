namespace HOETool
{
	partial class DiffForm
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
			lbLeft = new ListBox();
			lbRite = new ListBox();
			cmdOpenLeft = new Button();
			cmdRefreshLeft = new Button();
			txtLeftFile = new TextBox();
			txtRightFile = new TextBox();
			cmdOpenRight = new Button();
			cmdRefreshRight = new Button();
			openFileDialog1 = new OpenFileDialog();
			SuspendLayout();
			// 
			// lbLeft
			// 
			lbLeft.FormattingEnabled = true;
			lbLeft.ItemHeight = 25;
			lbLeft.Location = new Point(12, 87);
			lbLeft.Name = "lbLeft";
			lbLeft.Size = new Size(606, 704);
			lbLeft.TabIndex = 0;
			lbLeft.Tag = "Left";
			// 
			// lbRight
			// 
			lbRite.FormattingEnabled = true;
			lbRite.ItemHeight = 25;
			lbRite.Location = new Point(624, 88);
			lbRite.Name = "lbRight";
			lbRite.Size = new Size(606, 704);
			lbRite.TabIndex = 1;
			lbRite.Tag = "Right";
			// 
			// cmdOpenLeft
			// 
			cmdOpenLeft.Location = new Point(12, 12);
			cmdOpenLeft.Name = "cmdOpenLeft";
			cmdOpenLeft.Size = new Size(112, 34);
			cmdOpenLeft.TabIndex = 2;
			cmdOpenLeft.Tag = "Left";
			cmdOpenLeft.Text = "Left...";
			cmdOpenLeft.UseVisualStyleBackColor = true;
			cmdOpenLeft.Click += cmdOpenLeft_Click;
			// 
			// cmdRefreshLeft
			// 
			cmdRefreshLeft.Location = new Point(12, 48);
			cmdRefreshLeft.Name = "cmdRefreshLeft";
			cmdRefreshLeft.Size = new Size(112, 34);
			cmdRefreshLeft.TabIndex = 3;
			cmdRefreshLeft.Text = "Refresh";
			cmdRefreshLeft.UseVisualStyleBackColor = true;
			cmdRefreshLeft.Click += cmdRefreshLeft_Click;
			// 
			// txtLeftFile
			// 
			txtLeftFile.Location = new Point(130, 14);
			txtLeftFile.Multiline = true;
			txtLeftFile.Name = "txtLeftFile";
			txtLeftFile.Size = new Size(488, 70);
			txtLeftFile.TabIndex = 4;
			txtLeftFile.Tag = "Left";
			// 
			// txtRightFile
			// 
			txtRightFile.Location = new Point(742, 12);
			txtRightFile.Multiline = true;
			txtRightFile.Name = "txtRightFile";
			txtRightFile.Size = new Size(488, 70);
			txtRightFile.TabIndex = 4;
			txtRightFile.Tag = "Right";
			// 
			// cmdOpenRight
			// 
			cmdOpenRight.Location = new Point(624, 14);
			cmdOpenRight.Name = "cmdOpenRight";
			cmdOpenRight.Size = new Size(112, 34);
			cmdOpenRight.TabIndex = 2;
			cmdOpenRight.Text = "Right...";
			cmdOpenRight.UseVisualStyleBackColor = true;
			cmdOpenRight.Click += cmdOpenRight_Click;
			// 
			// cmdRefreshRight
			// 
			cmdRefreshRight.Location = new Point(624, 50);
			cmdRefreshRight.Name = "cmdRefreshRight";
			cmdRefreshRight.Size = new Size(112, 34);
			cmdRefreshRight.TabIndex = 3;
			cmdRefreshRight.Text = "Refresh";
			cmdRefreshRight.UseVisualStyleBackColor = true;
			cmdRefreshRight.Click += cmdRefreshRight_Click;
			// 
			// openFileDialog1
			// 
			openFileDialog1.AddExtension = false;
			openFileDialog1.FileName = "openFileDialog1";
			openFileDialog1.Filter = "HOE Saves|*.saveskirmish|All files|*.*";
			// 
			// DiffForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1238, 804);
			Controls.Add(txtRightFile);
			Controls.Add(txtLeftFile);
			Controls.Add(cmdRefreshRight);
			Controls.Add(cmdRefreshLeft);
			Controls.Add(cmdOpenRight);
			Controls.Add(cmdOpenLeft);
			Controls.Add(lbRite);
			Controls.Add(lbLeft);
			Name = "DiffForm";
			Text = "DiffForm";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox lbLeft;
		private ListBox lbRite;
		private Button cmdOpenLeft;
		private Button cmdRefreshLeft;
		private TextBox txtLeftFile;
		private TextBox txtRightFile;
		private Button cmdOpenRight;
		private Button cmdRefreshRight;
		private OpenFileDialog openFileDialog1;
	}
}