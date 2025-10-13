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
using XrossOne.DrawingFP;
using XrossOne.FixedPoint;

namespace XrossOne.Drawing
{
	public class GraphicsPathX
	{                        	
		FillModeX fillMode = FillModeX.Alternate;
		internal GraphicsPathFP path = new GraphicsPathFP();
		internal MatrixX matrix;

		public GraphicsPathX ()
		{
		}
                
		public GraphicsPathX (FillModeX fillMode)
		{
			FillMode = fillMode;
		}

		public FillModeX FillMode 
		{
			get 
			{  
				return fillMode;
			}

			set 
			{
				fillMode = value;                	
			}
		}

		public void AddArc (Rectangle rect, float start_angle, float sweep_angle)
		{
			AddArc(rect.Left, rect.Top, rect.Width, rect.Height, start_angle, sweep_angle);
		}

		public void AddArc (RectangleF rect, float start_angle, float sweep_angle)
		{
			AddArc(rect.Left, rect.Top, rect.Width, rect.Height, start_angle, sweep_angle);
		}

		public void AddArc (int x, int y, int width, int height, float start_angle, float sweep_angle)
		{
			AddArc((float)x, (float)y, (float)width, (float)height, start_angle, sweep_angle);                  	
		}

		public void AddArc (float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			bool positive = sweepAngle >= 0;
			float endAngle = startAngle + sweepAngle;
			startAngle = (float)Utils.TransformAngle(startAngle, width, height);
			sweepAngle = (float)Utils.TransformAngle(endAngle, width, height) - startAngle;
			if (positive && sweepAngle < 0) 
				sweepAngle += 360;
			else if (!positive && sweepAngle >= 0)
				sweepAngle -= 360;

			path.AddPath(GraphicsPathFP.CreateArc(
				SingleFP.FromFloat(x),
				SingleFP.FromFloat(y),
				SingleFP.FromFloat(x + width),
				SingleFP.FromFloat(y + height),
				MathFP.ToRadians(SingleFP.FromFloat(startAngle)), 
				MathFP.ToRadians(SingleFP.FromFloat(sweepAngle)), false));
		}

		public void AddBezier (Point pt1, Point pt2, Point pt3, Point pt4)
		{
			AddBezier(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);        		                                      
		}

		public void AddBezier (PointF pt1, PointF pt2, PointF pt3, PointF pt4)
		{
			AddBezier(pt1.X, pt1.Y, pt2.X, pt2.Y, pt3.X, pt3.Y, pt4.X, pt4.Y);
		}

		public void AddBezier (int x1, int y1, int x2, int y2, int x3, int y3, int x4, int y4)
		{
    		AddBezier((float) x1, (float) y1, (float) x2, (float) y2, (float) x3, (float) y3, (float) x4, (float) y4);
		}

		public void AddBezier (float x1, float y1, float x2, float y2, float x3, float y3, float x4, float y4)
		{
			path.AddMoveTo(new PointFP(SingleFP.FromFloat(x1), SingleFP.FromFloat(y1)));
			path.AddCurveTo(
				new PointFP(SingleFP.FromFloat(x2), SingleFP.FromFloat(y2)),
				new PointFP(SingleFP.FromFloat(x3), SingleFP.FromFloat(y3)),
				new PointFP(SingleFP.FromFloat(x4), SingleFP.FromFloat(y4)));
		}

		public void AddBeziers (Point [] pts)
		{
			int length = pts.Length;
			if (length < 4)	return;

			path.AddMoveTo(Utils.ToPointFP(pts[0]));
			for (int i = 1; i <= length - 3; i += 3) 
				path.AddCurveTo(
					Utils.ToPointFP(pts [i]),
					Utils.ToPointFP(pts [i+1]),
					Utils.ToPointFP(pts [i+2]));
		}

		public void AddBeziers (PointF [] pts)
		{
			int length = pts.Length;
			if (length < 4)	return;

			path.AddMoveTo(Utils.ToPointFP(pts[0]));
			for (int i = 1; i <= length - 3; i += 3) 
				path.AddCurveTo(
					Utils.ToPointFP(pts [i]),
					Utils.ToPointFP(pts [i+1]),
					Utils.ToPointFP(pts [i+2]));
		}

