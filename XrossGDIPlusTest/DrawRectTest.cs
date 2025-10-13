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
	public class DrawRectTest:GDITest
	{
		public DrawRectTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.DarkMagenta);
			PenX pen = new PenX(c, 10.5f);
			//pen.LineJoin = LineJoinX.Bevel;
			gx.DrawRectangle(pen, 50, 20,  150, 300);

			c = Color.FromArgb(0xA0, Color.GreenYellow);
			BrushX brush = new SolidBrushX(c);
			gx.FillRectangle(brush, 20, 50,  300, 150);
		}
		protected override void DoNativeTest()
		{
			//g2.Clear(Color.White);
			Color c = Color.FromArgb(0x80, Color.DarkMagenta);
			Pen pen = new Pen(c, 10.5f);
			g2.DrawRectangle(pen, 50, 20, 150, 300);

			c = Color.FromArgb(0xA0, Color.GreenYellow);
			Brush brush = new SolidBrush(c);
			g2.FillRectangle(brush, 20, 50,  300, 150);
		}	
	}
}
