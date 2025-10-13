using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for GDITest.
	/// </summary>
	public class GDITest
	{
		const int Counts = 10;
		const int SubCounts = 10;
		protected MainForm form;
		protected GraphicsX gx = null;
		protected Graphics g1 = null,g2 = null;
		public GDITest(MainForm form)
		{
			this.form = form;
			gx = form.gx;
			g2 = form.g2;
			g1 = form.g1;
		}
		protected virtual void DoXrossOneTest()
		{
		}
		protected virtual void DoNativeTest()
		{
		}
		private String GetInfo(ArrayList times)
		{
			TimeSpan sum = new TimeSpan(0L);
			foreach(TimeSpan time in times)
			{
				sum += time;
			}

			double average = sum.TotalMilliseconds / Counts;

			double stdDevSum = 0;
			foreach(TimeSpan time in times)
			{
				stdDevSum += Math.Pow(time.TotalMilliseconds - average, 2);
			}
			return String.Format("{0}({1})ms", 
				Math.Round(average/SubCounts,3), 
				Math.Round(Math.Sqrt(stdDevSum / Counts)/SubCounts, 3));
		}
		public void StartTest()
		{
			ArrayList times1 = new ArrayList();
			ArrayList times2 = new ArrayList();
			String txt = "";
			for (int i = 0; i < Counts; i++) 
			{
				gx.Clear(Color.White);
				gx.ResetTransform();
				DateTime dt = DateTime.Now;
				for (int j = 0; j < SubCounts; j++) DoXrossOneTest();
				times1.Add(DateTime.Now - dt);
				//total += DateTime.Now.Subtract(dt).TotalMilliseconds;
			}
			txt = "XrossOne GDI+ : " + GetInfo(times1);
			form.lbl1.Text = txt;

			gx.Clear(Color.White);
			gx.ResetTransform();
			DoXrossOneTest();
			gx.Flush(g1);

			txt = "";
				for (int i = 0; i < Counts; i++) 
			{
				g2.Clear(Color.White);
				g2.ResetTransform();
				DateTime dt = DateTime.Now;
				for (int j = 0; j < SubCounts; j++) DoNativeTest();
				times2.Add(DateTime.Now - dt);
				//total += DateTime.Now.Subtract(dt).TotalMilliseconds ;
			}
			txt = "Native GDI+ : " + GetInfo(times2);
			form.lbl2.Text = txt;

			g2.Clear(Color.White);
			g2.ResetTransform();
			DoNativeTest();

			form.pb1.Invalidate();
			form.pb2.Invalidate();
		}
	}
}
