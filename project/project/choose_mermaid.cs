using System.Drawing;
using System.Windows.Forms;

namespace project
{
    class choose_mermaid : PictureBox
    {
        public choose_mermaid(Bitmap character, int ID)
        {
            Size = new Size(100, 124);
            Image = character;
            SizeMode = PictureBoxSizeMode.Zoom;
            Id = ID;
            
        }
        public int Id { get; }
    }
}
