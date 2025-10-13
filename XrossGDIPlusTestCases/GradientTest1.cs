using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawEllipseTest.
	/// </summary>
	public class GradientTest1:GDITest
	{
		public GradientTest1( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = FromArgb(0xA0, Color.Black);
			Color c2 = FromArgb(0xA0, Color.White);
			BrushX brush1 = new LinearGradientBrushX(r, c1, c2, 30F);
			gx.FillRectangle(brush1, r);
			r.Y += 120;
			BrushX brush2 = new LinearGradientBrushX(r, c1, c2, 80F);
			gx.FillRectangle(brush2, r);
		}
	}
}
