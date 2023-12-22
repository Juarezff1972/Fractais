using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Fractal1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int width = 800;
            const int height = 800;
            Bitmap bmp = new Bitmap(width, height);
            double xmin = -2.1;
            double ymin = -1.3;
            double xmax = 1;
            double ymax = 1.3;
            double dx = (xmax - xmin) / width;
            double dy = (ymax - ymin) / height;
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    double x = xmin + i * dx;
                    double y = ymin + j * dy;
                    double a = 0;
                    double b = 0;
                    int iteration = 0;
                    int max_iteration = 1000;
                    while ((a * a + b * b <= 4) && (iteration < max_iteration))
                    {
                        double temp = a * a - b * b + x;
                        b = 2 * a * b + y;
                        a = temp;
                        iteration++;
                    }
                    if (iteration == max_iteration)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                        bmp.SetPixel(i, j, Color.FromArgb(iteration % 8 * 32, iteration % 16 * 16, iteration % 32 * 8));
                }
            }
            bmp.Save("Mandelbrot.png");
        }
    }
}
