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
	public class DrawCurveTest:GDITest
	{
		public DrawCurveTest( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			// Create pens.
			PenX pen1   = new PenX(Color.Gray, 3);
			PenX pen2 = new PenX(FromArgb(0xA0, Color.Green), 10);
			//pen2.LineJoin = LineJoinX.Round;
			// Create points that define curve.
			Point point1 = new Point( 50,  50);
			Point point2 = new Point(100,  25);
			Point point3 = new Point(200,  150);
			Point point4 = new Point(250,  50);
			Point point5 = new Point(300, 100);
			Point point6 = new Point(200, 200);
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
			// Draw lines between original points to screen.
			//gx.DrawLines(pen1, curvePoints);
			// Create offset, number of segments, and tension.
			int offset = 0;
			int numSegments = 6;
			float tension = 1f;
			// Draw curve to screen.
			gx.DrawCurve(pen2, curvePoints, offset, numSegments, tension);

			Point p1 = new Point(150,  20);
			Point p2 = new Point(100,  230);
			Point p3 = new Point(240,  150);
			Point p4 = new Point(60,  150);
			Point p5 = new Point(200,  230);
			Point[]  curvePoints2 = {
									 p1,
									 p2,
									 p3,
									 p4,
									 p5
								 };
			//gx.DrawPolygon(pen1, curvePoints2);
			pen2.Color = FromArgb(0x80, Color.Red);
			pen2.Width = 15;
			//gx.DrawClosedCurve(pen2, curvePoints2);
			BrushX brush = new SolidBrushX(FromArgb(0xA0, Color.Red));
			gx.FillClosedCurve(brush, curvePoints2);
		}
	}
}
