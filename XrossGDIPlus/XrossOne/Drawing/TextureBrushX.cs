using System;
using System.Drawing;
using XrossOne.DrawingFP;
using XrossOne.FixedPoint;

namespace XrossOne.Drawing
{
	/// <summary>
	/// Summary description for TextureBrushX.
	/// </summary>
	public class TextureBrushX : BrushFP, BrushX
	{
		private int ff_xstep, ff_ystep, ff_cx, ff_cy;
		private int xs, ys;
		private BitmapX bitmap;
		const int HALF = SingleFP.One >> 1;
		internal ImageAttributesX imageAttributes = null;
		public TextureBrushX(BitmapX bm)
		{
			xs = ys = 0;
			bitmap = bm;
		}
		public TextureBrushX(BitmapX bm, Rectangle rc)
		{
			xs = rc.Left;
			ys = rc.Top;
			if (bm.Width == rc.Width && bm.Height == rc.Height)
				bitmap = bm;
			else
				bitmap = BitmapX.ResizeBitmap(bm, rc.Width, rc.Height);
		}
		public BrushFP WrappedBrush
		{
			get
			{
				return this;
			}
		}
		public override bool MonoColor
		{
			get
			{
				return false;
			}
		}
		private int FilterColor(Color c)
		{
			int color = c.ToArgb();
			return color | unchecked((int)0xFF000000);
		}
		public override void GetColorAt(int x, int y, int[] colors, int count)
		{
			PointFP p = new PointFP(x << SingleFP.DecimalBits, y << SingleFP.DecimalBits);
			int w = bitmap.Width;
			int h = bitmap.Height;
			if (count > 1)
			{
				PointFP p1 = new PointFP(p.X + SingleFP.One * count, p.Y);
				if (finalMatrix != null)
				{
					p.Transform(finalMatrix);
					p1.Transform(finalMatrix);
				}
				ff_xstep = (p1.X - p.X) / count;
				ff_ystep = (p1.Y - p.Y) / count;
				ff_cx = p.X;
				ff_cy = p.Y;
				for (int i = 0; i < count; i++, ff_cx += ff_xstep, ff_cy += ff_ystep)
				{
					int xx = (ff_cx >> SingleFP.DecimalBits) - xs;
					int yy = (ff_cy >> SingleFP.DecimalBits) - ys; 
					xx = xx < 0 ? 0 : xx >= w ? w - 1 : xx;
					yy = yy < 0 ? 0 : yy >= h ? h - 1 : yy;
					int c = bitmap.GetPixel(xx, yy).ToArgb() & 0xFFFFFF;
					if (imageAttributes != null &&
						imageAttributes.colorLow <= c && 
						imageAttributes.colorHigh >= c) 
						colors[i] = 0;
					else
						colors[i] = c | unchecked((int)0xFF000000);
				}
			}
			else
			{
				if (finalMatrix != null) p.Transform(finalMatrix);
				ff_cx = p.X;
				ff_cy = p.Y;
				int xx = (ff_cx >> SingleFP.DecimalBits) - xs;
				int yy = (ff_cy >> SingleFP.DecimalBits) - ys; 
				xx = xx < 0 ? 0 : xx >= w ? w - 1 : xx;
				yy = yy < 0 ? 0 : yy >= h ? h - 1 : yy;
				int c = bitmap.GetPixel(xx, yy).ToArgb() & 0xFFFFFF;
				if (imageAttributes != null &&
					imageAttributes.colorLow <= c && 
					imageAttributes.colorHigh >= c) 
					colors[0] = 0;
				else
					colors[0] = c | unchecked((int)0xFF000000);
			}
		}
	}
}