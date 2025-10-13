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
using System.Runtime.InteropServices;

namespace XrossOne.Gdi
{

	public unsafe class GdiHelper
	{
		private static bool IsPocketPC = Environment.OSVersion.Platform == PlatformID.WinCE;
	
		#region Font & Text
		public static IntPtr CreateFontIndirect(IntPtr pLogFont)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.CreateFontIndirect(pLogFont);
			else
				return GdiHelperPC.CreateFontIndirect(pLogFont);
		}

		public static int SetTextColor(IntPtr hDC, int cColor)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.SetTextColor(hDC, cColor);
			else
				return GdiHelperPC.SetTextColor(hDC, cColor);
		}
		
		public static int DrawText(IntPtr hDC, string Text, ref GdiRectangle rect , GdiTextFormat Format)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.DrawText(hDC, Text, Text.Length, ref rect, (uint)Format);
			else
				return GdiHelperPC.DrawText(hDC, Text, Text.Length, ref rect, (uint)Format);
		}

		#endregion

		#region Memory
		public unsafe static void CopyMemory(byte *pDest, byte *pSrc, int length)
		{
			if (IsPocketPC)
				GdiHelperPocketPC.CopyMemory(pDest, pSrc, length);
			else
				GdiHelperPC.CopyMemory(pDest, pSrc, length);
		}
		public static IntPtr LocalAlloc(int flags, int size)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.LocalAlloc(flags, size);
			else
				return GdiHelperPC.LocalAlloc(flags, size);	
		}

		public static void LocalFree(IntPtr p)
		{
			if (IsPocketPC)
				GdiHelperPocketPC.LocalFree(p);
			else
				GdiHelperPC.LocalFree(p);	
		}
 
		#endregion

		#region GDI Object
		public static bool DeleteObject(IntPtr hObject)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.DeleteObject(hObject);
			else
				return GdiHelperPC.DeleteObject(hObject);	
		}

		public static IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.SelectObject(hdc, hgdiobj);
			else
				return GdiHelperPC.SelectObject(hdc, hgdiobj);
		}

		public static int GetObject(IntPtr hgdiobj, int cbBuffer, ref GdiBitmap lpvObject )
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetObject(hgdiobj, cbBuffer, ref lpvObject);
			else
				return GdiHelperPC.GetObject(hgdiobj, cbBuffer, ref lpvObject);
		}

		#endregion

		#region Bitmap
		
		public static IntPtr LoadBitmap(string filename)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.LoadBitmap(filename);
			else
				return GdiHelperPC.LoadBitmap(filename);
		}

		public unsafe static IntPtr CreateDIBSection(IntPtr hdc, byte* pbmi, uint iUsage,
			byte** ppvBits, IntPtr hSection, uint dwOffset)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.CreateDIBSection(hdc, pbmi, iUsage, ppvBits, hSection, dwOffset);
			else
				return GdiHelperPC.CreateDIBSection(hdc, pbmi, iUsage, ppvBits, hSection, dwOffset);
		}
		public static IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.CreateCompatibleBitmap(hdc, nWidth, nHeight);
			else
				return GdiHelperPC.CreateCompatibleBitmap(hdc, nWidth, nHeight);
		}
		public static bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
			IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwROP)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.BitBlt(hdcDest, nXDest, nYDest, nWidth, nHeight, hdcSrc, nXSrc, nYSrc, dwROP);
			else
				return GdiHelperPC.BitBlt(hdcDest, nXDest, nYDest, nWidth, nHeight, hdcSrc, nXSrc, nYSrc, dwROP);
		}

		public static int StretchBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidthDest, int nHeightDest,
			IntPtr hdcSrc, int nXSrc, int nYSrc, int nWidthSrc, int nHeightSrc, uint dwROP )
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.StretchBlt(hdcDest, nXDest, nYDest, nWidthDest, nHeightDest, hdcSrc, nXSrc, nYSrc, nWidthSrc, nHeightSrc, dwROP);
			else
				return GdiHelperPC.StretchBlt(hdcDest, nXDest, nYDest, nWidthDest, nHeightDest, hdcSrc, nXSrc, nYSrc, nWidthSrc, nHeightSrc, dwROP);
		}

		#endregion 

		#region Device Context 
		public static int GetDeviceCaps(IntPtr hdc, int nIndex )
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetDeviceCaps(hdc, nIndex);
			else
				return GdiHelperPC.GetDeviceCaps(hdc, nIndex);
		}

		public static int SetBkColor(IntPtr hDC, int cColor)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.SetBkColor(hDC, cColor);
			else
				return GdiHelperPC.SetBkColor(hDC, cColor);
		}

		public static int SetBkMode(IntPtr hDC, int nMode)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.SetBkMode(hDC, nMode);
			else
				return GdiHelperPC.SetBkMode(hDC, nMode);
		}

		public static int GetLastError()
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetLastError();
			else
				return GdiHelperPC.GetLastError();
		}

		public static IntPtr GetCapture()
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetCapture();
			else
				return GdiHelperPC.GetCapture();
		}

		public static IntPtr GetActiveWindow()
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetActiveWindow();
			else
				return GdiHelperPC.GetActiveWindow();
		}

		public static IntPtr GetDC(IntPtr hwnd)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.GetDC(hwnd);
			else
				return GdiHelperPC.GetDC(hwnd);
		}

		public static void ReleaseDC( IntPtr hDC )
		{
			if (IsPocketPC)
				GdiHelperPocketPC.ReleaseDC(hDC);
			else
				GdiHelperPC.ReleaseDC(hDC);
		}

		public static int ReleaseDC(IntPtr hwnd, IntPtr hdc)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.ReleaseDC(hwnd, hdc);
			else
				return GdiHelperPC.ReleaseDC(hwnd, hdc);
		}

		public static IntPtr CreateCompatibleDC(IntPtr hdc)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.CreateCompatibleDC(hdc);
			else
				return GdiHelperPC.CreateCompatibleDC(hdc);
		}

		public static bool DeleteDC(IntPtr hdc)
		{
			if (IsPocketPC)
				return GdiHelperPocketPC.DeleteDC(hdc);
			else
				return GdiHelperPC.DeleteDC(hdc);
		}

		#endregion
	}
}
