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

namespace XrossOne.Drawing
{
	public struct POINT
	{
		public int x;
		public int y;
	}

	public struct RECT 
	{ 
		public int left; 
		public int top; 
		public int right; 
		public int bottom; 
	}  

	public struct SIZE
	{
		public int width;
		public int height;
	}

	public struct BITMAP 
	{
		public int bmType; 
		public int bmWidth; 
		public int bmHeight; 
		public int bmWidthBytes; 
		public ushort bmPlanes; 
		public ushort bmBitsPixel; 
		public int bmBits; 
	} 

	public struct BITMAPINFOHEADER
	{
		public uint  biSize; 
		public int   biWidth; 
		public int   biHeight; 
		public ushort   biPlanes; 
		public ushort   biBitCount; 
		public uint  biCompression; 
		public uint  biSizeImage; 
		public int   biXPelsPerMeter; 
		public int   biYPelsPerMeter; 
		public uint  biClrUsed; 
		public uint  biClrImportant; 
	}
		
	public struct BITMAPFILEHEADER 
	{ 
		public ushort  bfType; 
		public uint    bfSize; 
		public ushort  bfReserved1; 
		public ushort  bfReserved2; 
		public uint    bfOffBits; 
	}

	public struct TEXTMETRIC 
	{
		public int tmHeight; 
		public int tmAscent; 
		public int tmDescent; 
		public int tmInternalLeading; 
		public int tmExternalLeading; 
		public int tmAveCharWidth; 
		public int tmMaxCharWidth; 
		public int tmWeight; 
		public int tmOverhang; 
		public int tmDigitizedAspectX; 
		public int tmDigitizedAspectY; 
		public char tmFirstChar; 
		public char tmLastChar; 
		public char tmDefaultChar; 
		public char tmBreakChar; 
		public byte tmItalic; 
		public byte tmUnderlined; 
		public byte tmStruckOut; 
		public byte tmPitchAndFamily; 
		public byte tmCharSet; 
	}

	public enum ROP
	{
		R2_BLACK          =  1,   /*  0       */
		R2_NOTMERGEPEN      =2,   /* DPon     */
		R2_MASKNOTPEN       =3,   /* DPna     */
		R2_NOTCOPYPEN       =4,   /* PN       */
		R2_MASKPENNOT       =5,   /* PDna     */
		R2_NOT              =6,   /* Dn       */
		R2_XORPEN           =7,   /* DPx      */
		R2_NOTMASKPEN       =8,   /* DPan     */
		R2_MASKPEN          =9,   /* DPa      */
		R2_NOTXORPEN        =10,  /* DPxn     */
		R2_NOP              =11,  /* D        */
		R2_MERGENOTPEN      =12,  /* DPno     */
		R2_COPYPEN          =13,  /* P        */
		R2_MERGEPENNOT      =14,  /* PDno     */
		R2_MERGEPEN         =15,  /* DPo      */
		R2_WHITE            =16,  /*  1       */
		R2_LAST             =16,		
	}

	public class GDIHelper
	{
		#region Font stuff
		[DllImport("coredll")]
		public static extern IntPtr CreateFontIndirect(IntPtr pLogFont);

		public class LOGFONT
		{
			public int      lfHeight;
			public int      lfWidth;
			public int      lfEscapement;
			public int      lfOrientation;
			public int      lfWeight;
			public byte      lfItalic;
			public byte      lfUnderline;
			public byte      lfStrikeOut;
			public byte      lfCharSet;
			public byte      lfOutPrecision;
			public byte      lfClipPrecision;
			public byte      lfQuality;
			public byte      lfPitchAndFamily;
			//public char[]    lfFaceName;
		} 

		public const int TRANSPARENT        = 1;
		public const int OPAQUE             = 2;

