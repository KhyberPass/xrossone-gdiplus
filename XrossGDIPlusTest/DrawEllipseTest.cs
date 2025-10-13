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
	public class DrawEllipseTest:GDITest
	{
		public DrawEllipseTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			PenX pen = new PenX(c, 10.5f);
			gx.DrawEllipse(pen, 50, 20,  150, 300);

			c = Color.FromArgb(0xA0, Color.Red);
			BrushX brush = new SolidBrushX(c);
			gx.FillEllipse(brush, 20, 50,  30, 50);
		}
		protected override void DoNativeTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			Pen pen = new Pen(c, 10.5f);
			g2.DrawEllipse(pen, 50, 20, 150, 300);

			c = Color.FromArgb(0xA0, Color.Red);
			Brush brush = new SolidBrush(c);
			g2.FillEllipse(brush, 20, 50,   30, 50);
		}	
	}
}
