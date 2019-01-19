using System.Drawing;
using System.Windows.Forms;

namespace project
{
	class SpikeRight : PictureBox
	{
        public SpikeRight()
		{
			Image = project.Properties.Resources.spike;
			SizeMode = PictureBoxSizeMode.Zoom;
			Size = new Size(30, 30);
            BackColor = Color.Transparent;
        }

		public int X { get; set; }

        public int Y { get; set; }
    }
}
