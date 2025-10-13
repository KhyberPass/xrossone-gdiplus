using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using OpenVue.DrawingFP;
using OpenVue.Drawing;

namespace XrossGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawEllipseTest.
	/// </summary>
	public class GradientBrushTest3:GDITest
	{
		public GradientBrushTest3(MainForm form):base(form)
		{
		}
		protected override void DoXrossTest()
		{
			Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = Color.FromArgb(0xA0, Color.Black);
			Color c2 = Color.FromArgb(0xA0, Color.White);
			BrushX brush1 = new RadialGradientBrushX(r, c1, c2, 30F);
			gx.FillRectangle(brush1, r);
			r.Y += 120;
			BrushX brush2 = new RadialGradientBrushX(r, c1, c2, 80F);
			gx.FillRectangle(brush2, r);
		}
		protected override void DoNativeTest()
		{
			/*Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = Color.FromArgb(0xA0, Color.Black);
			Color c2 = Color.FromArgb(0xA0, Color.White);
			Brush brush1 = new RadialGradientBrush(r, c1, c2, 30F);
			g2.FillRectangle(brush1, r);
			r.Y += 120;
			Brush brush2 = new RadialGradientBrushX(r, c1, c2, 80F);
			g2.FillRectangle(brush2, r);*/
		}	
	}
}
