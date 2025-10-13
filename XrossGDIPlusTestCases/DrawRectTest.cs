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
	public class DrawRectTest:GDITest
	{
		public DrawRectTest( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = FromArgb(0x80, Color.DarkMagenta);
			PenX pen = new PenX(c, 10.5f);
			//pen.LineJoin = LineJoinX.Bevel;
			gx.DrawRectangle(pen, 50, 20,  150, 300);

			c = FromArgb(0xA0, Color.GreenYellow);
			BrushX brush = new SolidBrushX(c);
			gx.FillRectangle(brush, 20, 50,  300, 150);
		}
	}
}
