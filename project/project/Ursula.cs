using System.Drawing;
using System.Windows.Forms;

namespace project
{
	class Ursula : TransparentPicture
	{
        public Ursula()
		{
			Image = Properties.Resources.Ursula;
			SizeMode = PictureBoxSizeMode.Zoom;
			Size = new Size(80, 80);
            BackColor = Color.Transparent;
        }

		public int X { get; set; }

        public int Y { get; set; }
    }
}
