﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPShot
{
    class CollageBuilder
    {
        int newImageHeight = 0;
        int maxWidth = 900;
        int rightMostPoint = 0;
        int borderWidth = 2;

        FileInfo[] images;
        Graphics canvas;
        Bitmap bmapCanvas;
        int row = 0;

        public static Image ScaleImage(Image image, int maxWidth, int maxHeight)
        {
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);

            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);

            var newImage = new Bitmap(newWidth, newHeight);

            using (var graphics = Graphics.FromImage(newImage))
                graphics.DrawImage(image, 0, 0, newWidth, newHeight);

            return newImage;
        }

        public void Build()
        {
            Console.WriteLine("buildin");

            DirectoryInfo d = new DirectoryInfo(@"images");
            images = d.GetFiles("*.png");

            PrepareParams();
            PrepareCanvas();

            int xOffset = 0;
            row = 0;

            foreach (FileInfo image in images)
            {
                Image img = Image.FromFile("images/" + image.Name);

                int width = img.Width;
                int height = img.Height;

                Console.WriteLine("Loaded image " + image.Name + " with dimensions" + width + "," + height);

                double factor = (double)newImageHeight / height;

                Console.WriteLine("factor: " + factor);

                int newImageWidth = (int)(width * factor);

                Console.WriteLine("new width: " + newImageWidth);

                img = ScaleImage(img, this.maxWidth, newImageHeight);

                Bitmap resizedImage = new Bitmap(img);
                newImageWidth = img.Width;


                resizedImage.Save("output/" + image.Name, ImageFormat.Png);

                Console.WriteLine("Resized to " + newImageWidth + "," + newImageHeight);

                if (xOffset + newImageWidth + borderWidth > maxWidth)
                {
                    row += 1;
                    xOffset = 0;
                }

                int requiredHeight = (int)Math.Ceiling((double)((row + 1) * newImageHeight + (row + 1) * borderWidth + borderWidth));

                if (bmapCanvas.Height < requiredHeight)
                {
                 //   Console.WriteLine("extending");
                 //   bmapCanvas = new Bitmap(bmapCanvas, this.maxWidth, requiredHeight);
                 //   canvas = Graphics.FromImage(bmapCanvas);
                  //  canvas.CompositingMode = CompositingMode.SourceOver;
                }


                Console.WriteLine("drawing at " + (xOffset + borderWidth) + "," + (int)(row * newImageHeight + (row + 1) * borderWidth));
                canvas.DrawImage(
                    img,
                    xOffset + borderWidth,
                    (int)(row * newImageHeight + (row + 1) * borderWidth),
                    img.Width,
                    img.Height
                    );

                xOffset += (newImageWidth + borderWidth);

                if (xOffset > rightMostPoint)
                {
                    rightMostPoint = xOffset;
                    Console.WriteLine("right most point: " + rightMostPoint);
                }
            }

            TrimImage();

            bmapCanvas.Save("output/report.png", ImageFormat.Png);
        }

        private void PrepareParams()
        {
            this.newImageHeight = GetMeanHeight();
        }

        private int GetMeanHeight()
        {
            int total = 0;

            foreach (FileInfo image in images)
            {
                Image img = Image.FromFile("images/" + image.Name);
                total += img.Height;
            }

            int newHeight = (int)((double)total / images.Length);

            Console.WriteLine("new height: " + newHeight);

            return Math.Min(newHeight, 300);
        }

        private void PrepareCanvas()
        {
            bmapCanvas = new Bitmap(this.maxWidth, 900);
            canvas = Graphics.FromImage(bmapCanvas);
            canvas.CompositingMode = CompositingMode.SourceOver;
        }

        private void TrimImage()
        {
            Rectangle rec = new Rectangle(
                0,
                0,
                this.rightMostPoint + this.borderWidth,
                (row + 1) * this.newImageHeight + (this.borderWidth * (this.row + 2))
                );
            bmapCanvas = bmapCanvas.Clone(rec, bmapCanvas.PixelFormat);
         //  bmapCanvas = new Bitmap(bmapCanvas, this.rightMostPoint + this.borderWidth, row * this.newImageHeight + (this.borderWidth * (this.row + 1)));
         //  canvas = Graphics.FromImage(bmapCanvas);
        }
    }
}