		public void AddEllipse (RectangleF r)
		{
			AddEllipse(r.X, r.Y, r.Width, r.Height);
		}
		public void AddRoundRectangle (RectangleF r, float rx, float ry)
		{
			AddRoundRectangle(r.X, r.Y, r.Width, r.Height, rx, ry);
		}
		public void AddRoundRectangle (float x, float y, float width, float height, float rx, float ry)
		{
			path.AddPath(GraphicsPathFP.CreateRoundRect(
				SingleFP.FromFloat(x),
				SingleFP.FromFloat(y),
				SingleFP.FromFloat(x + width),
				SingleFP.FromFloat(y + height),
				SingleFP.FromFloat(rx),
				SingleFP.FromFloat(ry)));
		}
		public void AddEllipse (float x, float y, float width, float height)
		{
			path.AddPath(GraphicsPathFP.CreateOval(
				SingleFP.FromFloat(x),
				SingleFP.FromFloat(y),
				SingleFP.FromFloat(x + width),
				SingleFP.FromFloat(y + height)));
		}

		public void AddEllipse (Rectangle r)
		{
			AddEllipse(r.X, r.Y, r.Width, r.Height);
		}
                
		public void AddEllipse (int x, int y, int width, int height)
		{
			AddEllipse((float)x, (float)y, (float)width, (float)height);
		}
                
		public void AddLine (Point a, Point b)
		{
			AddLine(a.X, a.Y, b.X, b.Y);             	
		}

		public void AddLine (PointF a, PointF b)
		{
			AddLine(a.X, a.Y, b.X, b.Y);                                     
		}

		public void AddLine (int x1, int y1, int x2, int y2)
		{
			AddLine((float)x1, (float)y1, (float)x2, (float)y2);             	
		}

		public void AddLine (float x1, float y1, float x2, float y2)
		{
			path.AddMoveTo(Utils.ToPointFP(x1, y1));
			path.AddLineTo(Utils.ToPointFP(x2, y2));
		}

		public void AddLines (Point [] points)
		{
			if (points.Length < 2) return;
			path.AddMoveTo(Utils.ToPointFP(points[0]));
			for (int i = 1; i < points.Length; i++)
				path.AddLineTo(Utils.ToPointFP(points[i]));
		}

		public void AddLines (PointF [] points)
		{
			if (points.Length < 2) return;
			path.AddMoveTo(Utils.ToPointFP(points[0]));
			for (int i = 1; i < points.Length; i++)
				path.AddLineTo(Utils.ToPointFP(points[i]));			
		}
        
		public void AddPie (Rectangle rect, float startAngle, float sweepAngle)
		{
			AddPie(rect.X, rect.Y, rect.Width, rect.Height, startAngle, sweepAngle);
		}

		public void AddPie (int x, int y, int width, int height, float startAngle, float sweepAngle)
		{
			AddPie((float)x, (float)y, (float) width, (float) height, startAngle, sweepAngle);   	
		}

		public void AddPie (float x, float y, float width, float height, float startAngle, float sweepAngle)
		{
			bool positive = sweepAngle >= 0;
			float endAngle = startAngle + sweepAngle;
			startAngle = (float)Utils.TransformAngle(startAngle, width, height);
			sweepAngle = (float)Utils.TransformAngle(endAngle, width, height) - startAngle;
			if (positive && sweepAngle < 0) 
				sweepAngle += 360;
			else if (!positive && sweepAngle >= 0)
				sweepAngle -= 360;

			path.AddPath(GraphicsPathFP.CreateArc(
				SingleFP.FromFloat(x),
				SingleFP.FromFloat(y),
				SingleFP.FromFloat(x + width),
				SingleFP.FromFloat(y + height),
				MathFP.ToRadians(SingleFP.FromFloat(startAngle)),
				MathFP.ToRadians(SingleFP.FromFloat(sweepAngle)), true));
		}

