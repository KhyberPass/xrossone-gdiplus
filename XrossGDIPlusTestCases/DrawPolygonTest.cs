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
	public class DrawPolygonTest:GDITest
	{
		public DrawPolygonTest( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			Point point1 = new Point( 50,  50);
			Point point2 = new Point(85,  125);
			Point point3 = new Point(200,   45);
			Point point4 = new Point(250,  50);
			Point point5 = new Point(300, 100);
			Point point6 = new Point(70, 200);
			Point point7 = new Point(250, 250);
			Point[] curvePoints ={
									 point1,
									 point2,
									 point3,
									 point4,
									 point5,
									 point6,
									 point7
								 };
			Color c = FromArgb(0x80, Color.Green);
			PenX pen = new PenX(c, 10.5f);
			pen.LineJoin = LineJoinX.Miter;
			//gx.DrawPolygon(pen, curvePoints);
			gx.DrawLines(pen, curvePoints);

			c = FromArgb(0xA0, Color.Red);
			BrushX brush = new SolidBrushX(c);
			gx.FillPolygon(brush, curvePoints);
		}

	}
}
