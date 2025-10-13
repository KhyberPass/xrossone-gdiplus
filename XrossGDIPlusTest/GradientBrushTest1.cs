using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawEllipseTest.
	/// </summary>
	public class GradientBrushTest1:GDITest
	{
		public GradientBrushTest1(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = Color.FromArgb(0xA0, Color.Black);
			Color c2 = Color.FromArgb(0xA0, Color.White);
			BrushX brush1 = new LinearGradientBrushX(r, c1, c2, 30F);
			gx.FillRectangle(brush1, r);
			r.Y += 120;
			BrushX brush2 = new LinearGradientBrushX(r, c1, c2, 80F);
			gx.FillRectangle(brush2, r);
		}
		protected override void DoNativeTest()
		{
			Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = Color.FromArgb(0xA0, Color.Black);
			Color c2 = Color.FromArgb(0xA0, Color.White);
			Brush brush1 = new LinearGradientBrush(r, c1, c2, 30F);
			g2.FillRectangle(brush1, r);
			r.Y += 120;
			Brush brush2 = new LinearGradientBrush(r, c1, c2, 80F);
			g2.FillRectangle(brush2, r);
		}	
	}
}
