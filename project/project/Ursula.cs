﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
	class Ursula : System.Windows.Forms.PictureBox
	{
		private int x;
		private int y;

		public Ursula()
		{
			this.Image = project.Properties.Resources.Ursula;
			this.SizeMode = PictureBoxSizeMode.Zoom;
			this.Size = new Size(100, 100);
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