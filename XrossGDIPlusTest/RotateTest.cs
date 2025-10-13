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
	public class RotateTest:GDITest
	{
		public RotateTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			PenX pen = new PenX(c, 10.5f);
			Color c1 = Color.FromArgb(0xA0, Color.Red);
			BrushX brush = new SolidBrushX(c1);
			gx.FillRectangle(brush, 120, 150,  200, 120);
			gx.DrawEllipse(pen, 150, 120,  150, 200);

			gx.RotateTransform(30);

			gx.FillRectangle(brush,  120, 150,  200, 120);
			gx.DrawEllipse(pen, 150, 120,  150, 200);

			gx.RotateTransform(-78);

			gx.FillRectangle(brush,  120, 150,  200, 120);
			gx.DrawEllipse(pen, 150, 120,  150, 200);
		}
		protected override void DoNativeTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			Pen pen = new Pen(c, 10.5f);
			Color c1 = Color.FromArgb(0xA0, Color.Red);
			Brush brush = new SolidBrush(c1);
			g2.FillRectangle(brush,  120, 150,  200, 120);
			g2.DrawEllipse(pen,150, 120,  150, 200);
			
			g2.RotateTransform(30);

			g2.FillRectangle(brush,  120, 150,  200, 120);
			g2.DrawEllipse(pen,150, 120,  150, 200);

			g2.RotateTransform(-78);

			g2.FillRectangle(brush,  120, 150,  200, 120);
			g2.DrawEllipse(pen,150, 120,  150, 200);
		}	
	}
}
