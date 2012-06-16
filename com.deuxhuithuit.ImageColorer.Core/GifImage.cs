//INSTANT C# NOTE: Formerly VB project-level imports:
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace com.deuxhuithuit.ImageColorer.Core
{
	public class GifImage
	{

        public static void CreateGifImage(Image refImage, ref Image destImage)
		{
			// Copy the palette to assure colors follow
			destImage.Palette = refImage.Palette;

			//now to copy the actual bitmap data
			//lock the source and destination bits
			BitmapData src = ((Bitmap)refImage).LockBits(new Rectangle(0, 0, refImage.Width, refImage.Height), ImageLockMode.ReadOnly, refImage.PixelFormat);
			BitmapData dst = ((Bitmap)destImage).LockBits(new Rectangle(0, 0, destImage.Width, destImage.Height), ImageLockMode.WriteOnly, destImage.PixelFormat);

			//steps through each pixel
			int y = 0;
			for (y = 0; y < refImage.Height; y++)
			{
//INSTANT C# TODO TASK: There is no C# equivalent to VB's implicit 'once only' variable initialization within loops:
				int x;
				for (x = 0; x < refImage.Width; x++)
				{
					//transferring the bytes
					Marshal.WriteByte(dst.Scan0, dst.Stride * y + x, Marshal.ReadByte(src.Scan0, src.Stride * y + x));
				}
			}

			//all done, unlock the bitmaps
			((Bitmap)refImage).UnlockBits(src);
			((Bitmap)destImage).UnlockBits(dst);
		}

		public static Image CreateGifImage(Image refImage)
		{
			//Create a new 8 bit per pixel image
			Image bm = new Bitmap(refImage.Width, refImage.Height, PixelFormat.Format8bppIndexed);

            CreateGifImage(refImage, ref bm);

			return bm;
		}

		public static void ReplaceColorInPalette(Image refImage, ColorPalette refPalette, Color victimColor, Color newColor)
		{
			//get it's palette
			ColorPalette ncp = refPalette;

			// Start with the refPalette
			System.Drawing.Imaging.ColorPalette palette = refPalette;
			for (int x = 0; x < palette.Entries.Length; x++)
			{
				System.Drawing.Color color = palette.Entries[x];
				int alpha = 255;
				// if we found our victim
				if (color.R == victimColor.R && color.B == victimColor.B && color.G == victimColor.G)
				{
					// replace it in the palette
					ncp.Entries[x] = System.Drawing.Color.FromArgb(victimColor.A, newColor.R, newColor.G, newColor.B);
				}
				else
				{
					ncp.Entries[x] = System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
				}
			}
			//re-insert the palette
			refImage.Palette = ncp;
		}

		public static void ConverToGifImageWithNewColor(Image refImage, ColorPalette refPalette, Color victimColor, Color newColor)
		{
			ReplaceColorInPalette(refImage, refPalette, victimColor, newColor);

			// Rewrite the bitmap data in a new image
			Image gifImage = Core.GifImage.CreateGifImage(refImage);

			refImage.Dispose();

			refImage = gifImage;
		}

		public static void ReplaceTransparencyColor()
		{
			//copy all the entries from the old palette removing any transparency
			//Dim n As Integer = 0
			//Dim c As Color
			//For Each c In bm.Palette.Entries
			//    ncp.Entries(n) = Color.FromArgb(255, c)
			//    n += 1
			//Next c
			//Set the newly selected transparency
			//ncp.Entries(0) = Color.FromArgb(0, bm.Palette.Entries(0))
			//re-insert the palette
			//refImage.Palette = ncp
		}

		public static Color ParseColor(string s)
		{
			if (!(string.IsNullOrWhiteSpace(s)))
			{
				int r = 0;
				int g = 0;
				int b = 0;
				string[] splitted = s.Split(',');
				if (splitted.Length != 3)
				{
					if (s.Length == 6)
					{
						int.TryParse(s.Substring(0, 2), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out r);
						int.TryParse(s.Substring(2, 2), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out g);
						int.TryParse(s.Substring(4, 2), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out b);
					}
					else if (s.Length == 3)
					{
						int.TryParse(s.Substring(0, 1), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out r);
						int.TryParse(s.Substring(1, 1), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out g);
						int.TryParse(s.Substring(2, 1), System.Globalization.NumberStyles.HexNumber, System.Globalization.CultureInfo.InvariantCulture, out b);
					}
				}
				else
				{
					int.TryParse(splitted[0], out r);
					int.TryParse(splitted[1], out g);
					int.TryParse(splitted[2], out b);
				}
				return Color.FromArgb(255, r, g, b);
			}
			return new Color();
		}

	}

}