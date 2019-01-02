using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace project
{
	class TransparentPicture : System.Windows.Forms.PictureBox
	{
		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);
			using (var gp = new GraphicsPath())
			{
				gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 0));
				this.Region = new Region(gp);
			}
		}
	}
}
