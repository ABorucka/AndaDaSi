using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
	class SpikeLeft : System.Windows.Forms.PictureBox
	{
		private int x;
		private int y;

		public SpikeLeft()
		{
			this.Image = project.Properties.Resources.spikeLeft;
			this.SizeMode = PictureBoxSizeMode.Zoom;
			this.Size = new Size(30, 30);
		}

		public int X
		{
			get { return x; }
			set { x = value; }
		}

		public int Y
		{
			get { return y; }
			set { y = value; }
		}
	}
}
