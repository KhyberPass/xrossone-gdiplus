using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for GDITest.
	/// </summary>
	public class GDITest
	{
		const int Counts = 1;
		const int SubCounts = 1;
		protected GraphicsX gx = null;
		public GDITest(GraphicsX gx)
		{
			this.gx = gx;
		}
		protected virtual void DoXrossOneTest()
		{
		}
		private String GetInfo(TimeSpan[] times)
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
			return String.Format("{0}ms", 
				Math.Round(average/SubCounts,3));
		}
		public Color FromArgb(int alpha, Color c)
		{
			int color =  c.ToArgb();
			color = (alpha << 24) | (color & 0xFFFFFF);
			return Color.FromArgb(color);
		}
		public String StartTest()
		{
			TimeSpan[] times1 = new TimeSpan[Counts];
			for (int i = 0; i < Counts; i++) 
			{
				gx.Clear(Color.White);
				gx.ResetTransform();
				DateTime dt = DateTime.Now;
				for (int j = 0; j < SubCounts; j++) DoXrossOneTest();
				times1[i] = (DateTime.Now - dt);
				//total += DateTime.Now.Subtract(dt).TotalMilliseconds;
			}
			gx.Clear(Color.White);
			gx.ResetTransform();
			DoXrossOneTest();
			//gx.Flush(graphics);
			return GetInfo(times1);
		}
	}
}
