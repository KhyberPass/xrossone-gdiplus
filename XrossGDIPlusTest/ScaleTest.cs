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
	public class ScaleTest:GDITest
	{
		public ScaleTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			PenX pen = new PenX(c, 10.5f);
			Color c1 = Color.FromArgb(0xA0, Color.Red);
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
		protected override void DoNativeTest()
		{
			Color c = Color.FromArgb(0x80, Color.BlueViolet);
			Pen pen = new Pen(c, 10.5f);
			Color c1 = Color.FromArgb(0xA0, Color.Red);
			Brush brush = new SolidBrush(c1);
			g2.FillRectangle(brush,  20, 50,  200, 120);
			g2.DrawEllipse(pen,50, 20,  150, 200);
			
			g2.ScaleTransform(1.5F, 1.3F);

			g2.FillRectangle(brush,  20, 50,  200, 120);
			g2.DrawEllipse(pen, 50, 20,  150, 200);

			g2.ScaleTransform(0.25F, 0.5F);

			g2.FillRectangle(brush,  20, 50,  200, 120);
			g2.DrawEllipse(pen, 50, 20,  150, 200);
		}	
	}
}
