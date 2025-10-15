/*

Copyright (C) 2004 XrossOne Studio (www.xrossone.com), All rights reserved.
Author : Xinjie ZHANG (xjzhang@xrossone.com)

This license governs use of the accompanying software ("Software"), and your use
of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose, including
distributing derivative works.

In return, we simply require that you agree:
1.	Not to remove any copyright or other notices from the Software.
2.	That if you distribute the Software in source code form you do so only under
this license (i.e. you must include a complete copy of this license with your
distribution), and if you distribute the Software solely in object form you only
do so under a license that complies with this license.
3.	That the Software comes "as is", with no warranties. None whatsoever. This
means no express, implied or statutory warranty, including without limitation,
warranties of merchantability or fitness for a particular purpose or any
warranty of title or non-infringement. Also, you must pass this disclaimer on
whenever you distribute the Software or derivative works.
4.	That XrossOne Studio will not be liable for any of those types of damages known 
as indirect, special, consequential, or incidental related to the Software or this
license, to the maximum extent the law permits, no matter what legal theory it's
based on. Also, you must pass this limitation of liability on whenever you distribute 
the Software or derivative works.
5.	That if you sue anyone over patents that you think may apply to the Software
for a person's use of the Software, your license to the Software ends
automatically.
6.	That the patent rights, if any, granted in this license only apply to the
Software, not to any derivative works you make.
7.	That your rights under this License end automatically if you breach it in
any way.
8.	That all rights not expressly granted to you in this license are reserved.

*/

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using XrossOne.DrawingFP;
using XrossOne.FixedPoint;
using XrossOne.Gdi;

namespace XrossOne.Drawing
{
	public class GraphicsX
	{
		private GraphicsFP graphics;
		private MatrixX matrix = null;
		public GraphicsX(int width, int height)
		{
			Resize(width, height);
		}
		public GraphicsX(GraphicsX g)
		{
			int w = g.graphics.Buffer.Width;
			int h = g.graphics.Buffer.Height;
			Resize(w, h);
			for (int i = 0; i < w; i ++)
				for (int j = 0; j < h; j++)
					graphics.Buffer[i, j] = g.graphics.Buffer[i, j];
		}
		public BitmapX ToBitmapX()
		{
			int w = graphics.Buffer.Width;
			int h = graphics.Buffer.Height;
			BitmapX bm = new BitmapX(w, h);
			for (int i = 0; i < w; i ++)
				for (int j = 0; j < h; j++)
					bm[i, j] = graphics.Buffer[i, j];
			return bm;
		}
		public GraphicsFP WrappedGraphics
		{
			get
			{
				return graphics;
			}
		}
		public void Resize(int width, int height)
		{
			lock(this)
			{
				//graphics = new GraphicsFP(new DIBGraphicsBuffer(width, height));
				graphics = new GraphicsFP(width, height);
			}
		}
		
		public void Clear (Color color)
		{
			lock(this)
			{
				graphics.Clear(color.ToArgb());
			}
		}

		/*public void DrawString (string s, FontX font, BrushX brush, RectangleF layoutRectangle)
		{			
		}*/
		
		public void DrawString (string s, FontX font, BrushX brush, Point point)
		{
			DrawString(s, font, brush, point.X, point.Y);
		}
		private class TextBrushX : TextureBrushX
		{
			private BrushFP brush;
			private int[] colorsText;
			private int[] colorsBrush;
			public TextBrushX(BrushFP br, BitmapX bm, Rectangle rc) : base(bm, rc)
			{
				brush = br;
				colorsText	= new int[rc.Width + rc.Height];
				colorsBrush = new int[rc.Width + rc.Height];
			}
			public override void GetColorAt(int x, int y, int[] colors, int count)
			{
				base.GetColorAt(x, y, colorsText, count);
				if (brush.MonoColor)
				{
					brush.GetColorAt(x, y, colorsBrush, 1);
					for (int i = 0; i < count; i ++)
						colors[i] = (colorsText[i] & 0xFFFFFF) == 0xFFFFFF ? 0 : colorsBrush[0];
				}
				else
				{
					brush.GetColorAt(x, y, colorsBrush, count);
					for (int i = 0; i < count; i ++)
						colors[i] = (colorsText[i] & 0xFFFFFF) == 0xFFFFFF ? 0 : colorsBrush[i];
				}
			}
		}

