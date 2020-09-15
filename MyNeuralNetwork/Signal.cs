using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace MyNeuralNetwork
{
    public class Signal
    {
        public double[] Amplitude { get; set; }
        public double samplesCount { get; set; }
        public String ImagePath { get; set; }
        public Bitmap image { get; set; }
        public Image imageRotate { get; set; }

        public Signal (int samplesCount)
        {
            Amplitude = new double[samplesCount];
            this.samplesCount = samplesCount;
        }

        public void GenerateSinus(double freq, Random rndAmplitude)
        {
            double time = 0;

            for (int i = 0; i < samplesCount; i += 1)
            {
                time += 0.01;
                Amplitude[i] = ((Math.Sin(time * freq) + Math.Sin(4 * time * freq)) + rndAmplitude.NextDouble() * 8) / 9; //;
            }
        }

        public Image ImageFromFile(string imagePath, Random rndAngle)
        {
            Image im = Image.FromFile(imagePath);
            //image = new Bitmap(RotateImage(im, rndAngle.Next(0,360)));
            image = new Bitmap(im);

            Color clr = new Color();
            Color[] colorArray = new Color[784];
            int k = 0;

            for (int i = 0; i < image.Width; i += 1)
            {
                for (int j = 0; j < image.Height; j += 1)
                {
                    clr = image.GetPixel(i, j);
                    colorArray[k] = clr;
                    Amplitude[k] = (clr.R * 0.21 + clr.G * 0.587 + clr.B * 0.114);

                    if (Amplitude[k] > 1)
                        Amplitude[k] = 0.99;

                    k++;
                }
            }
            return image;
        }

        public void ImageFromDrawer(PictureBox pictureBox)
        {
            image = new Bitmap(pictureBox.Image);

            Color clr = new Color();
            Color[] colorArray = new Color[784];

            int k = 0;
            for (int i = 0; i < image.Width; i += 1)
            {
                for (int j = 0; j < image.Height; j += 1)
                {
                    clr = image.GetPixel(i, j);
                    colorArray[k] = clr;

                    Amplitude[k] = (clr.R * 0.21 + clr.G * 0.587 + clr.B * 0.114)/255;

                    if (Amplitude[k] > 1)
                        Amplitude[k] = 0.99;

                    k++;
                }
            }
        }

        public static Image RotateImage(Image img, float rotationAngle)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);

            Graphics gfx = Graphics.FromImage(bmp);

            gfx.TranslateTransform((float)bmp.Width / 2, (float)bmp.Height / 2);

            gfx.RotateTransform(rotationAngle);

            gfx.TranslateTransform(-(float)bmp.Width / 2, -(float)bmp.Height / 2);

            gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
           
            gfx.DrawImage(img, new Point(0, 0));

            gfx.Dispose();

            return bmp;
        }
    }
}
