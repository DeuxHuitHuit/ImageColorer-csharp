﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

using System.Drawing.Imaging;
using System.Drawing;
using System.Runtime.InteropServices;

namespace com.deuxhuithuit.ImageColorer.Console
{
	internal static class MainProgram
	{

		private const string HEX_COLOR_FORMAT_32 = "{0}{1:X2}{2:X2}{3:X2}.{4}"; // color is 16 bits
		private const string HEX_COLOR_FORMAT_16 = "{0}{1:X1}{2:X1}{3:X1}.{4}"; // color is 8 bits
		private const string RGB_TEXT_COLOR_FORMAT = "{0}rgb({1},{2},{3}).{4}"; // color is always 16 bits
		private const string RGB_FIXED_COLOR_FORMAT = "{0}{1:000}{2:000}{3:000}).{4}"; // 16 bits here too

		private const int COLOR_FORMAT = 16; // 16 (X10) | 256 (X100)
		//Private Const COLOR_DEPTH As Byte = 16 ' 8, 16, 24 beware! 1111 1111 / 1111 1111 / 1111 1111

		private static string outputFolder = "../../output/";
		private static string file = "../../test.gif";
		private static Color victim;
		private static string colorFormat = HEX_COLOR_FORMAT_16;
		private static int stepper = 256 / COLOR_FORMAT;

		public static void Main(string[] args)
		{
			parseArgs(args);
			System.Console.WriteLine("Welcome in Deux Huit Huit's ImageColorer");
			System.Console.WriteLine();
			System.Console.WriteLine("File: {0}", file);
			System.Console.WriteLine("Output: {0}", outputFolder);
			System.Console.WriteLine("Filename format {0}", colorFormat);
			System.Console.WriteLine();
			System.Console.WriteLine("Color format: {0} bits", COLOR_FORMAT);
			System.Console.WriteLine("Victim {0}", victim);
			System.Console.WriteLine();
			System.Threading.Thread.Sleep(1000);
			System.Console.Write(" -> 3 -> ");
			System.Threading.Thread.Sleep(1000);
			System.Console.Write("2 -> ");
			System.Threading.Thread.Sleep(1000);
			System.Console.Write("1 -> ");
			System.Threading.Thread.Sleep(1000);
			System.Console.Write(" GO!");
			System.Console.WriteLine();

			DateTime start = DateTime.Now;

			System.IO.FileInfo fileInfo = new System.IO.FileInfo(file);

			if (fileInfo != null && fileInfo.Exists)
			{
				ProcessFile(fileInfo);
			}
			else
			{
				System.Console.WriteLine("ERROR: File '{0}' does not exists. Can not continue.", fileInfo.FullName);
			}
			System.Console.WriteLine();
			System.Console.WriteLine("Took {0:0.000} minutes to create {1} images", (DateTime.Now - start).TotalMinutes, ((Math.Pow(COLOR_FORMAT, 3))));
			System.Console.WriteLine();
			System.Console.WriteLine("Hit <Enter> to exit...");
			System.Console.ReadLine();
		}

        private static void parseArgs(string[] args)
		{
			foreach (string s in args)
			{
				switch (s)
				{

					case "-v":

					break;
					default:
						if (s.StartsWith("-f:"))
						{
							file = s.Remove(0, 3);
						}
						else if (s.StartsWith("-o:"))
						{
							outputFolder = s.Remove(0, 3);
						}
						else if (s.StartsWith("-c:"))
						{
							victim = Core.GifImage.ParseColor(s.Remove(0, 3));
						}
						else
						{
							System.Console.WriteLine("Argument '{0}' not valid.", s);
						}
						break;
				}
			}
		}

		private static void ProcessFile(System.IO.FileInfo fileInfo)
		{
			System.Drawing.Image img = System.Drawing.Bitmap.FromFile(fileInfo.FullName);

			for (int r = 0; r <= 128; r += stepper)
			{
				for (int g = 0; g <= 32; g += stepper)
				{
					for (int b = 0; b <= 32; b += stepper)
					{
						CreateNewImage(ref img, r, g, b);
					}
				}
			}

			img.Dispose();
			img = null;
		}


		private static void CreateNewImage(ref System.Drawing.Image refImage, int r, int g, int b)
		{
			Image newImage = (Image)refImage.Clone();

			// Convert to gif with new color
			Core.GifImage.ConverToGifImageWithNewColor(ref newImage, refImage.Palette, victim, Color.FromArgb(255, r, g, b));

			// Sage this gif image
			SaveGifImage(ref newImage, r, g, b);

			// Free up resources
			newImage.Dispose();
			newImage = null;
		}

		private static int sd(int n)
		{
			if (n == 0)
			{
				return 0;
			}
			return n / stepper;
		}

		private static void SaveGifImage(ref System.Drawing.Image newImage, int r, int g, int b)
		{
			if (!((new System.IO.DirectoryInfo(outputFolder)).Exists))
			{
				System.IO.Directory.CreateDirectory(outputFolder);
			}
			System.IO.FileInfo fileInfo = new System.IO.FileInfo(string.Format(colorFormat, outputFolder, sd(r), sd(g), sd(b), "gif"));

			if (fileInfo.Exists)
			{
				fileInfo.Delete();
			}

			newImage.Save(fileInfo.FullName.Replace("\\","/"));

			System.Console.WriteLine(" - File {0} as been created!", fileInfo.Name);
		}
	}
}