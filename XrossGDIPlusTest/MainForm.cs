using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Reflection;
using XrossOne.DrawingFP;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItemDrawLine;
		internal System.Windows.Forms.PictureBox pb1;
		internal System.Windows.Forms.PictureBox pb2;
		internal GraphicsX gx = new GraphicsX(1000, 1000);
		internal Graphics g1, g2;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		internal System.Windows.Forms.Label lbl1;
		internal System.Windows.Forms.Label lbl2;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem19;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MainForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			lbl1.Left = 0; 
			lbl1.Top = 0; 
			lbl2.Left = Width / 2;
			lbl2.Top = 0;
			pb1.Left = 0; 
			pb1.Top = lbl1.Bottom ;
			pb2.Top = lbl2.Bottom ;

			pb1.Image = new Bitmap(1000, 1000);
			Graphics.FromImage(pb1.Image).Clear(Color.White);

			pb2.Image = new Bitmap(1000, 1000);
			Graphics.FromImage(pb2.Image).Clear(Color.White);

			g1 = Graphics.FromImage(pb1.Image);
			g2 = Graphics.FromImage(pb2.Image);

			String filename = Assembly.GetExecutingAssembly().GetModules()[0].FullyQualifiedName;
			filename = Path.GetDirectoryName(filename) + "\\..\\..\\IntroImg.jpg";
			Bitmap bx = new Bitmap(filename);
			//g2.DrawImage(bx, 0, 0);
			LinearGradientBrush xBrushX = new LinearGradientBrush(new Point(0, 0), new Point(120, 120), Utils.FromArgb(255, Color.Yellow), Utils.FromArgb(0, Color.Violet));
			Rectangle r = new Rectangle(0, 0, 120, 120);
			g2.FillRectangle(xBrushX, r);

			g2.SmoothingMode = SmoothingMode.AntiAlias;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItemDrawLine = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.pb1 = new System.Windows.Forms.PictureBox();
			this.pb2 = new System.Windows.Forms.PictureBox();
			this.lbl1 = new System.Windows.Forms.Label();
			this.lbl2 = new System.Windows.Forms.Label();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuItem1,
																					 this.menuItem8,
																					 this.menuItem12,
																					 this.menuItem15,
																					 this.menuItem18});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItemDrawLine,
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem6,
																					  this.menuItem7,
																					  this.menuItem17});
			this.menuItem1.Text = "Basic";
			// 
			// menuItemDrawLine
			// 
			this.menuItemDrawLine.Index = 0;
			this.menuItemDrawLine.Text = "DrawLine";
			this.menuItemDrawLine.Click += new System.EventHandler(this.menuItemDrawLine_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 1;
			this.menuItem2.Text = "Draw/Fill Ellipse";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 2;
			this.menuItem3.Text = "Draw/Fill Rect";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 3;
			this.menuItem4.Text = "DrawArc/FillPie";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 4;
			this.menuItem5.Text = "DrawPolyline/FillPolygon";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 5;
			this.menuItem6.Text = "DrawBezier(s)";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 6;
			this.menuItem7.Text = "DrawCurve";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 7;
			this.menuItem17.Text = "Clear";
			this.menuItem17.Click += new System.EventHandler(this.menuItem17_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Index = 1;
			this.menuItem8.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem9,
																					  this.menuItem10,
																					  this.menuItem11});
			this.menuItem8.Text = "Trasformations";
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 0;
			this.menuItem9.Text = "Translate";
			this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 1;
			this.menuItem10.Text = "Scale";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 2;
			this.menuItem11.Text = "Rotate";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 2;
			this.menuItem12.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem13,
																					   this.menuItem14});
			this.menuItem12.Text = "GradientFill";
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 0;
			this.menuItem13.Text = "LinearGradientFill";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 1;
			this.menuItem14.Text = "LinearGradientFill - ColorBlend";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 3;
			this.menuItem15.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem16});
			this.menuItem15.Text = "Bitmap";
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 0;
			this.menuItem16.Text = "DrawImage";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// pb1
			// 
			this.pb1.Location = new System.Drawing.Point(224, 192);
			this.pb1.Name = "pb1";
			this.pb1.Size = new System.Drawing.Size(112, 112);
			this.pb1.TabIndex = 0;
			this.pb1.TabStop = false;
			// 
			// pb2
			// 
			this.pb2.Location = new System.Drawing.Point(456, 184);
			this.pb2.Name = "pb2";
			this.pb2.Size = new System.Drawing.Size(184, 128);
			this.pb2.TabIndex = 1;
			this.pb2.TabStop = false;
			// 
			// lbl1
			// 
			this.lbl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl1.Location = new System.Drawing.Point(8, 8);
			this.lbl1.Name = "lbl1";
			this.lbl1.Size = new System.Drawing.Size(296, 23);
			this.lbl1.TabIndex = 2;
			this.lbl1.Text = "XrossOne GDI+:";
			// 
			// lbl2
			// 
			this.lbl2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.lbl2.Location = new System.Drawing.Point(376, 8);
			this.lbl2.Name = "lbl2";
			this.lbl2.Size = new System.Drawing.Size(288, 23);
			this.lbl2.TabIndex = 3;
			this.lbl2.Text = "Native GDI+:";
			// 
			// menuItem18
			// 
			this.menuItem18.Index = 4;
			this.menuItem18.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem19});
			this.menuItem18.Text = "String";
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 0;
			this.menuItem19.Text = "DrawString";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 365);
			this.Controls.Add(this.lbl2);
			this.Controls.Add(this.lbl1);
			this.Controls.Add(this.pb2);
			this.Controls.Add(this.pb1);
			this.Menu = this.mainMenu;
			this.Name = "MainForm";
			this.Text = "Benchmark Test";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}
		private void Clear()
		{
		}
		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			lbl2.Left = pb1.Width = pb2.Width = Width / 2;
			pb1.Height = pb2.Height = Height;
			pb2.Left = pb1.Right;
		}
		private void menuItemDrawLine_Click(object sender, System.EventArgs e)
		{
			Text = "DrawLineTest";
			new DrawLineTest(this).StartTest();
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Text = "DrawEllipseTest";
			new DrawEllipseTest(this).StartTest();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Text = "DrawRectTest";
			new DrawRectTest(this).StartTest();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Text = "DrawArcPieTest";
			new DrawArcPieTest(this).StartTest();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Text = "DrawPolygonTest";
			new DrawPolygonTest(this).StartTest();
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Text = "DrawBezierTest";
			new DrawBezierTest(this).StartTest();
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			Text = "DrawCurveTest";
			new DrawCurveTest(this).StartTest();
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			Text = "TranslateTest";
			new TranslateTest(this).StartTest();
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			Text = "ScaleTest";
			new ScaleTest(this).StartTest();
		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			Text = "RotateTest";
			new RotateTest(this).StartTest();
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			Text = "LinearGradientBrush Test1";
			new GradientBrushTest1(this).StartTest();
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			Text = "LinearGradientBrush Test2";
			new GradientBrushTest2(this).StartTest();
		}


		private void menuItem17_Click(object sender, System.EventArgs e)
		{
			Text = "ClearTest";
			new ClearTest(this).StartTest();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			Text = "DrawImage";
			new DrawBitmapTest(this).StartTest();
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			Text = "DrawString";
			new DrawStringTest(this).StartTest();
		}
	}
}
