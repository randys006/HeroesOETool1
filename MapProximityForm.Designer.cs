namespace HOETool
{
	partial class MapProximityForm
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
			lbSquads = new ListBox();
			label1 = new Label();
			lbResources = new ListBox();
			label2 = new Label();
			lbResMines = new ListBox();
			label3 = new Label();
			SuspendLayout();
			// 
			// lbSquads
			// 
			lbSquads.FormattingEnabled = true;
			lbSquads.Location = new Point(12, 87);
			lbSquads.Name = "lbSquads";
			lbSquads.Size = new Size(263, 654);
			lbSquads.TabIndex = 0;
			lbSquads.SelectedIndexChanged += lbSquads_SelectedIndexChanged;
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new Point(9, 52);
			label1.Name = "label1";
			label1.Size = new Size(71, 25);
			label1.TabIndex = 1;
			label1.Text = "Squads";
			// 
			// lbResources
			// 
			lbResources.FormattingEnabled = true;
			lbResources.Location = new Point(281, 87);
			lbResources.Name = "lbResources";
			lbResources.Size = new Size(184, 654);
			lbResources.TabIndex = 0;
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new Point(281, 52);
			label2.Name = "label2";
			label2.Size = new Size(91, 25);
			label2.TabIndex = 1;
			label2.Text = "Resources";
			// 
			// lbResMines
			// 
			lbResMines.FormattingEnabled = true;
			lbResMines.Location = new Point(471, 87);
			lbResMines.Name = "lbResMines";
			lbResMines.Size = new Size(184, 654);
			lbResMines.TabIndex = 0;
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new Point(471, 52);
			label3.Name = "label3";
			label3.Size = new Size(135, 25);
			label3.TabIndex = 1;
			label3.Text = "Resource Mines";
			// 
			// MapProximityForm
			// 
			AutoScaleDimensions = new SizeF(10F, 25F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1134, 745);
			Controls.Add(label3);
			Controls.Add(label2);
			Controls.Add(label1);
			Controls.Add(lbResMines);
			Controls.Add(lbResources);
			Controls.Add(lbSquads);
			Name = "MapProximityForm";
			Text = "Map Objects Sorted by Proximity to Current Hero";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private ListBox lbSquads;
		private Label label1;
		private ListBox lbResources;
		private Label label2;
		private ListBox lbResMines;
		private Label label3;
	}
}