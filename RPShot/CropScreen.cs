using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPShot
{
    public partial class CropScreen : Form
    {
        private bool clicked = false;
        private int xDown, yDown, xUp, yUp;
        private Image baseImage;
        private string currentFilename = "";

        public CropScreen()
        {
            InitializeComponent();

            //setting form to 80% of screen resolution:
            const int _const = 80;
            int screenWidth = Screen.PrimaryScreen.Bounds.Width;
            int screenHeight = Screen.PrimaryScreen.Bounds.Height;

            this.Size = new Size((screenWidth * _const) / 100, (screenHeight * _const) / 100);
        }

        public void SetImage(string filename) {
           // Image img = Image.FromFile("images/" + filename);
            Image img;
            using (var bmpTemp = new Bitmap("images/" + filename))
            {
                img = new Bitmap(bmpTemp);
            }
            currentFilename = "images/" + filename;

            baseImage = img;
            this.cropImageBox.Image = img;
        }

        private void cropImageBox_MouseDown(object sender, MouseEventArgs e)
        {
            clicked = true;
            cropImageBox.Invalidate();

            xDown = e.X;
            yDown = e.Y;
            Console.WriteLine("down");
        }

        private void cropImageBox_MouseUp(object sender, MouseEventArgs e)
        {
            clicked = false;
            xUp = e.X;
            yUp = e.Y;
           // rectCropArea = rec;
           // cropImageBox.Invalidate();
            drawRect();
            Console.WriteLine("up");
        }

        private void cropImageBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (!clicked) { return; }

            xUp = e.X;
            yUp = e.Y;
            cropImageBox.Invalidate();
            drawRect();
            Console.WriteLine("move");
        }

        private void drawRect() {
            Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
            using (Pen pen = new Pen(Color.YellowGreen, 3))
            {
                //cropImageBox.Invalidate();
                //cropImageBox.Image = baseImage;
                cropImageBox.CreateGraphics().DrawRectangle(pen, rec);
            }
        }

        private void cropButton_Click(object sender, EventArgs e)
        {
            Rectangle rec = new Rectangle(xDown, yDown, Math.Abs(xUp - xDown), Math.Abs(yUp - yDown));
            Bitmap src = cropImageBox.Image as Bitmap;
            Bitmap croppedImage = src.Clone(rec, src.PixelFormat);
            cropImageBox.Invalidate();
            cropImageBox.Image = croppedImage;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(currentFilename);
            //System.IO.File.WriteAllText("images/foo.txt", "Testing valid path & permissions.");
            cropImageBox.Image.Save(currentFilename);
            this.Close();
        }
    }
}
