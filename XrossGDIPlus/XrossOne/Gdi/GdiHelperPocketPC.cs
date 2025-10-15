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
	/// <summary>
	/// Summary description for GDIHelperPocketPC.
	/// </summary>
	internal class GdiHelperPocketPC
	{
		#region Font & Text
		[DllImport("Coredll.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr CreateFontIndirect(IntPtr pLogFont);

		[DllImport("Coredll.dll")]
		public static extern int SetTextColor(IntPtr hDC, int cColor);
		
		[DllImport("Coredll.dll")]
		public static extern int DrawText(IntPtr hDC, string Text, int nLen, IntPtr pRect, uint uFormat);

		[DllImport("Coredll.dll")]
		public static extern int DrawText(IntPtr hDC, string Text, int nLen, ref GdiRectangle rect , uint uFormat);

		[DllImport("Coredll.dll")]
		public static extern int ExtTextOut(IntPtr hdc, int X, int Y, uint fuOptions, ref GdiRectangle lprc, 
			string lpString, int cbCount, int[] lpDx ); 

		[DllImport("Coredll.dll")]
		public static extern int GetTextMetrics(IntPtr hdc, ref GdiTextMetric lptm); 

		[DllImport("Coredll.dll")]
		public static extern int GetTextExtentExPoint(IntPtr hdc, string lpszStr, 
			int cchString, int nMaxExtent, out int lpnFit, int[] alpDx, ref GdiSize lpSize ); 

		#endregion

		#region Memory
		[DllImport("Coredll.dll")]
		public static extern IntPtr LocalAlloc(int flags, int size);

		[DllImport("Coredll.dll")]
		public static extern void LocalFree(IntPtr p);
 
		[DllImport("Coredll.dll", EntryPoint="memcpy")]
		public unsafe static extern void CopyMemory(byte *pDest, byte *pSrc, int length);

		#endregion

		#region GDI Object
		[DllImport("Coredll.dll", EntryPoint="DeleteObject")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("Coredll.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("Coredll.dll")]
		public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, ref GdiBitmap lpvObject ); 

		#endregion

		#region Bitmap
		
		[DllImport("aygshell.dll", EntryPoint="#75")]
		private static extern IntPtr SHLoadImageFile(string szFileName ); 

		[DllImport("imageloader.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr LoadBitmapFromResource (IntPtr hdc, uint dwResourceID, string pcszClass, IntPtr hModule);

		[DllImport("imageloader.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr LoadBitmapFromFilename (IntPtr hdc, string filename);

		public static IntPtr LoadBitmap(string filename)
		{
			IntPtr hbitmap = SHLoadImageFile(filename);
			return hbitmap != IntPtr.Zero ? hbitmap : LoadBitmapFromFilename(IntPtr.Zero, filename);
		}
		[DllImport("Coredll.dll")]
		public static extern IntPtr CreateDIBSection(IntPtr hdc, IntPtr hdr, uint colors, ref IntPtr pBits, IntPtr hFile, uint offset);

		[DllImport("Coredll.dll", EntryPoint="CreateDIBSection", SetLastError=true)]
		public unsafe static extern IntPtr CreateDIBSection(IntPtr hdc, byte* pbmi, uint iUsage,
			byte** ppvBits, IntPtr hSection, uint dwOffset);

		[DllImport("Coredll.dll", EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
			IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwROP);

		[DllImport("Coredll.dll")]
		public static extern int StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
			IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop ); 

		[DllImport("Coredll.dll")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		#endregion 

		#region Device Context 

		[DllImport("coredll.dll")]
		public static extern int GetDeviceCaps(IntPtr hdc, int nIndex );

		[DllImport("Coredll.dll")]
		public static extern int SetBkColor(IntPtr hDC, int cColor);

		[DllImport("Coredll.dll")]
		public static extern int SetBkMode(IntPtr hDC, int nMode);

		[DllImport("Coredll.dll", EntryPoint="GetLastError")]
		public static extern int GetLastError();		

		[DllImport("Coredll.dll", EntryPoint="GetCapture")]
		public static extern IntPtr GetCapture();

		[DllImport("Coredll.dll")]
		public static extern IntPtr GetActiveWindow();

		[DllImport("Coredll.dll", EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport("Coredll.dll", EntryPoint="ReleaseDC")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("Coredll.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("Coredll.dll", EntryPoint="DeleteDC")]
		public static extern bool DeleteDC(IntPtr hdc);

		#endregion
	}
}
