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

**Original copyright from source files...**

Copyright (C) 2004 XrossOne Studio (www.xrossone.com), All rights reserved.
Author : Xinjie ZHANG (xjzhang@xrossone.com)

This license governs use of the accompanying software ("Software"), and your use of the Software constitutes acceptance of this license.

You may use the Software for any commercial or noncommercial purpose, including distributing derivative works.

In return, we simply require that you agree:
1.	Not to remove any copyright or other notices from the Software.
2.	That if you distribute the Software in source code form you do so only under this license (i.e. you must include a complete copy of this license with your
distribution), and if you distribute the Software solely in object form you only do so under a license that complies with this license.
3.	That the Software comes "as is", with no warranties. None whatsoever. This means no express, implied or statutory warranty, including without limitation, warranties of merchantability or fitness for a particular purpose or any warranty of title or non-infringement. Also, you must pass this disclaimer on whenever you distribute the software or derivative works.
4.	That XrossOne Studio will not be liable for any of those types of damages known as indirect, special, consequential, or incidental related to the Software or this license, to the maximum extent the law permits, no matter what legal theory it's based on. Also, you must pass this limitation of liability on whenever you distribute the Software or derivative works.
5.	That if you sue anyone over patents that you think may apply to the Software for a person's use of the Software, your license to the Software ends automatically.
6.	That the patent rights, if any, granted in this license only apply to the Software, not to any derivative works you make.
7.	That your rights under this License end automatically if you breach it in any way.
8.	That all rights not expressly granted to you in this license are reserved.
