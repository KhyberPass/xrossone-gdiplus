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
using System.IO;
using System.Drawing;
using System.Diagnostics;
using System.Runtime.InteropServices;
using XrossOne.Gdi;

namespace XrossOne.Drawing
{
	public unsafe class BitmapX : IDisposable	
	{
		const ushort	BITMAP_TYPE				= 19778;
		const ushort	BITMAP_BPP				= 24;
		const ushort	BITMAP_BYTE_PER_PIXEL	= BITMAP_BPP / 8;
		const uint		BITMAP_INFO_HEADER_SIZE	= 40;
		const uint		BITMAP_FILE_HEADER_SIZE	= 14;
		const uint		BITMAP_HEADER_SIZE		= BITMAP_FILE_HEADER_SIZE + BITMAP_INFO_HEADER_SIZE;
		const int		SRCCOPY					= 0x00CC0020;

		GdiBitmapFileHeader fileHeader			= new GdiBitmapFileHeader();
		GdiBitmapInfoHeader infoHeader			= new GdiBitmapInfoHeader();
		IntPtr hBitmap							= IntPtr.Zero;
		internal byte * pPixelData				= null;
		internal uint bytesPerLine;
		private static void Swap(BitmapX bm1, BitmapX bm2)
		{
			GdiBitmapFileHeader t1 = bm1.fileHeader;
			bm1.fileHeader = bm2.fileHeader;
			bm2.fileHeader = t1;

			GdiBitmapInfoHeader t2 = bm1.infoHeader;
			bm1.infoHeader = bm2.infoHeader;
			bm2.infoHeader = t2;

			IntPtr t3 = bm1.hBitmap;
			bm1.hBitmap = bm2.hBitmap;
			bm2.hBitmap = t3;

			byte * t4 = bm1.pPixelData;
			bm1.pPixelData = bm2.pPixelData;
			bm2.pPixelData = t4;

			uint t5 = bm1.bytesPerLine;
			bm1.bytesPerLine = bm2.bytesPerLine;
			bm2.bytesPerLine = t5;
		}
		public BitmapX(int width, int height)
		{
#if DEBUG
			Debug.Assert(width > 0 && height > 0);
#endif
			Initialize(width, height);
			IntPtr hdc = GdiHelper.GetDC(GdiHelper.GetActiveWindow());
			IntPtr hdcComp = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr handle = GdiHelper.CreateCompatibleBitmap(hdcComp, width, height);
			FromHBitmap(handle);
			GdiHelper.DeleteObject(handle);
			GdiHelper.DeleteDC(hdcComp);
			GdiHelper.ReleaseDC(hdc);
		}
		public BitmapX(string filename)
		{
			if (File.Exists(filename))
			{
				IntPtr handle = GdiHelper.LoadBitmap(filename);
				if (handle == IntPtr.Zero)
					throw new FileNotFoundException("Invalid image file.");
				FromHBitmap(handle);
				GdiHelper.DeleteObject(handle);
			}
			else
				throw new FileNotFoundException("Image file doesn't exist.");
		}
		public BitmapX(Type type, string resource)
		{
			Stream input = type.Assembly.GetManifestResourceStream(resource);
			if (input == null)
				input = type.Assembly.GetManifestResourceStream(type.Namespace + "." + resource);
			if (input == null)
				throw new Exception("Resource doesn't exist!");
			FromStream(input);
			input.Close();
		}
		public BitmapX(Stream input)
		{
			FromStream(input);
		}
		public BitmapX(BitmapX bitmap)
		{
			FromHBitmap(bitmap.hBitmap);
		}
		~BitmapX()
		{
			Dispose();
		}
		#region IDisposable Members

		public void Dispose()
		{
			if ( hBitmap != IntPtr.Zero )
			{
				GdiHelper.DeleteObject(hBitmap);
				hBitmap = IntPtr.Zero;
				GC.SuppressFinalize(this);
			}
		}

		#endregion

