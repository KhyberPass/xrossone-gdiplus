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
	public class DrawBezierTest:GDITest
	{
		public DrawBezierTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.DarkGreen);
			PenX pen = new PenX(c, 30.5f);
			pen.EndCap = LineCapX.Round;

			float startX = 100;
			float startY = 100;
			float controlX1 = 200;
			float controlY1 =  10;
			float controlX2 = 350;
			float controlY2 =  50;
			float endX = 100;
			float endY = 300;
			gx.DrawBezier(pen, startX, startY,
				controlX1, controlY1,
				controlX2, controlY2,
				endX, endY);

			c = Color.FromArgb(0xA0, Color.Firebrick);
			pen = new PenX(c, 16);
			//pen.Color = c;
			//pen.Width = 16;
			
			Point start = new Point(70, 100);
			Point control1 = new Point(200, 10);
			Point control2 = new Point(350, 50);
			Point end1 = new Point(300, 300);
			Point control3 = new Point(100, 150);
			Point control4 = new Point(150, 250);
			Point end2 = new Point(100, 50);
			Point[] bezierPoints ={
									  start, control1, control2, end1,
									  control3, control4, end2
								  };
			pen.EndCap = LineCapX.Round;
			gx.DrawBeziers(pen, bezierPoints);
		}
		protected override void DoNativeTest()
		{
			Color c = Color.FromArgb(0x80, Color.DarkGreen);
			Pen pen = new Pen(c, 30.5f);
			pen.EndCap = LineCap.Round;
			float startX = 100;
			float startY = 100;
			float controlX1 = 200;
			float controlY1 =  10;
			float controlX2 = 350;
			float controlY2 =  50;
			float endX = 100;
			float endY = 300;
			g2.DrawBezier(pen, startX, startY,
				controlX1, controlY1,
				controlX2, controlY2,
				endX, endY);

			c = Color.FromArgb(0xA0, Color.Firebrick);
			pen = new Pen(c, 16);
			Point start = new Point(70, 100);
			Point control1 = new Point(200, 10);
			Point control2 = new Point(350, 50);
			Point end1 = new Point(300, 300);
			Point control3 = new Point(100, 150);
			Point control4 = new Point(150, 250);
			Point end2 = new Point(100, 50);
			Point[] bezierPoints ={
									   start, control1, control2, end1,
									   control3, control4, end2
								   };
			pen.EndCap = LineCap.Round;
			g2.DrawBeziers(pen, bezierPoints);

		}	
	}
}