		public void DrawString (string s, FontX font, BrushX brush, int x, int y)
		{
			if (x > graphics.renderer.Width || y > graphics.renderer.Height) return;

			Size size			= MeasureString(s, font);
			BitmapX buffer		= new BitmapX(size.Width + size.Height, size.Height);
			buffer.Clear(Color.White);

			IntPtr hDC			= GdiHelper.GetDC(GdiHelper.GetActiveWindow());
			IntPtr hdcTemp		= GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hBitmapOld	= GdiHelper.SelectObject(hdcTemp, buffer.GetHbitmap());
			IntPtr hFontOld		= GdiHelper.SelectObject(hdcTemp, font.hFont);
			GdiRectangle rc		= new GdiRectangle();
			rc.Left				= 0;
			rc.Top				= 0;
			rc.Right			= size.Width + size.Height;
			rc.Bottom			= size.Height;
			GdiHelper.SetTextColor(hdcTemp, 0);
			GdiHelper.SetBkColor(hdcTemp, 0xFFFFFF);
			GdiHelper.SetBkMode(hdcTemp, (int)GdiBackgroundMode.Transparent);
			GdiHelper.DrawText(hdcTemp, s, ref rc, GdiTextFormat.Left | GdiTextFormat.Top);
			GdiHelper.SelectObject(hdcTemp, hFontOld);
			GdiHelper.SelectObject(hdcTemp, hBitmapOld);
			GdiHelper.DeleteDC(hdcTemp);
			GdiHelper.ReleaseDC(GdiHelper.GetActiveWindow(), hDC);
		
			int w = Math.Min(graphics.renderer.Width - x, buffer.Width);
			int h = Math.Min(graphics.renderer.Height - y, buffer.Height);
/*			for (int i = 0; i < h; i++)
			{
				for (int j = 0; j < w; j++)	
				{
					//int currColor = buffer[j, i] & 0xFFFFFF;
					if (buffer[j, i] == 0)
					{
						int cx = x + j;
						int cy = y + i;
						int cc = graphics.Buffer[cx, cy];
						graphics.Buffer[cx, cy] = XrossOne.DrawingFP.GraphicsPathRenderer.Merge(
							cc, brush.WrappedBrush.GetColorAt(cx, cy, true));
					}
				}
			}
			graphics.Buffer.IsDirty = true;
*/			
			Rectangle rect = new Rectangle(x, y, buffer.Width, buffer.Height);

            // Draws anti-aliased black text but with white background
            //TextureBrushX br = new TextureBrushX(buffer, rect);

            // Draws mono color text where all the anti-aliasing is 
            // converted to a mono color, but the background is transparent
            TextBrushX br = new TextBrushX(brush.WrappedBrush, buffer, rect);

			FillRectangle(br, rect);
			buffer.Dispose();

			//DrawImage(buffer, new Point(x, y));
			
		}
		
		public Size MeasureString(string text, FontX font)
		{
			GdiSize sz = new GdiSize();
			IntPtr hDC = GdiHelper.GetDC(GdiHelper.GetActiveWindow());
			IntPtr hdcTemp = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			GdiRectangle rc = new GdiRectangle();
			IntPtr hFontOld = GdiHelper.SelectObject(hdcTemp, font.hFont);
			GdiHelper.DrawText(hdcTemp, text, ref rc, 
				GdiTextFormat.Left | GdiTextFormat.Top | GdiTextFormat.CalcRect); 
			GdiHelper.SelectObject(hdcTemp, hFontOld);
			GdiHelper.DeleteDC(hdcTemp);
			GdiHelper.ReleaseDC(GdiHelper.GetActiveWindow(), hDC);
			return new Size(rc.Right - rc.Left, rc.Bottom - rc.Top);
		}

		/*
		public void DrawImage(BitmapX image, Point point, Color transparentColor)
		{
			int w = Math.Min(graphics.renderer.Width - point.X, image.Width);
			int h = Math.Min(graphics.renderer.Height - point.Y, image.Height);
			for (int y = 0; y < h; y++)
			{
				//int index = point.X + (point.Y + y) * graphics.renderer.Width;
				if (transparentColor == Color.Empty)
				{
					for (int x = 0; x < w; x++)
						graphics.Buffer[point.X + x, point.Y + y] = image[x, y];
				}
				else
				{
					int c = transparentColor.ToArgb() & 0xFFFFFF;
					for (int x = 0; x < w; x++)	
					{
						int currColor = image[x, y] & 0xFFFFFF;
						if (c != currColor)
							graphics.Buffer[point.X + x, point.Y + y] = currColor;
					}
				}
			}
			graphics.Buffer.IsDirty = true;
		}
		public void DrawImage(BitmapX image, Point point)
		{
			DrawImage(image, point, Color.Empty);
		}*/
		
