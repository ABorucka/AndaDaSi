using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
    class choose_mermaid : PictureBox
    {
        private int id;

        public choose_mermaid(Bitmap character, int ID)
        {
            this.Size = new Size(100, 124);
            this.Image = character;
            this.SizeMode = PictureBoxSizeMode.Zoom;
            id = ID;
            
        }
        public int Id
        {
            get { return id; }
        }
    }
}
