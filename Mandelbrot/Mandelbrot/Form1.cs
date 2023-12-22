namespace Mandelbrot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            int width = pictureBox1.Width;
            int height = pictureBox1.Height;
            Bitmap bmp = new Bitmap(width, height);
            double xmin = -2.1;
            double ymin = -1.3;
            double xmax = 1;
            double ymax = 1.3;
            double dx = (xmax - xmin) / width;
            double dy = (ymax - ymin) / height;
            int max_iteration = 1000;
            int iteration;
            double x, y, a, b, temp;
            progressBar1.Maximum = width * height;
            progressBar1.Value = 0;

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    x = xmin + i * dx;
                    y = ymin + j * dy;
                    a = 0;
                    b = 0;
                    iteration = 0;
                    while ((a * a + b * b <= 4) && (iteration < max_iteration))
                    {
                        temp = a * a - b * b + x;
                        b = 2 * a * b + y;
                        a = temp;
                        iteration++;
                    }
                    if (iteration == max_iteration)
                        bmp.SetPixel(i, j, Color.Black);
                    else
                        bmp.SetPixel(i, j, Color.FromArgb(iteration % 8 * 32, iteration % 16 * 16, iteration % 32 * 8));
                    progressBar1.Value = i * j;
                }
                progressBar1.Refresh();
            }
            pictureBox1.Image = bmp;
            bmp.Save("Mandelbrot.png");
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            Form1_Shown(sender, e);
        }
    }
}
