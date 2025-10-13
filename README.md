# XrossOne Mobile GDI+

Initial version uploaded from http://www.isquaredsoftware.com/XrossOneGDIPlus.php
Version uploaded was 1.2.6

Description from original website
---

# Antialias Vector Graphics Drawing

XrossOne Mobile GDI+ allows rendering all kinds of 2D geometric shapes, such as lines, rectangles, polygons, ellipses, pies, Bézier spline curves, cardinal spline curves and so on. While the pies, Bézier/cardinal spline curves are not available in .NET Compact Framework. Moreover all shapes are automatically antialiased when being rendered. It helps to achieve a super smooth quality. In .NET Compact Framework, the width of a pen is fixed to 1 pixel. This limitation does not exist any longer in XrossOne GDI+. Variant sizes of the pen could be applied to the outlines of all shapes.

The vector graphics output of XrossOne GDI+ and native GDI+ is identical except for cardinal spline curves. The algorithm is from this article and I have no ideas about that of Microsoft. So you may find some differences between their outputs.

## Line Cap/Join Decorations
To keep itself compact enough, .NET Compact Framework stripped off a lot of features in GDI+ desktop version. One of them is the line cap/join decoration. Of course, in its one-pixel-width outlines, any decoration seems unnecessary. But in XrossOne GDI+, the line cap/join decoration is requisite to draw the variant size outlines. Four line caps ( Flat , Round , Triangle and Square ) and three line joins ( Bevel , Miter and Round ) are supported in the XrossOne GDI+.

## 2D Transformations
The transformation feature is absolutely disappeared in the .NET Compact Framework. It means that if you want to draw an ellipse with 30 degrees rotated, you have to compute its outline and draw it pixel by pixel. It is painful and inefficient in most cases. Fortunately, XrossOne GDI+ provides you full-featured 2D transformations. You can move, zoom and rotate any shapes as you like.

## Gradient Filling
There are five kinds of brushes in native GDI+, namely SolidBrush, LinearGradientBrush, PathGradientBrush, TextureBrush, HatchBrush. Two of them are available in this version: SolidBrush and LinearGradientBrush. Instead of PathGradientBrush, XrossOne GDI+ supports RadialGradientBrush.

## Alpha Channel Composition
The Color structure in the System.Drawing namespace is available in both .NET Framework and Compact Framework. The difference is that the alpha component is disabled in Compact Framework and the hue-saturation-brightness (HSB) values can not be available. Fortunately, the alpha channel composition works perfectly with XrossOne GDI+.
