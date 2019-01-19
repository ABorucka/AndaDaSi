using System.Drawing;
using System.Windows.Forms;

namespace project
{
	class SpikeLeft : PictureBox
	{
        public SpikeLeft()
		{
			Image = Properties.Resources.spikeLeft;
			SizeMode = PictureBoxSizeMode.Zoom;
			Size = new Size(30, 30);
            BackColor = Color.Transparent;
		}

		public int X { get; set; }

        public int Y { get; set; }
    }
}