		public const int DT_TOP                     = 0x00000000;
		public const int DT_LEFT                    = 0x00000000;
		public const int DT_CENTER                  = 0x00000001;
		public const int DT_RIGHT                   = 0x00000002;
		public const int DT_VCENTER                 = 0x00000004;
		public const int DT_BOTTOM                  = 0x00000008;
		public const int DT_WORDBREAK               = 0x00000010;
		public const int DT_SINGLELINE              = 0x00000020;
		public const int DT_EXPANDTABS              = 0x00000040;
		public const int DT_TABSTOP                 = 0x00000080;
		public const int DT_NOCLIP                  = 0x00000100;
		public const int DT_EXTERNALLEADING         = 0x00000200;
		public const int DT_CALCRECT                = 0x00000400;
		public const int DT_NOPREFIX                = 0x00000800;
		public const int DT_INTERNAL                = 0x00001000;

		public const int DT_EDITCONTROL             = 0x00002000;
		public const int DT_PATH_ELLIPSIS           = 0x00004000;
		public const int DT_END_ELLIPSIS            = 0x00008000;
		public const int DT_MODIFYSTRING            = 0x00010000;
		public const int DT_RTLREADING              = 0x00020000;
		public const int DT_WORD_ELLIPSIS           = 0x00040000;
		public const int DT_NOFULLWIDTHCHARBREAK    = 0x00080000;

		public const int ANSI_CHARSET				 = 0x0;
		public const int DEFAULT_CHARSET         = 1;

		public const uint FF_DONTCARE         =(0<<4);  /* Don't care or don't know. */
		public const uint FF_ROMAN            =(1<<4);  /* Variable stroke width, serifed. */
		/* Times Roman, Century Schoolbook, etc. */
		public const uint FF_SWISS            =(2<<4);  /* Variable stroke width, sans-serifed. */
		/* Helvetica, Swiss, etc. */
		public const uint FF_MODERN           =(3<<4);  /* Constant stroke width, serifed or sans-serifed. */
		/* Pica, Elite, Courier, etc. */
		public const uint FF_SCRIPT           =(4<<4);  /* Cursive, etc. */
		public const uint FF_DECORATIVE       =(5<<4);  /* Old English, etc. */

		/* Font Weights */
		public const int FW_DONTCARE         =0;
		public const int FW_THIN             =100;
		public const int FW_EXTRALIGHT       =200;
		public const int FW_LIGHT            =300;
		public const int FW_NORMAL           =400;
		public const int FW_MEDIUM           =500;
		public const int FW_SEMIBOLD         =600;
		public const int FW_BOLD             =700;
		public const int FW_EXTRABOLD        =800;

		public const uint DEFAULT_QUALITY        = 0;
		public const uint DRAFT_QUALITY          = 1;
		public const uint PROOF_QUALITY          = 2;
		public const uint NONANTIALIASED_QUALITY = 3;
		public const uint ANTIALIASED_QUALITY    = 4;
		public const uint CLEARTYPE_QUALITY  =     5;

		#endregion
		
		public const int LOGPIXELSX =   88;    /* Logical pixels/inch in X                 */
		public const int LOGPIXELSY  =  90;    /* Logical pixels/inch in Y                 */
		public const int DIB_RGB_COLORS = 0;
		public const int SRCCOPY = 0x00CC0020;
		public const int BI_RGB = 0;
		public const int BI_BITFIELDS = 3;

		[DllImport("coredll")]
		public static extern int SetTextColor(IntPtr hDC, int cColor);

		[DllImport("coredll")]
		public static extern int SetBkColor(IntPtr hDC, int cColor);

		[DllImport("coredll")]
		public static extern int SetBkMode(IntPtr hDC, int nMode);

		[DllImport("coredll")]
		public static extern IntPtr SetROP2(IntPtr hDC, ROP rop);

		[DllImport("coredll")]
		public static extern int DrawText(IntPtr hDC, string Text, int nLen, IntPtr pRect, uint uFormat);

		[DllImport("coredll")]
		public static extern int DrawText(IntPtr hDC, string Text, int nLen, ref RECT rect , uint uFormat);

