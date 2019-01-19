using System.Drawing;
using System.Windows.Forms;

namespace project
{
	class Shark : TransparentPicture
	{
        public Shark()
		{
			Image = Properties.Resources.shark;
			SizeMode = PictureBoxSizeMode.Zoom;
			Size = new Size(80, 80);
            BackColor = Color.Transparent;
        }

		public int X { get; set; }

        public int Y { get; set; }

        public int Vy { get; set; }

        public void Shark_down(int tmpY)
        {
            Location = new Point(X, tmpY);
        }
    }
}