		public void DrawImage(BitmapX image, Point point)
		{
			DrawImage(image, new Rectangle(point.X, point.Y, image.Width , image.Height));
		}
		public void DrawImage(BitmapX image, Point point, ImageAttributesX imageAttributes)
		{
			DrawImage(image, new Rectangle(point.X, point.Y, image.Width , image.Height), imageAttributes);
		}
		public void DrawImage(BitmapX image, Rectangle rect)
		{
			DrawImage(image, rect, null);
		}
		public void DrawImage(BitmapX image, Rectangle rect, ImageAttributesX imageAttributes)
		{
			TextureBrushX br = new TextureBrushX(image, rect);
			br.imageAttributes = imageAttributes;
			FillRectangle(br, rect);
		}
		public void DrawArc (PenX pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			DrawArc (pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		public void DrawArc (PenX pen, RectangleF rect, float startAngle, float sweepAngle)
		{
			DrawArc (pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		public void DrawArc (PenX pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			DrawArc(pen, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
		}

		public void DrawArc (PenX pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				bool positive = sweepAngle >= 0;
				float endAngle = startAngle + sweepAngle;
				startAngle = (float)Utils.TransformAngle(startAngle, width, height);
				sweepAngle = (float)Utils.TransformAngle(endAngle, width, height) - startAngle;
				if (positive && sweepAngle < 0) 
					sweepAngle += 360;
				else if (!positive && sweepAngle >= 0)
					sweepAngle -= 360;

				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawArc(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height),
					MathFP.ToRadians(SingleFP.FromFloat(startAngle)),
					MathFP.ToRadians(SingleFP.FromFloat(sweepAngle)));
			}
		}

		public void DrawBezier (PenX pen, Point pt1, Point pt2, Point pt3, Point pt4)
		{
			DrawBezier(pen, 
				(float)pt1.X, (float)pt1.Y,
				(float)pt2.X, (float)pt2.Y,
				(float)pt3.X, (float)pt3.Y,
				(float)pt4.X, (float)pt4.Y);
		}

		public void DrawBezier (PenX pen, float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				GraphicsPathFP path = new GraphicsPathFP();
				path.AddMoveTo(new PointFP(SingleFP.FromFloat(x1), SingleFP.FromFloat(y1)));
				path.AddCurveTo(
					new PointFP(SingleFP.FromFloat(x2), SingleFP.FromFloat(y2)),
					new PointFP(SingleFP.FromFloat(x3), SingleFP.FromFloat(y3)),
					new PointFP(SingleFP.FromFloat(x4), SingleFP.FromFloat(y4)));
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPath(path);
			}
		}

		public void DrawBeziers (PenX pen, Point [] points)
		{
			lock(this)
			{
				int length = points.Length;
				if (length < 4)	return;

				graphics.Pen = PenX.ToPenFP(pen);
				GraphicsPathFP path = new GraphicsPathFP();
				path.AddMoveTo(new PointFP(SingleFP.FromInt(points[0].X), SingleFP.FromInt(points[0].Y)));
				for (int i = 1; i <= length - 3; i += 3) 
				{
					Point p1 = points [i];
					Point p2 = points [i + 1];
					Point p3 = points [i + 2];
					path.AddCurveTo(
						new PointFP(SingleFP.FromInt(p1.X), SingleFP.FromInt(p1.Y)),
						new PointFP(SingleFP.FromInt(p2.X), SingleFP.FromInt(p2.Y)),
						new PointFP(SingleFP.FromInt(p3.X), SingleFP.FromInt(p3.Y)));
				}
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPath(path);
			}
		}
		
		public void DrawClosedCurve (PenX pen, Point [] points)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawClosedCurves(Utils.ToPointFPArray(points), 0, points.Length - 1, SingleFP.One * 7 / 10);
			}
		}
 							
		public void DrawCurve (PenX pen, Point [] points)
		{
			DrawCurve(pen, points, 1.0f);
		}
				
		public void DrawCurve (PenX pen, Point [] points, float tension)
		{
			DrawCurve(pen, points, 0, points.Length, tension);
		}
		