		[DllImport("coredll")]
		public static extern int ExtTextOut(IntPtr hdc, int X, int Y, uint fuOptions, ref RECT lprc, 
			string lpString, int cbCount, int[] lpDx ); 

		[DllImport("coredll.dll")]
		public static extern int GetTextMetrics(IntPtr hdc, ref TEXTMETRIC lptm); 

		[DllImport("coredll.dll")]
		public static extern int GetTextExtentExPoint(IntPtr hdc, string lpszStr, 
			int cchString, int nMaxExtent, out int lpnFit, int[] alpDx, ref SIZE lpSize ); 

		[DllImport("aygshell.dll", EntryPoint="#75")]
		private static extern IntPtr SHLoadImageFile(string szFileName ); 

		[DllImport("imageloader.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr LoadBitmapFromResource (IntPtr hdc, uint dwResourceID, string pcszClass, IntPtr hModule);

		[DllImport("imageloader.dll", CharSet=CharSet.Unicode)]
		public static extern IntPtr LoadBitmapFromFilename (IntPtr hdc, string filename);

		public static IntPtr LoadBitmap(string filename)
		{
			IntPtr hbitmap = SHLoadImageFile(filename);
			return hbitmap != IntPtr.Zero ? hbitmap : LoadBitmapFromFilename(GetDC((IntPtr)0), filename);
		}

		[DllImport("coredll.dll", EntryPoint="GetLastError")]
		public static extern int GetLastError();		
 
		[DllImport("coredll.dll", EntryPoint="memcpy")]
		public unsafe static extern void CopyMemory(byte *pDest, byte *pSrc, int length);

		[DllImport("coredll.dll", EntryPoint="GetCapture")]
		public static extern IntPtr GetCapture();

		[DllImport("coredll.dll", EntryPoint="GetDC")]
		public static extern IntPtr GetDC(IntPtr hwnd);

		[DllImport ("coredll.dll")]
		public static extern void ReleaseDC( IntPtr hDC );

		[DllImport("coredll.dll", EntryPoint="ReleaseDC")]
		public static extern int ReleaseDC(IntPtr hwnd, IntPtr hdc);

		[DllImport("coredll.dll", EntryPoint="CreateCompatibleDC")]
		public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

		[DllImport("coredll.dll")]
		public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidth, int nHeight);

		[DllImport("coredll.dll", EntryPoint="DeleteDC")]
		public static extern bool DeleteDC(IntPtr hdc);

		[DllImport("coredll.dll", EntryPoint="DeleteObject")]
		public static extern bool DeleteObject(IntPtr hObject);

		[DllImport("coredll.dll", EntryPoint="SelectObject")]
		public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

		[DllImport("coredll.dll", EntryPoint="BitBlt")]
		public static extern bool BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight,
			IntPtr hdcSrc, int nXSrc, int nYSrc, uint dwROP);

		[DllImport("coredll.dll")]
		public static extern int StretchBlt(IntPtr hdcDest, int nXOriginDest, int nYOriginDest, int nWidthDest, int nHeightDest,
			IntPtr hdcSrc, int nXOriginSrc, int nYOriginSrc, int nWidthSrc, int nHeightSrc, uint dwRop ); 

		[DllImport("coredll.dll")]
		public static extern int GetObject(IntPtr hgdiobj, int cbBuffer, ref BITMAP lpvObject ); 

		[DllImport("coredll.dll")]
		public static extern IntPtr CreateDIBSection(IntPtr hdc, IntPtr hdr, uint colors, ref IntPtr pBits, IntPtr hFile, uint offset);

		[DllImport("coredll.dll", EntryPoint="CreateDIBSection", SetLastError=true)]
		public unsafe static extern IntPtr CreateDIBSection(IntPtr hdc, byte* pbmi, uint iUsage,
			byte** ppvBits, IntPtr hSection, uint dwOffset);
	}
}
