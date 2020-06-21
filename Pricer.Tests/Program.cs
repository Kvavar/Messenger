using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using Pricer.Math;

namespace Pricer.Tests
{
    class Program
    {
        public static void Draw(List<(double, double)> points, int startX, int startY, Color color)
        {
            Bitmap bitmap;
            var file = @"C:\Hobby\Messenger\Pricer.Tests\Results\m.bmp";
            if (File.Exists(file))
            {
                using var bmpStream = File.Open(file, FileMode.Open);
                var image = Image.FromStream(bmpStream);
                bitmap = new Bitmap(image);
            }
            else
            {
                bitmap = new Bitmap(1000, 1000);
            }
            
            foreach (var (x, y) in points)
            {
                bitmap.DrawCircle(startX + (int) (x * 50), 1000 - (startY + (int) (y * 300)), 2, color);
            }

            bitmap.Save(file);
        }
    }

    public static class BitMapExt
    {
        public static void DrawCircle(this Bitmap bitmap, int centerX, int centerY, int radius, Color color)
        {
            for (var x =  - radius; x <= radius; x++)
            {
                var absSqrt = System.Math.Sqrt((radius * radius) - (x * x));
                var y1 = absSqrt;
                var y2 = - absSqrt;
                bitmap.SetPixel(centerX + x, centerY + (int)(y1), color);
                bitmap.SetPixel(centerX + x, centerY + (int)(y2), color);
            }
        }

        public static void DrawCircle(this Bitmap bitmap, int centerX, int centerY, int radius, int thickness, Color color)
        {
            for (int i = - thickness / 2; i < thickness / 2 + thickness % 2; i++)
            {
                bitmap.DrawCircle(centerX, centerY, radius + i, color);
            }
        }
    }
}
