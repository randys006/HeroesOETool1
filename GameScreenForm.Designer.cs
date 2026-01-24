namespace HOETool
{
	partial class GameScreenForm
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
			components = new System.ComponentModel.Container();
			pictureBoxScreen = new PictureBox();
			timerCapture = new System.Windows.Forms.Timer(components);
			((System.ComponentModel.ISupportInitialize)pictureBoxScreen).BeginInit();
			SuspendLayout();
			// 
			// pictureBoxScreen
			// 
			pictureBoxScreen.Dock = DockStyle.Fill;
			pictureBoxScreen.Location = new Point(0, 0);
			pictureBoxScreen.Name = "pictureBoxScreen";
			pictureBoxScreen.Size = new Size(800, 450);
			pictureBoxScreen.TabIndex = 0;
			pictureBoxScreen.TabStop = false;
			// 
			// timerCapture
			// 
			timerCapture.Interval = 250;
			timerCapture.Tick += timerCapture_Tick;
			// 
			// GameScreen
			// 
			AutoScaleDimensions = new SizeF(7F, 15F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(800, 450);
			Controls.Add(pictureBoxScreen);
			Name = "GameScreen";
			Text = "GameScreen";
			((System.ComponentModel.ISupportInitialize)pictureBoxScreen).EndInit();
			ResumeLayout(false);
		}

		#endregion

		private PictureBox pictureBoxScreen;
		public System.Windows.Forms.Timer timerCapture;
	}
}