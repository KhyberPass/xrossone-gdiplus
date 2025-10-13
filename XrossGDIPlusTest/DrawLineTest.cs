using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawLineTest.
	/// </summary>
	public class DrawLineTest : GDITest
	{
		public DrawLineTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.Black);
			PenX pen = new PenX(c, 10.5f);
			pen.EndCap = LineCapX.Triangle;
			gx.DrawLine(pen, 50, 20,  50, 300);

			c = Color.FromArgb(0xA0, Color.Blue);
			pen = new PenX(c, 0.5f);
			gx.DrawLine(pen, 100, 20,  100, 300);

			c = Color.Blue;
			pen = new PenX(c, 12.5f);
			pen.StartCap = LineCapX.Round;
			pen.EndCap = LineCapX.Square;
			gx.DrawLine(pen, 150, 20,  150, 300);

			c = Color.FromArgb(0xA0, Color.Red);
			pen.Color = c;
			gx.DrawLine(pen, 20, 20,  180, 300);
		}
		protected override void DoNativeTest()
		{
			Color c = Color.FromArgb(0x80, Color.Black);
			Pen pen = new Pen(c, 10.5f);
			pen.EndCap = LineCap.Triangle;
			g2.DrawLine(pen, 50, 20, 50, 300);

			c = Color.FromArgb(0xA0, Color.Blue);
			pen = new Pen(c, 0.5f);
			g2.DrawLine(pen, 100, 20,  100, 300);

			c = Color.Blue;
			pen = new Pen(c, 12.5f);
			pen.StartCap = LineCap.Round;
			pen.EndCap = LineCap.Square;
			g2.DrawLine(pen, 150, 20,  150, 300);

			c = Color.FromArgb(0xA0, Color.Red);
			pen.Color = c;
			g2.DrawLine(pen, 20, 20,  180, 300);
		}
	}
}