		public void DrawCurve (PenX pen, Point [] points, int offset, int numberOfSegments, float tension)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawCurves(Utils.ToPointFPArray(points), offset, numberOfSegments, SingleFP.FromFloat(tension));
			}
		}

		public void DrawEllipse (PenX pen, Rectangle rect)
		{
			DrawEllipse (pen, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void DrawEllipse (PenX pen, RectangleF rect)
		{
			DrawEllipse (pen, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void DrawEllipse (PenX pen, int x, int y, int width, int height)
		{
			DrawEllipse(pen, (float)x, (float)y, (float)width, (float)height);
		}

		public void DrawEllipse (PenX pen, float x, float y, float width, float height)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawOval(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height));
			}
		}
		
		public void DrawLine (PenX pen, Point pt1, Point pt2)
		{
			DrawLine(pen, pt1.X, pt1.Y, pt2.X, pt2.Y);
		}

		public void DrawLine (PenX pen, int x1, int y1, int x2, int y2)
		{
			DrawLine(pen, (float)x1, (float)y1, (float)x2, (float)y2);
		}

		public void DrawLine (PenX pen, float x1, float y1, float x2, float y2)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawLine(
					SingleFP.FromFloat(x1),
					SingleFP.FromFloat(y1),
					SingleFP.FromFloat(x2),
					SingleFP.FromFloat(y2));
			}
		}

		public void DrawPie (PenX pen, Rectangle rect, float startAngle, float sweepAngle)
		{
			DrawPie (pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}
		
		public void DrawPie (PenX pen, RectangleF rect, float startAngle, float sweepAngle)
		{
			DrawPie (pen, rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}
		
		public void DrawPie (PenX pen, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				bool positive = sweepAngle >= 0;
				float endAngle = startAngle + sweepAngle;
				startAngle = (float)Utils.TransformAngle(startAngle, width, height);
				sweepAngle = (float)Utils.TransformAngle(endAngle, width, height) - startAngle;
				if (positive && sweepAngle < 0) 
					sweepAngle += 360;
				else if (!positive && sweepAngle >= 0)
					sweepAngle -= 360;
			
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPie(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height),
					MathFP.ToRadians(SingleFP.FromFloat(startAngle)),
					MathFP.ToRadians(SingleFP.FromFloat(sweepAngle)));
			}
		}
		
		public void DrawPie (PenX pen, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			DrawPie(pen, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
		}
		public void DrawLines (PenX pen, Point [] points)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPolyline(Utils.ToPointFPArray(points));
			}
		}
        public void DrawLines(PenX pen, PointF[] points)
        {
            lock (this)
            {
                graphics.Pen = PenX.ToPenFP(pen);
                graphics.Matrix = matrix == null ? null : matrix.matrix;
                graphics.DrawPolyline(Utils.ToPointFPArray(points));
            }
        }
		public void DrawPolygon (PenX pen, Point [] points)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPolygon(Utils.ToPointFPArray(points));
			}
		}
        public void DrawPolygon(PenX pen, PointF[] points)
        {
            lock (this)
            {
                graphics.Pen = PenX.ToPenFP(pen);
                graphics.Matrix = matrix == null ? null : matrix.matrix;
                graphics.DrawPolygon(Utils.ToPointFPArray(points));
            }
        }

		public void DrawRectangle (PenX pen, RectangleF rect)
		{
			DrawRectangle (pen, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void DrawRectangle (PenX pen, Rectangle rect)
		{
			DrawRectangle (pen, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void DrawRectangle (PenX pen, float x, float y, float width, float height)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawRect(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height));
			}
		}
		public void DrawRoundRectangle (PenX pen, RectangleF rect, float rx, float ry)
		{
			DrawRoundRectangle (pen, rect.Left, rect.Top, rect.Width, rect.Height, rx, ry);
		}
		public void DrawRoundRectangle (PenX pen, float x, float y, float width, float height, float rx, float ry)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawRoundRect(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height),
					SingleFP.FromFloat(rx),
					SingleFP.FromFloat(ry));
			}
		}
		public void DrawRectangle (PenX pen, int x, int y, int width, int height)
		{
			DrawRectangle(pen, (float)x, (float)y, (float)width, (float)height);
		}
		public void DrawPath(PenX pen, GraphicsPathX path)
		{
			lock(this)
			{
				graphics.Pen = PenX.ToPenFP(pen);
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.DrawPath(path.path);
			}
		}
		public void ExcludeClip (Rectangle rect)
		{
		}

		public void ExcludeClip (Region region)
		{
		}

		public void FillClosedCurve (BrushX brush, Point [] points)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillClosedCurves(Utils.ToPointFPArray(points), 0, points.Length - 1, SingleFP.One);
			}
		}

		public void FillEllipse (BrushX brush, Rectangle rect)
		{
			FillEllipse (brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void FillEllipse (BrushX brush, RectangleF rect)
		{
			FillEllipse (brush, rect.X, rect.Y, rect.Width, rect.Height);
		}

		public void FillEllipse (BrushX brush, float x, float y, float width, float height)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillOval(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height));
			}
		}

		public void FillEllipse (BrushX brush, int x, int y, int width, int height)
		{
			FillEllipse(brush, (float)x, (float)y, (float)width, (float)height);
		}

		public void FillPie (BrushX brush, Rectangle rect, float startAngle, float sweepAngle)
		{
			FillPie(brush, (float)rect.X, (float)rect.Y, (float)rect.Width, (float)rect.Height, startAngle, sweepAngle);
		}

		public void FillPie (BrushX brush, int x, int y, int width, int height, int startAngle, int sweepAngle)
		{
			FillPie(brush, (float)x, (float)y, (float)width, (float)height, (float)startAngle, (float)sweepAngle);
		}

		public void FillPie (BrushX brush, float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				bool positive = sweepAngle >= 0;
				float endAngle = startAngle + sweepAngle;
				startAngle = (float)Utils.TransformAngle(startAngle, width, height);
				sweepAngle = (float)Utils.TransformAngle(endAngle, width, height) - startAngle;
				if (positive && sweepAngle < 0) 
					sweepAngle += 360;
				else if (!positive && sweepAngle >= 0)
					sweepAngle -= 360;

				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillPie(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height),
					MathFP.ToRadians(SingleFP.FromFloat(startAngle)),
					MathFP.ToRadians(SingleFP.FromFloat(sweepAngle)));
			}
		}

		public void FillPolygon (BrushX brush, Point [] points)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillPolygon(Utils.ToPointFPArray(points));
			}
		}

        public void FillPolygon(BrushX brush, PointF[] points)
        {
            lock (this)
            {
                graphics.Brush = brush.WrappedBrush;
                graphics.Matrix = matrix == null ? null : matrix.matrix;
                graphics.FillPolygon(Utils.ToPointFPArray(points));
            }
        }

		public void FillRoundRectangle (BrushX brush, RectangleF rect, float rx, float ry)
		{
			FillRoundRectangle (brush, rect.Left, rect.Top, rect.Width, rect.Height, rx, ry);
		}
		public void FillRoundRectangle (BrushX brush, float x, float y, float width, float height, float rx, float ry)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillRoundRect(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height),
					SingleFP.FromFloat(rx),
					SingleFP.FromFloat(ry));
			}
		}
		public void FillRectangle (BrushX brush, RectangleF rect)
		{
			FillRectangle (brush, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void FillRectangle (BrushX brush, Rectangle rect)
		{
			FillRectangle (brush, rect.Left, rect.Top, rect.Width, rect.Height);
		}

		public void FillRectangle (BrushX brush, int x, int y, int width, int height)
		{
			FillRectangle(brush, (float)x, (float)y, (float)width, (float)height);
		}

		public void FillRectangle (BrushX brush, float x, float y, float width, float height)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillRect(
					SingleFP.FromFloat(x),
					SingleFP.FromFloat(y),
					SingleFP.FromFloat(x + width),
					SingleFP.FromFloat(y + height));
			}
		}
		public void FillPath(BrushX brush, GraphicsPathX path)
		{
			lock(this)
			{
				graphics.Brush = brush.WrappedBrush;
				graphics.Matrix = matrix == null ? null : matrix.matrix;
				graphics.FillPath(path.path);
			}
		}
		public void FillRegion (BrushX brush, Region region)
		{
		}
		
		public void Flush (Graphics g, int x, int y)
		{
			lock(this)
			{
				g.DrawImage(graphics.Buffer.ToBitmap(), x, y);
			}
		}
		public void Flush (Graphics g)
		{
			lock(this)
			{
				Bitmap bm = graphics.Buffer.ToBitmap();
				g.DrawImage(bm, 0, 0);
				bm.Dispose();
			}
		}
		public void MultiplyTransform (MatrixX matrix)
		{
			MultiplyTransform (matrix, MatrixOrderX.Prepend);
		}

		public void MultiplyTransform (MatrixX matrix, MatrixOrderX order)
		{
			if (this.matrix == null) this.matrix = new MatrixX();
			this.matrix.Multiply(matrix, order);
		}

		public void ResetTransform ()
		{
			if (matrix == null) matrix = new MatrixX();
			matrix.Reset();
		}

		public void RotateTransform (float angle)
		{
			if (matrix == null) matrix = new MatrixX();
			matrix.Rotate(angle);
		}

		public void ScaleTransform (float sx, float sy)
		{
			if (matrix == null) matrix = new MatrixX();
			matrix.Scale(sx, sy);
		}
	
		public void TranslateTransform (float dx, float dy)
		{
			if (matrix == null) matrix = new MatrixX();
			matrix.Translate(dx, dy);
		}

		public MatrixX Transform 
		{
			get 
			{
				return matrix;
			}
			set 
			{
				matrix = value.Clone();
			}
		}
	}
}