		private void FromStream(Stream input)
		{
			const int size = 4096;
			byte[] bytes = new byte[size];
			int numBytes;
			string tempFilename = Path.GetTempFileName();
			FileStream output = File.OpenWrite(tempFilename);
			while((numBytes = input.Read(bytes, 0, size)) > 0)
				output.Write(bytes, 0, numBytes);
			//input.Close();
			output.Close();
			IntPtr handle = GdiHelper.LoadBitmap(tempFilename);
			if (handle == IntPtr.Zero)
				throw new Exception("Resource is not a bitmap.");
			FromHBitmap(handle);
			GdiHelper.DeleteObject(handle);
			output.Close();
			try
			{
				File.Delete(tempFilename);
			}
			catch
			{
			}
		}
		public static BitmapX ResizeBitmap(BitmapX bmSrc, int width, int height)
		{
#if DEBUG
			Debug.Assert(width > 0 && height > 0);
#endif
			BitmapX bmDsc = new BitmapX(width, height);

			IntPtr hdc = GdiHelper.GetDC(GdiHelper.GetActiveWindow());
			IntPtr hdcCompTarget = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hdcCompSource = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hbmpOld1 = GdiHelper.SelectObject(hdcCompSource, bmSrc.hBitmap);
			IntPtr hbmpOld2 = GdiHelper.SelectObject(hdcCompTarget, bmDsc.hBitmap);
			GdiHelper.StretchBlt(
				hdcCompTarget, 0, 0, width, height, 
				hdcCompSource, 0, 0, bmSrc.Width, bmSrc.Height, SRCCOPY);						
			GdiHelper.SelectObject(hdcCompSource, hbmpOld1);
			GdiHelper.SelectObject(hdcCompTarget, hbmpOld2);
			GdiHelper.DeleteDC(hdcCompSource);
			GdiHelper.DeleteDC(hdcCompTarget);
			GdiHelper.ReleaseDC(hdc);

			return bmDsc;
		}
		public IntPtr GetHbitmap()
		{
			return hBitmap;
		}
		public void Clear(Color c)
		{
			int color = c.ToArgb();
			for (int i = 0; i < Width; i++)
			{
				for (int j = 0; j < Height; j++)
				{
					this[i, j] = color;
				}
			}
		}
		public void FromHBitmap(IntPtr hBitmapSrc)
		{
			GdiBitmap bm = new GdiBitmap();
			GdiHelper.GetObject(hBitmapSrc, Marshal.SizeOf(bm), ref bm);
			Initialize(bm.Width, bm.Height);  
			IntPtr hdc = GdiHelper.GetDC(GdiHelper.GetActiveWindow());
			IntPtr hdcCompTarget = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hdcCompSource = GdiHelper.CreateCompatibleDC(IntPtr.Zero);
			IntPtr hbmpOld1 = GdiHelper.SelectObject(hdcCompSource, hBitmapSrc);
			IntPtr hbmpOld2 = GdiHelper.SelectObject(hdcCompTarget, hBitmap);
			GdiHelper.BitBlt(hdcCompTarget, 0, 0, bm.Width, bm.Height, hdcCompSource, 0, 0, SRCCOPY);						
			GdiHelper.SelectObject(hdcCompSource, hbmpOld1);
			GdiHelper.SelectObject(hdcCompTarget, hbmpOld2);
			GdiHelper.DeleteDC(hdcCompSource);
			GdiHelper.DeleteDC(hdcCompTarget);
			GdiHelper.ReleaseDC(hdc);
		}
		public int Width
		{
			get
			{
				return infoHeader.Width;
			}
		}
		public int Height
		{
			get
			{
				return infoHeader.Height;
			}
		}
		public Size Size 
		{
			get
			{
				return new Size(Width, Height);
			}
		}
		internal int BytesPerLine
		{
			get
			{
				return (int)bytesPerLine;
			}
		}
		public Color GetPixel(int x, int y)
		{
			return Color.FromArgb(this[x, y]);
		}
		public void SetPixel(int x,	int y, Color color)
		{
			this[x, y] = color.ToArgb();
		}
		public int this[int x, int y]
		{
			get
			{
#if DEBUG
				Debug.Assert(x >= 0 && y >= 0 && x < Width && y < Height);
				Debug.Assert(pPixelData != null);
#endif
				long index = (infoHeader.Height - y - 1) * bytesPerLine + x * BITMAP_BYTE_PER_PIXEL;
				int b, g, r;
				byte * p = pPixelData + index;
				b = *p++;
				g = *p++;
				r = *p;
				return r << 16 | g << 8 | b;
			}
			set
			{
#if DEBUG
				Debug.Assert(x >= 0 && y >= 0 && x < Width && y < Height);
				Debug.Assert(pPixelData != null);
#endif
				long index = (infoHeader.Height - y - 1) * bytesPerLine + x * BITMAP_BYTE_PER_PIXEL;
				byte * p = pPixelData + index;
				*p++ = (byte)(value & 0xFF);
				*p++ = (byte)((value >> 8) & 0xFF);
				*p = (byte)((value >> 16) & 0xFF);
			}
		}
		public Bitmap ToBitmap()
		{
			if (pPixelData == null) return null;

			MemoryStream stream = new MemoryStream((int)fileHeader.Size);
			Save(stream);
			return new Bitmap(stream);
		}
		public unsafe void Save(Stream stream)
		{
			BinaryWriter writer = new BinaryWriter(stream);
			writer.Write(fileHeader.Type);
			writer.Write(fileHeader.Size);
			writer.Write(fileHeader.Reserved1);
			writer.Write(fileHeader.Reserved2);
			writer.Write(fileHeader.OffBits);

			writer.Write(infoHeader.Size);
			writer.Write(infoHeader.Width);
			writer.Write(infoHeader.Height);
			writer.Write(infoHeader.Planes);
			writer.Write(infoHeader.BitCount);
			writer.Write(infoHeader.Compression);
			writer.Write(infoHeader.SizeImage);
			writer.Write(infoHeader.XPelsPerMeter);
			writer.Write(infoHeader.YPelsPerMeter);
			writer.Write(infoHeader.ClrUsed);
			writer.Write(infoHeader.ClrImportant);

			byte * p = pPixelData;
			for (int i = 0; i < fileHeader.Size - BITMAP_HEADER_SIZE; i++, p++)
				writer.Write(*p);
			writer.Flush();
			//writer.Close();
		}
		public void Save(string filename)
		{
			FileStream fstream = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Write, FileShare.Write);
			Save(fstream);
			fstream.Flush();
			fstream.Close();
		}
		private unsafe void Initialize(int width, int height)
		{
			if (pPixelData != null) return;

			infoHeader.BitCount			= BITMAP_BPP;
			infoHeader.ClrImportant		= 0;
			infoHeader.ClrUsed			= 0;
			infoHeader.Compression		= 0;
			infoHeader.Height			= height;
			infoHeader.Width			= width;
			infoHeader.Planes			= 1;
			infoHeader.Size				= BITMAP_INFO_HEADER_SIZE;
			infoHeader.SizeImage		= 0;
			infoHeader.XPelsPerMeter	= 0;
			infoHeader.YPelsPerMeter	= 0;

			bytesPerLine				= (uint)(((width * BITMAP_BPP + 31) & (~31) ) / 8);
			fileHeader.Type				= BITMAP_TYPE;
			fileHeader.Size				= BITMAP_HEADER_SIZE + bytesPerLine * (uint)height;
			fileHeader.OffBits			= BITMAP_HEADER_SIZE;
			fileHeader.Reserved1		= 0;
			fileHeader.Reserved2		= 0;

			fixed (GdiBitmapInfoHeader* pBitmapInfo = &infoHeader)
			{
				byte * pTemp;
				IntPtr hdc = GdiHelper.GetDC(GdiHelper.GetActiveWindow());
				hBitmap = GdiHelper.CreateDIBSection(hdc, (byte*)pBitmapInfo, 0, &pTemp, (IntPtr)0, (uint)0);
				GdiHelper.ReleaseDC(hdc);
				pPixelData = pTemp;
			}
		}
	}
}
