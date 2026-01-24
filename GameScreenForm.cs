using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOETool
{
	public partial class GameScreenForm : Form
	{
		public GameScreenForm()
		{
			InitializeComponent();
		}

		private void CaptureMyScreen()
		{
			try
			{
				// Define the area of the screen to capture (e.g., the primary screen's bounds)
				Rectangle bounds = Screen.PrimaryScreen.Bounds;

				// Create a new Bitmap object with the same dimensions as the screen area
				Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height);

				// Create a Graphics object from the bitmap
				using (Graphics g = Graphics.FromImage(bitmap))
				{
					// Copy the screen data to the Graphics object
					// Parameters: sourceX, sourceY, destX, destY, size, copyPixelOperation
					g.CopyFromScreen(
						bounds.X,
						bounds.Y,
						0,
						0,
						bounds.Size,
						CopyPixelOperation.SourceCopy
					);
				}

				// Display the captured image in the PictureBox control
				pictureBoxScreen.Image = bitmap;

				// Optional: Adjust PictureBox properties for better display
				pictureBoxScreen.SizeMode = PictureBoxSizeMode.Zoom;
			}
			catch (Exception ex)
			{
				MessageBox.Show("An error occurred: " + ex.Message);
			}
		}

		private void timerCapture_Tick(object sender, EventArgs e)
		{
			if (!this.IsDisposed)
				CaptureMyScreen();
		}

		//		Alternative: Capture Only the Current Form
		//		If you only want to capture the contents of the current form itself(without other overlapping windows or the rest of the desktop), you can use the Control.DrawToBitmap method instead.
		//		csharp
		//private void CaptureForm()
		//		{
		//			// Create a Bitmap with the form's dimensions
		//			Bitmap bitmap = new Bitmap(this.Width, this.Height);

		//			// Draw the form's content onto the Bitmap
		//			this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));

		//			// Display the captured image in the PictureBox
		//			pictureBoxScreen.Image = bitmap;
		//			pictureBoxScreen.SizeMode = PictureBoxSizeMode.Zoom;
		//		}
	}
}
