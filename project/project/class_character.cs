using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    
    class class_character : PictureBox
    {
        private double vx = 2;
        private double vy = 3;
       // private Bitmap bitmap;
       // private int control = 0;
       // private bool alive = true;
       /* public int Control
        {
            get
            {
                return control;
            }
            set
            {
                control = value;
            }
        }
        public bool Alive
        {
            get
            {
                return alive;
            }
            set
            {
                alive = value;
            }
        }*/
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

        public class_character(Image character)
        {
            this.Size = new Size(70, 50);
            this.Image = character;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            this.Image.RotateFlip(RotateFlipType.Rotate270FlipX);
        }

        public void rotate180()
        {
            Image tmp= this.Image;
            tmp.RotateFlip(RotateFlipType.Rotate180FlipNone);
            this.Image = tmp;
        }
    }
}
