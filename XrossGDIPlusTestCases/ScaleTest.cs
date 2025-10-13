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
	public class ScaleTest:GDITest
	{
		public ScaleTest( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = FromArgb(0x80, Color.BlueViolet);
			PenX pen = new PenX(c, 10.5f);
			Color c1 = FromArgb(0xA0, Color.Red);
			BrushX brush = new SolidBrushX(c1);
			gx.FillRectangle(brush, 20, 50,  200, 120);
			gx.DrawEllipse(pen, 50, 20,  150, 200);

			gx.ScaleTransform(1.5F, 1.3F);

			gx.FillRectangle(brush,  20, 50,  200, 120);
			gx.DrawEllipse(pen, 50, 20,  150, 200);

			gx.ScaleTransform(0.25F, 0.5F);

			gx.FillRectangle(brush,  20, 50,  200, 120);
			gx.DrawEllipse(pen, 50, 20,  150, 200);
		}
	}
}
