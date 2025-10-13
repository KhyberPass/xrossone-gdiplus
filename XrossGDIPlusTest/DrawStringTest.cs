using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using XrossOne.DrawingFP;
using XrossOne.Drawing;
using System.Reflection;
using System.IO;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawLineTest.
	/// </summary>
	public class DrawStringTest : GDITest
	{
		String text = "Hello world";
		public DrawStringTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			FontX font = new FontX("Arial", 36, FontStyle.Italic | FontStyle.Underline);
			Size size = gx.MeasureString(text, font);
			Rectangle r = new Rectangle(20, 50,  20 + size.Width, 50 + size.Height);
			Color c1 = Color.Blue;
			Color c2 = Utils.FromArgb(0x40, Color.Gray);
			BrushX brush1 = new LinearGradientBrushX(r, c1, c2, 0);
			gx.DrawString(text, font, brush1, 10, 30);
			gx.DrawString("TO", new FontX("Microsoft Sans Serif", 64, FontStyle.Regular), 
				new SolidBrushX(Utils.FromArgb(0xA0, Color.Green)), 1, 100);
			gx.DrawString("Hello world", new FontX("Arial", 36, FontStyle.Regular), 
				new SolidBrushX(Utils.FromArgb(0x80, Color.Red)), 1, 1);
			gx.DrawString("XrossOne Studio", new FontX("Arial", 12, FontStyle.Regular), 
				new SolidBrushX(Color.BlueViolet), 30, 200);
		}
		protected override void DoNativeTest()
		{
			Font font = new Font("Arial", 36, FontStyle.Italic | FontStyle.Underline);
			SizeF size = g2.MeasureString(text, font);
			Rectangle r = new Rectangle(20, 50,  20 + (int)size.Width, 50 + (int)size.Height);
			Color c1 = Color.Blue;
			Color c2 = Color.FromArgb(0x40, Color.Gray);
			LinearGradientBrush brush1 = new LinearGradientBrush(r, c1, c2, 0F);
			g2.DrawString(text, font, brush1, 10, 30);
			g2.DrawString("TO", new Font("Microsoft Sans Serif", 64, FontStyle.Regular), 
				new SolidBrush(Utils.FromArgb(0xA0, Color.Green)), 1, 100);
			g2.DrawString("Hello world", new Font("Arial", 36, FontStyle.Regular), 
				new SolidBrush(Utils.FromArgb(0x80, Color.Red)), 1, 1);
			g2.DrawString("XrossOne Studio", new Font("Arial", 12, FontStyle.Regular), 
				new SolidBrush(Color.BlueViolet), 30, 200);
		}
	}
}
