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
using System.Runtime.InteropServices;
using XrossOne.Gdi;

namespace XrossOne.Drawing
{
	public class FontX : IDisposable
	{
		const int LOGPIXELSX			= 88;     
		const int LOGPIXELSY			= 90;       

		private float size;
		private string fontName;
		private FontStyle fontStyle;
		internal IntPtr hFont;
		private bool clearType = true;
		private int angle = 0;

		public FontX(string fontName, float size, FontStyle fontStyle)
		{
			this.fontName = fontName;
			this.size = size;
			this.fontStyle = fontStyle;

			hFont = CreateFont(fontName, size, fontStyle, angle*10);
		}
		public int Angle
		{
			get 
			{ 
				return angle; 
			} 
			set 
			{ 
				if (angle != value)
				{
					angle = value; 
					if ( hFont != IntPtr.Zero )
						GdiHelper.DeleteObject(hFont);
					hFont = CreateFont(fontName, size, fontStyle, angle*10);
				}
			} 
		}
		public bool ClearType
		{
			get 
			{ 
				return clearType; 
			} 
			set 
			{ 
				if (clearType != value)
				{
					clearType = value; 
					if ( hFont != IntPtr.Zero )
						GdiHelper.DeleteObject(hFont);
					hFont = CreateFont(fontName, size, fontStyle, angle*10);
				}
			} 
		}
		
		internal IntPtr CreateFont(string Family, float Size, FontStyle Style, int Escapement)
		{
			GdiLogFont lf = new GdiLogFont();
			lf.CharSet = (byte)GdiFontCharset.Default;
			lf.ClipPrecision = 0;
			lf.Escapement = Escapement;
			IntPtr hdc = GdiHelper.GetDC(IntPtr.Zero);
			int cyDevice_Res = GdiHelper.GetDeviceCaps(hdc, LOGPIXELSY);
			GdiHelper.ReleaseDC(IntPtr.Zero, hdc);
			float flHeight = ((float)Size * (float)cyDevice_Res) / 72.0F;
			int iHeight = (int)(flHeight + 0.5);
			// Set height negative to request 'Em-Height' (versus
			// 'character-cell height' for positive size)
			iHeight = iHeight * (-1);

			lf.Height = iHeight;
			lf.Width = 0;
		
			lf.Italic = (Style & FontStyle.Italic) == FontStyle.Italic? (byte)1: (byte)0;
			lf.Orientation = Escapement;
			lf.OutPrecision = 0;
			if (clearType)
				lf.Quality = (byte)GdiTextQuality.ClearType;
			else
				lf.Quality = (byte)GdiTextQuality.Default;

			lf.StrikeOut = (Style & FontStyle.Strikeout) == FontStyle.Strikeout? (byte)1: (byte)0;
			lf.Underline = (Style & FontStyle.Underline) == FontStyle.Underline? (byte)1: (byte)0;
			lf.Weight = (int)((Style & FontStyle.Bold) == FontStyle.Bold? GdiFontWeights.Bold : GdiFontWeights.Normal);
			
			IntPtr pLF = GdiHelper.LocalAlloc(0x40, 92);
			Marshal.StructureToPtr(lf, pLF, false);
			if ( Family.Length > 32 ) Family = Family.Substring(0, 32);
			Marshal.Copy(Family.ToCharArray(), 0, (IntPtr) ((int)pLF + 28), Family.Length);
			hFont = GdiHelper.CreateFontIndirect(pLF);
			//Marshal.PtrToStructure(pLF, lf);
			GdiHelper.LocalFree(pLF);
			
			return hFont;
		}

		internal IntPtr CreateFont(string Family, float Size, FontStyle Style, int Escapement, int width)
		{

			GdiLogFont lf = new GdiLogFont();
			lf.CharSet = (byte)GdiFontCharset.Default;
			lf.ClipPrecision = 0;
			lf.Escapement = Escapement;
			IntPtr hdc = GdiHelper.GetDC(IntPtr.Zero);
			int cyDevice_Res = GdiHelper.GetDeviceCaps(hdc, LOGPIXELSY);
			GdiHelper.ReleaseDC(IntPtr.Zero, hdc);
			float flHeight = ((float)Size * (float)cyDevice_Res) / 72.0F;
			int iHeight = (int)(flHeight + 0.5);
			iHeight = iHeight * (-1);

			lf.Height = iHeight;
			lf.Width = width;
			
			lf.Italic = (Style & FontStyle.Italic) == FontStyle.Italic? (byte)1: (byte)0;
			lf.Orientation = Escapement;
			lf.OutPrecision = 0;
			if (clearType)
				lf.Quality = (byte)GdiTextQuality.ClearType;
			else
				lf.Quality = (byte)GdiTextQuality.Default;

			lf.StrikeOut = (Style & FontStyle.Strikeout) == FontStyle.Strikeout? (byte)1: (byte)0;
			lf.Underline = (Style & FontStyle.Underline) == FontStyle.Underline? (byte)1: (byte)0;
			lf.Weight = (int)((Style & FontStyle.Bold) == FontStyle.Bold? GdiFontWeights.Bold : GdiFontWeights.Normal);
			
			IntPtr pLF = GdiHelper.LocalAlloc(0x40, 92);
			Marshal.StructureToPtr(lf, pLF, false);
			if ( Family.Length > 32 ) Family = Family.Substring(0, 32);
			Marshal.Copy(Family.ToCharArray(), 0, (IntPtr) ((int)pLF + 28), Family.Length);
			hFont = GdiHelper.CreateFontIndirect(pLF);
			//Marshal.PtrToStructure(pLF, lf);
			GdiHelper.LocalFree(pLF);
			
			return hFont;
		}

		internal IntPtr CreateFont(Font fromFont)
		{
			return CreateFont(fromFont.Name, fromFont.Size, fromFont.Style, 0);
		}	

		~FontX()
		{
			Dispose();
		}

		public void Dispose()
		{
			if ( hFont != IntPtr.Zero )
				GdiHelper.DeleteObject(hFont);
			GC.SuppressFinalize(this);
		}
	}
}
