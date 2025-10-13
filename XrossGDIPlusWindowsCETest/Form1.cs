using System;
using System.Drawing;
using System.Collections;
using System.Windows.Forms;
using System.Data;
using XrossOne.Drawing;

namespace XrossOneGDIPlusTest
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private GraphicsX gx;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			gx = new GraphicsX(Width, Height);
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
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.Add(this.menuItem1);
			this.mainMenu1.MenuItems.Add(this.menuItem9);
			// 
			// menuItem1
			// 
			this.menuItem1.MenuItems.Add(this.menuItem2);
			this.menuItem1.MenuItems.Add(this.menuItem3);
			this.menuItem1.MenuItems.Add(this.menuItem4);
			this.menuItem1.MenuItems.Add(this.menuItem5);
			this.menuItem1.MenuItems.Add(this.menuItem6);
			this.menuItem1.MenuItems.Add(this.menuItem7);
			this.menuItem1.MenuItems.Add(this.menuItem8);
			this.menuItem1.Text = "Basic";
			// 
			// menuItem2
			// 
			this.menuItem2.Text = "DrawLine";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Text = "DrawPolygon";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Text = "DrawCurve";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Text = "DrawBezier";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Text = "DrawRect";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Text = "DrawArcPie";
			this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
			// 
			// menuItem8
			// 
			this.menuItem8.Text = "DrawEllipse";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.MenuItems.Add(this.menuItem10);
			this.menuItem9.MenuItems.Add(this.menuItem11);
			this.menuItem9.MenuItems.Add(this.menuItem12);
			this.menuItem9.Text = "Transformation";
			// 
			// menuItem10
			// 
			this.menuItem10.Text = "Rotate";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Text = "Scale";
			this.menuItem11.Click += new System.EventHandler(this.menuItem11_Click);
			// 
			// menuItem12
			// 
			this.menuItem12.Text = "Translate";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// Form1
			// 
			this.ClientSize = new System.Drawing.Size(634, 441);
			this.Menu = this.mainMenu1;
			this.Text = "Form1";
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>

		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Text = new DrawLineTest(gx).StartTest();
			Invalidate();
		
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Text = new DrawPolygonTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Text = new DrawCurveTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Text = new DrawBezierTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			Text = new DrawRectTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
			Text = new DrawArcPieTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			Text = new DrawEllipseTest(gx).StartTest();
			Invalidate();

		}

		private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			gx.Flush(e.Graphics, 0, 20);

		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			Text = new RotateTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem11_Click(object sender, System.EventArgs e)
		{
			Text = new ScaleTest(gx).StartTest();
			Invalidate();

		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			Text = new TranslateTest(gx).StartTest();
			Invalidate();

		}
	}
}
