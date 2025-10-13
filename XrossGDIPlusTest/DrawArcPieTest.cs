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
	public class DrawArcPieTest:GDITest
	{
		public DrawArcPieTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.Orange;
			PenX pen = new PenX(c, 10.7f);
			gx.DrawArc(pen, 50, 20,  150, 300, 45, -270);
			pen.Width = 17.7f;
			pen.Color = Color.FromArgb(0xA0, Color.Blue);
			pen.StartCap = LineCapX.Round;
			pen.EndCap = LineCapX.Round;
			gx.DrawArc(pen, 130.6f, 20.3f, 250.8f, 130.1f, 56.5f, 170.9f);

			c = Color.FromArgb(0xA0, Color.Red);
			BrushX brush = new SolidBrushX(c);
			gx.FillPie(brush, 130.6f, 120.3f, 250.8f, 230.1f, 126.5f, 120.9f);

			pen.Color = Color.FromArgb(0xA0, Color.HotPink);
			gx.DrawPie(pen, 30.6f, 120.3f, 250.8f, 230.1f, 156.5f, -280.9f);
		}
		protected override void DoNativeTest()
		{
			Color c = Color.Orange;
			Pen pen = new Pen(c, 10.7f);
			g2.DrawArc(pen, 50, 20,  150, 300, 45, -270);
			pen.Width = 17.7f;
			pen.Color = Color.FromArgb(0xA0, Color.Blue);
			pen.StartCap = LineCap.Round;
			pen.EndCap = LineCap.Round;
			g2.DrawArc(pen, 130.6f, 20.3f, 250.8f, 130.1f, 56.5f, 170.9f);

			c = Color.FromArgb(0xA0, Color.Red);
			Brush brush = new SolidBrush(c);
			g2.FillPie(brush, 130.6f, 120.3f, 250.8f, 230.1f, 126.5f, 120.9f);

			pen.Color = Color.FromArgb(0xA0, Color.HotPink);
			g2.DrawPie(pen, 30.6f, 120.3f, 250.8f, 230.1f, 156.5f, -280.9f);
		}	
	}
}