		public void AddPolygon (Point [] points)
		{
			AddPath(GraphicsPathFP.CreatePolygon(Utils.ToPointFPArray(points)), false);
		}

		public void AddPolygon (PointF [] points)
		{
			AddPath(GraphicsPathFP.CreatePolygon(Utils.ToPointFPArray(points)), false);
		}

		public void AddRectangle (Rectangle rect)
		{
			RectangleFP r = Utils.ToRectangleFP(rect);
			AddPath(GraphicsPathFP.CreateRect(r.Left, r.Top, r.Right, r.Bottom), false);
		}

		public void AddRectangle (RectangleF rect)
		{
			RectangleFP r = Utils.ToRectangleFP(rect);
			AddPath(GraphicsPathFP.CreateRect(r.Left, r.Top, r.Right, r.Bottom), false);		               	
		}

		public void AddRectangles (Rectangle [] rects)
		{
			for (int i = 0; i < rects.Length; i++)
				AddRectangle(rects[i]);	               
		}

		public void AddRectangles (RectangleF [] rects)
		{
			for (int i = 0; i < rects.Length; i++)
				AddRectangle(rects[i]);	               			                 	
		}
		private void AddPath (GraphicsPathFP addingPath, bool connect)
		{
			if (addingPath.cmdsSize > 0)
			{
				GraphicsPathFP pathTemp = new GraphicsPathFP(addingPath);
				//if (pathTemp.cmds[0] == GraphicsPathFP.CMD_MOVETO)
				//	pathTemp.cmds[0] = GraphicsPathFP.CMD_LINETO;
				path.AddPath(pathTemp);    
			}
		}

		public void AddPath (GraphicsPathX addingPath, bool connect)
		{
			AddPath(addingPath.path, connect);
		}

		public PointF GetLastPoint ()
		{
			if (path.pntsSize > 0)
				return Utils.ToPointF(path.pnts[path.pntsSize - 1]);
			else 
				return PointF.Empty;
		}

		public void AddClosedCurve (Point [] points)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.One, true), false);			             	
		}

		public void AddClosedCurve (PointF [] points)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.One, true), false);			             			                 	
		}

		public void AddClosedCurve (Point [] points, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.FromFloat(tension), true), false);			             				                   	
		}

		public void AddClosedCurve (PointF [] points, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.FromFloat(tension), true), false);			             				                   				                	
		}

		public void AddCurve (Point [] points)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.One, false), false);			             			                 				                  	
		}
                
		public void AddCurve (PointF [] points)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.One, false), false);			             			                 				                  				              	
		}
                
		public void AddCurve (Point [] points, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.FromFloat(tension), false), false);			             			                 				                  				               	
		}
                
		public void AddCurve (PointF [] points, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), 0, points.Length, SingleFP.FromFloat(tension), false), false);			             			                 				                  				               				                   	
		}

		public void AddCurve (Point [] points, int offset, int numberOfSegments, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), offset, numberOfSegments, SingleFP.FromFloat(tension), false), false);			             			                 				                  				             			           	                                       
		}
                
		public void AddCurve (PointF [] points, int offset, int numberOfSegments, float tension)
		{
			AddPath(GraphicsPathFP.CreateSmoothCurves(
				Utils.ToPointFPArray(points), offset, numberOfSegments, SingleFP.FromFloat(tension), false), false);			             			                 				                  				             			           	                                       			               	                                       
		}
                        
		public void Reset ()
		{
			path.cmdsSize = 0;
			path.pntsSize = 0;            	
		}

		public void Reverse ()
		{
			throw new Exception("Not implemented!");			            	
		}

		public void Transform (MatrixX matrix)
		{
			if (this.matrix == null)
				this.matrix = matrix;
            else
				this.matrix.Multiply(matrix);
		}
                
		public RectangleF GetBounds ()
		{
			return GetBounds (null, null);
		}  		

		public RectangleF GetBounds (MatrixX matrix)
		{
			return GetBounds (matrix, null);
		}

		public RectangleF GetBounds (MatrixX matrix, Pen pen)
		{
			throw new Exception("Not implemented!");			            	
		}
	}
}


