using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace project
{
	class TransparentPicture : PictureBox
	{
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			using (var gp = new GraphicsPath())
			{
				gp.AddEllipse(new Rectangle(0, 0, Width, Height));
				Region = new Region(gp);
			}
		}
	}
}
