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
	public class DrawBitmapTest : GDITest
	{

		public DrawBitmapTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			String filename = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
			filename = Path.GetDirectoryName(filename) + "\\..\\..\\twins.jpg";
			BitmapX bx = new BitmapX(filename);
			gx.DrawImage(bx, new Point(10, 10));
		}
		protected override void DoNativeTest()
		{
			String filename = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
			filename = Path.GetDirectoryName(filename) + "\\..\\..\\twins.jpg";
			Bitmap bm = new Bitmap(filename);
			g2.DrawImage(bm, new Point(10, 10));
		}
	}
}
