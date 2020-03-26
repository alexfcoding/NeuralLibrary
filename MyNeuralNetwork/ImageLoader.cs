using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace MyNeuralNetwork
{
    class ImageLoader
    {
        //private void GetPicture(Image Picture, Stopwatch watch)
        //{
        //    Bitmap sourcePic = new Bitmap(Picture);

        //    Graphics clearGraphics = Graphics.FromImage(Picture);
        //    Brush clearBrush = new SolidBrush(Color.Black);

        //    clearGraphics.FillRectangle(clearBrush, new System.Drawing.Rectangle(0, 0, Picture.Width, Picture.Height));

        //    Random rndNum = new Random();

        //    using (Graphics graphics = Graphics.FromImage(Picture))
        //    {
        //        using (Font font = new Font("Consolas", 15))
        //        {
        //            for (int i = 0; i < Picture.Width; i += 12)
        //            {
        //                for (int j = 0; j < Picture.Height; j += 12)
        //                {
        //                    int randomCharIndex = rndNum.Next(0, charOut.Length);

        //                    //if (sourcePic.GetPixel(i,j).R < 255)
        //                    {
        //                        Color clr = sourcePic.GetPixel(i, j);
        //                        Brush brush = new SolidBrush(clr);
        //                        graphics.DrawString(charOut[randomCharIndex].ToString(), font, brush, i, j);
        //                    }

        //                }
        //            }
        //            pictureBox1.Refresh();
        //        }
        //    }
        //    watch.Stop();
        //    var elapsedMs = watch.ElapsedMilliseconds;

        //    listBox1.Items.Add("Execution time:");
        //    listBox1.Items.Add(elapsedMs + " ms");
        //    listBox1.Items.Add("=========================");
        //}
    }
}
