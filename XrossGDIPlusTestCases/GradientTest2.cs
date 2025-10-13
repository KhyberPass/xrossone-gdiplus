using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawEllipseTest.
	/// </summary>
	public class GradientTest2:GDITest
	{
		public GradientTest2( GraphicsX gx):base(gx)
		{
		}
		protected override void DoXrossOneTest()
		{
			Rectangle r = new Rectangle(20, 50,  170, 100);
			LinearGradientBrushX br = new LinearGradientBrushX(r,Color.Black,Color.Black, 60F); 
			ColorBlendX cb = new ColorBlendX(); 
			cb.Positions=new float[7]; 
			int i=0; 
			for(float f=0;f<=1;f+=1.0f/6) 
				cb.Positions[i++]=f; 
			cb.Colors=new Color[]{Color.Red,Color.Orange,Color.Yellow,Color.Green,Color.Blue,Color.Indigo,Color.Violet}; 
			br.InterpolationColors=cb; 
			//Brush brush1 = new LinearGradientBrush(r, c1, c2, 20F);
			gx.TranslateTransform(300, 100);
			gx.RotateTransform(60F);
			gx.FillRectangle(br, r);
			r.Y += 120;
			LinearGradientBrushX brush2 = new LinearGradientBrushX(r, Color.Black,Color.Black, 90F); 
			brush2.InterpolationColors = cb;
			//gx.TranslateTransform(-300, -100);
			gx.RotateTransform(30F);
			gx.FillRectangle(brush2, r);
		
			brush2 = new LinearGradientBrushX(r, Color.Black,Color.Black, 220F); 
			brush2.InterpolationColors = cb;
			gx.RotateTransform(-45F);
			gx.TranslateTransform(-200, -200);
			gx.FillRectangle(brush2, r);
		}
	}
}
