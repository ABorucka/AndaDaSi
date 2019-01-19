using System.Drawing;
using System.Windows.Forms;

namespace project
{
    
    class class_character : TransparentPicture
	{
        public double Vx { get; set; } = 3;

        public double Vy { get; set; } = 5;

        public double Vx_start { get; } = 3;

        public class_character(int character)
        {
            Size = new Size(70, 50);

            Image = character == 1 ? Properties.Resources.blond_men : Properties.Resources.girl_brown;
			SizeMode = PictureBoxSizeMode.Zoom;
			Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			BackColor = Color.Transparent;
            BringToFront();
		}

        public void rotate180()
        {
			Image tmp = Image;
            tmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            Image = tmp;
		}
    }
}
