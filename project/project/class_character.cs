using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    
    class class_character : TransparentPicture
	{
        private double vx = 2;
        private double vy = 5;
       
        public double Vx
        {
            get
            {
                return vx;
            }
            set
            {
                vx = value;
            }
        }
        public double Vy
        {
            get
            {
                return vy;
            }
            set
            {
                vy = value;
            }
        }

        public class_character(int character)
        {
            this.Size = new Size(70, 50);

            if (character == 1)
                this.Image = Properties.Resources.blond_men;
            else
                this.Image = Properties.Resources.girl_brown;
			this.SizeMode = PictureBoxSizeMode.Zoom;
			this.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
			this.BackColor = Color.Transparent;
            this.BringToFront();
		}

        public void rotate180()
        {
			Image tmp = this.Image;
            tmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.Image = tmp;
		}
    }
}
