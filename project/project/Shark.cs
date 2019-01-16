using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
	class Shark : TransparentPicture
	{
		private int x;
		private int y;

		public Shark()
		{
			this.Image = project.Properties.Resources.shark;
			this.SizeMode = PictureBoxSizeMode.Zoom;
			this.Size = new Size(80, 80);
            this.BackColor = Color.Transparent;
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
