using System.Drawing;
using System.Windows.Forms;

namespace project
{
    internal class Buble : TransparentPicture
	{
        public Buble()
		{
			Image = Properties.Resources.buble;
			SizeMode = PictureBoxSizeMode.Zoom;
			Size = new Size(30, 30);
		}

		public int X { get; set; }

        public int Y { get; set; }
    }
}
