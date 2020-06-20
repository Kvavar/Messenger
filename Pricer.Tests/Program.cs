using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;

namespace Pricer.Tests
{
    class Program
    {
        private static int ΦSequencePrecision = 10;

        static void Main(string[] args)
        {
            var result = new List<(double, double)>();
            for (var x = -2.9; x < 2.9; x += 0.01)
            {
                var y = CalculateΦ(x);
                result.Add((x, y));
            }

            Draw(result, 400, 400, Color.Blue);
            result.Clear();


            Console.WriteLine("Done");
            Console.ReadLine();
        }

        public static double CalculateΦ(double x)
        {
            var pow = Math.Pow(Math.E, -(x * x / 2.0));
            var multiplier = (1 / Math.Sqrt(2 * Math.PI)) * pow;

            var sequenceSum = 0.0;
            var doubleFactorial = 1;
            for (var i = 0; i < ΦSequencePrecision; i++)
            {
                var n = 2 * i + 1;
                doubleFactorial *= n;
                sequenceSum += Math.Pow(x, n) / doubleFactorial;
            }

            return 0.5 + multiplier * sequenceSum;
        }

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
                var absSqrt = Math.Sqrt((radius * radius) - (x * x));
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
