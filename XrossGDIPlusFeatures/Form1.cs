using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using System.Reflection;
using System.IO;
using XrossOne.Drawing;

namespace XrossGDIPlusFeatures
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu2;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.OpenFileDialog dlgOpenFile;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private GraphicsX gx;
		int count = 0;
		private Timer timer = new Timer();
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			gx = new GraphicsX(Width, Height);
			gx.Clear(Color.White);
			timer.Interval = 50;
			timer.Tick +=new EventHandler(timer_Tick);
		}
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			base.Dispose( disposing );
		}
		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu2 = new System.Windows.Forms.MainMenu();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.dlgOpenFile = new System.Windows.Forms.OpenFileDialog();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu2
			// 
			this.mainMenu2.MenuItems.Add(this.menuItem6);
			// 
			// menuItem6
			// 
			this.menuItem6.MenuItems.Add(this.menuItem7);
			this.menuItem6.MenuItems.Add(this.menuItem1);
			this.menuItem6.MenuItems.Add(this.menuItem2);
			this.menuItem6.MenuItems.Add(this.menuItem3);
			this.menuItem6.MenuItems.Add(this.menuItem4);
			this.menuItem6.MenuItems.Add(this.menuItem5);
			this.menuItem6.MenuItems.Add(this.menuItem8);
			this.menuItem6.MenuItems.Add(this.menuItem9);
			this.menuItem6.Text = "Features";
			// 
			// menuItem7
			// 
			this.menuItem7.Text = "VG Drawing";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Text = "Line Cap/Join";
			this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "Transformation";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "Gradient";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "Bitmap";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "DrawString";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Text = "GraphicsPath";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Text = "Aminate";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// Form1
			// 
			this.Menu = this.mainMenu2;
			this.Text = "Form1";
			this.Size = new Size(800, 500);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			try
			{
				Application.Run(new Form1());
			}
			catch(Exception e)
			{
				MessageBox.Show(e.Message);
			}
		}


		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			gx.Flush(e.Graphics);
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			//Text = "VG Drawing";
			//Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;

			//Clear the background and reset the transform state
			gx.Clear(Color.White);
			gx.ResetTransform();
			//Draw skew grid as the background
			PenX pen = new PenX(Utils.FromArgb(0x40, Color.LightGray), 5);
			for (int i = -Height; i < Width + Height; i+=20)
			{
				gx.DrawLine(pen, i, 0, i + Height, Height);
				gx.DrawLine(pen, i, 0, i - Height, Height);
			}

			//Draw a DarkMagenta rectangle with a 10.5-pixel pen
			Color c = Utils.FromArgb(0x80, Color.DarkMagenta);
			pen = new PenX(c, 10.5f);
			gx.DrawRectangle(pen, 50, 20,  150, 200);

			//Fill a GreenYellow rectangle
			c = Utils.FromArgb(0xA0, Color.GreenYellow);
			BrushX brush = new SolidBrushX(c);
			gx.FillRectangle(brush, 120, 50,  90, 150);

			//Draw a BlueViolet ellipse with a 10.5-pixel pen
			c = Utils.FromArgb(0x80, Color.BlueViolet);
			pen = new PenX(c, 10.5f);
			gx.DrawEllipse(pen, 50, 20,  150, 80);

			//Fill a Red ellipse
			c = Utils.FromArgb(0xA0, Color.Red);
			brush = new SolidBrushX(c);
			gx.FillEllipse(brush, 20, 50,  80, 150);

			//Draw a HotPink pie from 156.5 degree to -280.9 degree
			pen.Color = Utils.FromArgb(0xA0, Color.HotPink);
			gx.DrawPie(pen, 3.6f, 120.3f, 200.8f, 130.1f, 156.5f, -280.9f);

			//Draw Orange Bezier curves
			c = Utils.FromArgb(0xA0, Color.Orange);
			pen = new PenX(c, 16);
			Point start = new Point(70, 100);
			Point control1 = new Point(100, 10);
			Point control2 = new Point(150, 50);
			Point end1 = new Point(200, 200);
			Point control3 = new Point(100, 150);
			Point control4 = new Point(50, 200);
			Point end2 = new Point(10, 150);
			Point[] bezierPoints ={start, control1, control2, end1, control3, control4, end2};
			pen.EndCap = LineCapX.Round;
			gx.DrawBeziers(pen, bezierPoints);

			//Refresh
			Invalidate();
			Cursor.Current = Cursors.Default;
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Text = "Line Cap/Join";
			//Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;

			//int tc = Environment.TickCount;
			//Clear the background and reset the transform state
			gx.Clear(Color.White);
			gx.ResetTransform();

			//Draw a pentacle with Miter line join and Round line cap
			PenX pen = new PenX(Color.Orange, 15);
			Point p1 = new Point(150,  80);
			Point p2 = new Point(100,  230);
			Point p3 = new Point(240,  150);
			Point p4 = new Point(60,  150);
			Point p5 = new Point(200,  230);
			Point[] points ={p1,p2,p3,p4,p5};
			MatrixX m = new MatrixX();
			m.Translate(-26, -70);
			m.TransformPoints(points);
			pen.LineJoin = LineJoinX.Miter;
			pen.EndCap = LineCapX.Round;
			pen.StartCap = LineCapX.Round;
			gx.DrawLines(pen, points);

			//Draw a pentacle with Bevel line join and Triangle line cap
			pen = new PenX(Utils.FromArgb(0x80, Color.Blue), 15);
			Point[] points2 ={p1,p2,p3,p4,p5};
			m = new MatrixX();
			m.Translate(-10, -30);
			m.TransformPoints(points2);
			pen.LineJoin = LineJoinX.Bevel;
			pen.StartCap = LineCapX.Triangle;
			gx.DrawLines(pen, points2);

			//Draw a pentacle with Round line join and Round line cap
			pen = new PenX(Utils.FromArgb(0x80, Color.BlueViolet), 20);
			Point[] points3 ={p1,p2,p3,p4,p5};
			m = new MatrixX();
			m.Translate(-40, 20);
			m.TransformPoints(points3);
			pen.LineJoin = LineJoinX.Round;
			pen.EndCap = LineCapX.Round;
			gx.DrawLines(pen, points3);

			//Text = "" + (Environment.TickCount - tc);
			//Refresh
			Invalidate();
			Cursor.Current = Cursors.Default;
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Text = "Transformation";
			//Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;

			//Clear the background and reset the transform state
			gx.Clear(Color.White);
			gx.ResetTransform();

			//Draw a rectangle and apply scale transform to it
			Color c = Utils.FromArgb(0x80, Color.Orange);
			PenX pen = new PenX(c, 7.5f);
			pen.LineJoin = LineJoinX.Miter;
			gx.DrawRectangle(pen, 10, 10, 50, 50);
			gx.ScaleTransform(3, 3);
			gx.DrawRectangle(pen, 10, 10, 50, 50);

			//Draw a series of ellipses and rotate 10 degrees between the preceding and the successor
			c = Utils.FromArgb(0x80, Color.BlueViolet);
			pen = new PenX(c, 5.5f);
			gx.ScaleTransform(0.25F, 0.25F);
			gx.RotateTransform(-40);
			for (int j = 0; j < 10; j ++)
			{
				gx.RotateTransform(10);
				gx.DrawEllipse(pen, 100, 50, 50, 130);
			}

			//Draw a series of triangles and apply translate transform to them
			pen = new PenX(Utils.FromArgb(0x80, Color.Blue), 10);
			Point p1 = new Point(120,  80);
			Point p2 = new Point(100,  200);
			Point p3 = new Point(140,  200);
			Point[] points ={p1,p2,p3};
			GraphicsPathX path = new GraphicsPathX();
			path.AddPolygon(points);
			gx.Transform = new MatrixX();
			pen.LineJoin = LineJoinX.Round;
			for (int i = 0; i <= 40; i +=10)
			{
				gx.TranslateTransform(20, 10);
				//gx.DrawPolygon(pen, points);
				gx.DrawPath(pen, path);
			}

			//gx.DrawImage(gx.ToBitmapX(), new Point(30, 30));
			//Refresh
			Invalidate();
			Cursor.Current = Cursors.Default;
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Text = "Gradient";
			//Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;

			//Clear the background and reset the transform state
			gx.Clear(Color.White);
			gx.ResetTransform();

			//Fill a rectangle with a black-white LinearGradientBrushX
			Rectangle r = new Rectangle(20, 50,  300, 100);
			Color c1 = Color.Black;
			Color c2 = Color.White;
			BrushX brush1 = new LinearGradientBrushX(r, c1, c2, 30F);
			gx.FillRectangle(brush1, r);

			//Fill a rectangle with a 7-color LinearGradientBrushX 
			r = new Rectangle(90, 100,  150, 100);
			LinearGradientBrushX br = new LinearGradientBrushX(r,Color.Black,Color.Black);//, 45.0F); 
			br.RotateTransform(-45.0F);
			ColorBlendX cb = new ColorBlendX(); 
			cb.Positions=new float[7]; 
			int i=0; 
			for(float f=0;f<=1;f+=1.0f/6) 
				cb.Positions[i++]=f; 
			cb.Colors=new Color[]{Color.Red,Color.Orange,Color.Yellow,Color.Green,Color.Blue,Color.Indigo,Color.Violet}; 
			br.InterpolationColors=cb; 
			gx.TranslateTransform(120, 10);
			gx.RotateTransform(50F);
			gx.FillRectangle(br, r);

			//Fill a rectangle with a 7-color RadialGradientBrushX 
			r.Y += 50;
			RadialGradientBrushX brush2 = new RadialGradientBrushX(r, Color.Black,Color.Black, 220F); 
			brush2.InterpolationColors = cb;
			gx.RotateTransform(-45F);
			gx.TranslateTransform(-200, -170);
			gx.FillRectangle(brush2, r);

			//Refresh
			Invalidate();
			Cursor.Current = Cursors.Default;
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			//Text = "Draw Bitmap";
			gx.Clear(Color.White);
			gx.ResetTransform();
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Filter = "Bitmap files (*.bmp)|*.bmp";
			String filename = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
			filename = Path.GetDirectoryName(filename) + "\\babies.jpg";
			ofd.InitialDirectory = Path.GetDirectoryName(filename);
			//if (ofd.ShowDialog() == DialogResult.OK)
			{
				Rectangle r1 = new Rectangle(20, 50,  300, 100);
				Color c1 = Color.Black;
				Color c2 = Color.White;
				BrushX brush1 = new LinearGradientBrushX(r1, c1, c2, 30F);
				//gx.FillRectangle(brush1, r1);

				Cursor.Current = Cursors.WaitCursor;
				BitmapX bx = new BitmapX(filename);
				bx.ToBitmap();
				//bx.Save(Path.GetDirectoryName(filename) + "\\save_test.bmp");
				gx.RotateTransform(30);
				gx.DrawImage(bx, new Point(0, 0));
				LinearGradientBrushX xb = new LinearGradientBrushX(new Point(0, 0), new Point(120, 120), 
					Utils.FromArgb(255, Color.Yellow), 
					Utils.FromArgb(100, Color.Violet));
				LinearGradientBrushX xb2 = new LinearGradientBrushX(new Rectangle(0, 0, 120, 120), 
					Utils.FromArgb(255, Color.Yellow), 
					Utils.FromArgb(100, Color.Violet),45F);
				SolidBrushX xb1 = new SolidBrushX(Utils.FromArgb(170, Color.Yellow));
				Rectangle r = new Rectangle(0, 0, bx.Width, bx.Height);
				gx.FillRectangle(xb, r);

				BitmapX bx1 = new BitmapX(bx);
				gx.ResetTransform();
				gx.ScaleTransform(2f, 0.5f);
				gx.RotateTransform(-30);
				gx.TranslateTransform(-100, 20);
				gx.DrawImage(bx1, new Point(10, 100));

				/*BitmapX bx2 = new BitmapX(this.GetType(), "Alphabet.bmp");
				ImageAttributesX ia = new ImageAttributesX();
				ia.SetColorKey(bx2[0,0], bx2[0, 0]);
				gx.RotateTransform(50.0f);
				gx.TranslateTransform(100, 0);
				gx.DrawImage(BitmapX.ResizeBitmap(bx2, 100, 100), new Point(0, 170), ia);
				gx.FillEllipse(new TextureBrushX(bx2, new Rectangle(10, 10, 500, 200)),
					50, 50, 100, 50);
				gx.ResetTransform();
				gx.FillRectangle(new TextureBrushX(bx2, new Rectangle(10, 10, 500, 200)),
					50, 150, 100, 50);*/
				Cursor.Current = Cursors.Default;
				Invalidate();
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			gx.Clear(Color.White);
			gx.ResetTransform();
			gx.RotateTransform(45);
			gx.DrawString("This is a string line", new FontX("Tahoma", 7, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 10); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 8, FontStyle.Bold), 
				new SolidBrushX(Color.BurlyWood), 10, 30); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 9, FontStyle.Bold), 
				new SolidBrushX(Color.BurlyWood), 10, 50); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 10, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 70); 
			gx.RotateTransform(-90);
			gx.DrawString("This is a string line", new FontX("Tahoma", 11, FontStyle.Bold), 
				new SolidBrushX(Color.BurlyWood), 10, 90); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 12, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 110); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 24, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 140); 
			gx.RotateTransform(45);
			gx.TranslateTransform(-20, -30);
			gx.DrawString("This is a string line", new FontX("Tahoma", 36, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 190); 
			gx.DrawString("This is a string line", new FontX("Tahoma", 36, FontStyle.Bold), 
				new SolidBrushX(Color.Chartreuse), 10, 250); 

/*
			string text = "Welcome";
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
			gx.DrawString("XrossOne Studio", new FontX("Arial", 12, FontStyle.Bold), 
				new SolidBrushX(Color.BlueViolet), 30, 200);*/
			Invalidate();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			Text = "Path";
			//Application.DoEvents();
			Cursor.Current = Cursors.WaitCursor;

            //Clear the background and reset the transform state
			gx.Clear(Color.White);
			gx.ResetTransform();

			//Fill a rectangle with a black-white LinearGradientBrushX
			Rectangle r = new Rectangle(10,20,50,80);
			Color c1 = Color.Black;
			Color c2 = Color.White;
			gx.DrawArc(new PenX(Color.Red), r, 56, 210.7f);
			gx.DrawPie(new PenX(Color.Blue),90, 60, 50, 80, 56f, 210.7f);
			
			
			GraphicsPathX gp = new GraphicsPathX();
			gp.AddLine(0, 30, 50, 180);
			gp.AddArc(0, 30, 50, 80, 56f, 210.7f);
			//gp.AddPie(90, 60, 50, 80, 56f, 210.7f);
			gp.AddEllipse(90, 10, 50, 80);
			gp.AddRoundRectangle(90, 30, 60, 180, 10, 15);
			//gx.RotateTransform(30f);
			//gx.TranslateTransform(60, 10);
			gx.DrawPath(new PenX(Color.Blue, 10.0f), gp);
			
			//Refresh
			Invalidate();
			Cursor.Current = Cursors.Default;
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			timer.Enabled = !timer.Enabled;
		}

		private void timer_Tick(object sender, EventArgs e)
		{
			Text = "" + count++;
			//menuItem7_Click(null, null);
			//menuItem4_Click(null, null);
			menuItem5_Click(null, null);
			//GC.Collect();
			//Text = ("" + (GC.GetTotalMemory(false) / 1024) + "k");
		}
	}
}
