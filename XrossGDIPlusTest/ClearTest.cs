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
	public class ClearTest:GDITest
	{
		public ClearTest(MainForm form):base(form)
		{
		}
		protected override void DoXrossOneTest()
		{
			gx.Clear(Color.White);
		}
		protected override void DoNativeTest()
		{
			g2.Clear(Color.White);
		}	
	}
}
