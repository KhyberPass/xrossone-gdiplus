using System;
using System.Runtime.InteropServices;

namespace XrossOne.Gdi
{
	public struct GdiPoint
	{
		public int X;
		public int Y;
	}
	public struct GdiRectangle
	{ 
		public int Left; 
		public int Top; 
		public int Right; 
		public int Bottom; 
	}  
	public struct GdiSize
	{
		public int Width;
		public int Height;
	}
	public struct GdiBitmap 
	{
		public int		Type; 
		public int		Width; 
		public int		Height; 
		public int		WidthBytes; 
		public ushort	Planes; 
		public ushort	BitsPixel; 
		public int		Bits; 
	} 

	public struct GdiBitmapInfoHeader
	{
		public uint		Size; 
		public int		Width; 
		public int		Height; 
		public ushort	Planes; 
		public ushort	BitCount; 
		public uint		Compression; 
		public uint		SizeImage; 
		public int		XPelsPerMeter; 
		public int		YPelsPerMeter; 
		public uint		ClrUsed; 
		public uint		ClrImportant; 
	}
		
	public struct GdiBitmapFileHeader
	{ 
		public ushort	Type; 
		public uint		Size; 
		public ushort	Reserved1; 
		public ushort	Reserved2; 
		public uint		OffBits; 
	}

	public struct GdiTextMetric
	{
		public int	Height; 
		public int	Ascent; 
		public int	Descent; 
		public int	InternalLeading; 
		public int	ExternalLeading; 
		public int	AveCharWidth; 
		public int	MaxCharWidth; 
		public int	Weight; 
		public int	Overhang; 
		public int	DigitizedAspectX; 
		public int	DigitizedAspectY; 
		public char FirstChar; 
		public char LastChar; 
		public char DefaultChar; 
		public char BreakChar; 
		public byte Italic; 
		public byte Underlined; 
		public byte StruckOut; 
		public byte PitchAndFamily; 
		public byte CharSet; 
	}

	[StructLayout(LayoutKind.Sequential)]
	public class GdiLogFont
	{
		public int		Height;
		public int      Width;
		public int      Escapement;
		public int      Orientation;
		public int      Weight;
		public byte     Italic;
		public byte     Underline;
		public byte     StrikeOut;
		public byte     CharSet;
		public byte     OutPrecision;
		public byte     ClipPrecision;
		public byte     Quality;
		public byte     PitchAndFamily;
		[MarshalAs(UnmanagedType.ByValTStr, SizeConst=32)]
		public string	lfFaceName;
	} 
	public enum GdiTextFormat
	{
		Top					= 0x00000000,
		Left				= 0x00000000,
		Center				= 0x00000001,
		Right				= 0x00000002,
		VCenter             = 0x00000004,
		Bottom              = 0x00000008,
		WordBreak			= 0x00000010,
		SingleLine	        = 0x00000020,
		ExpandTabs          = 0x00000040,
		TabStop             = 0x00000080,
		NoClip              = 0x00000100,
		ExternalLeading     = 0x00000200,
		CalcRect            = 0x00000400,
		NoPrefix            = 0x00000800,
		Internal            = 0x00001000
	}

	public enum GdiFontCharset
	{
		Ansi		= 0,
		Default		= 1
	}
	public enum GdiFontFamily
	{
		DontCare		= 0 << 4,
		Romain			= 1 << 4,
		Swiss			= 2 << 4,
		Modern			= 3 << 4,
		Script			= 4 << 4,
		Decorative		= 5 << 4
	}
	public enum GdiFontWeights
	{
		DontCare		= 0,
		Thin			= 100,
		ExtraLight		= 200,
		Light			= 300,
		Normal			= 400,
		Medium			= 500,
		SemiBold		= 600,
		Bold			= 700,
		ExtraBold		= 800
	}
	public enum GdiTextQuality
	{
		Default			= 0,
		Draft			= 1,
		Proof			= 2,
		NonAntiAliased	= 3,
		AntiAliased		= 4,
		ClearType		= 5
	}
	public enum GdiBackgroundMode
	{
		Transparent		= 1,
		Opaque			= 2
	}
	public class GdiConstants
	{
		public const int LogPixelSX			= 88;     
		public const int LogPixelSY			= 90;       
		public const int DibRgbColors		= 0;
		public const int SrcCopy			= 0x00CC0020;
		public const int BIRgb				= 0;
		public const int BIBitFields		= 3;
	}
}
