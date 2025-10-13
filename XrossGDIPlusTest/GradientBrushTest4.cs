using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using OpenVue.DrawingFP;
using OpenVue.Drawing;

namespace XrossGDIPlusTest
{
	/// <summary>
	/// Summary description for DrawEllipseTest.
	/// </summary>
	public class GradientBrushTest4:GDITest
	{
		public GradientBrushTest4(MainForm form):base(form)
		{
		}
		protected override void DoXrossTest()
		{
			Rectangle r = new Rectangle(20, 50,  170, 100);
			RadialGradientBrushX br = new RadialGradientBrushX(r,Color.Black,Color.Black, 60F); 
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
			RadialGradientBrushX brush2 = new RadialGradientBrushX(r, Color.Black,Color.Black, 90F); 
			brush2.InterpolationColors = cb;
			//gx.TranslateTransform(-300, -100);
			gx.RotateTransform(30F);
			gx.FillRectangle(brush2, r);

		}
		protected override void DoNativeTest()
		{
			/*Rectangle r = new Rectangle(20, 50,  170, 100);
			RadialGradientBrushX br = new RadialGradientBrushX(r,Color.Black,Color.Black,60F,false); 
			ColorBlend cb = new ColorBlend(); 
			cb.Positions=new float[7]; 
			int i=0; 
			for(float f=0;f<=1;f+=1.0f/6) 
				cb.Positions[i++]=f; 
			cb.Colors=new Color[]{Color.Red,Color.Orange,Color.Yellow,Color.Green,Color.Blue,Color.Indigo,Color.Violet}; 
			br.InterpolationColors=cb; 
			//Brush brush1 = new LinearGradientBrush(r, c1, c2, 20F);
			g2.TranslateTransform(300, 100);
			g2.RotateTransform(60F);
			g2.FillRectangle(br, r);
			r.Y += 120;
			RadialGradientBrushX brush2 = new RadialGradientBrushX(r, Color.Black,Color.Black, 90F,false); 
			brush2.InterpolationColors = cb;
			//g2.Transform.RotateAt(30F, r.Location);
			//g2.TranslateTransform(-300, -100);
			g2.RotateTransform(30F);
			g2.FillRectangle(brush2, r);*/
		}	
	}
}
