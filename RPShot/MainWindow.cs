using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace RPShot
{
    public partial class MainWindow : Form
    {
        protected override bool ShowWithoutActivation
        {
            get
            {
                return true;
            }
        }

        private const int WM_MOUSEACTIVATE = 0x0021, MA_NOACTIVATE = 0x0003;

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_MOUSEACTIVATE)
            {
                m.Result = (IntPtr)MA_NOACTIVATE;
                return;
            }
            base.WndProc(ref m);
        }

        private const int WS_EX_NOACTIVATE = 0x08000000;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams createParams = base.CreateParams;
                createParams.ExStyle |= WS_EX_NOACTIVATE;
                return createParams;
            }
        }

        public MainWindow()
        {
            InitializeComponent();
            sc = new ScreenCapture();
        }

        private int imageCount = 1;
        private ScreenCapture sc;

        private void Form1_Load(object sender, EventArgs e)
        {
            DirectoryInfo d = new DirectoryInfo(@"images");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
            foreach (FileInfo file in Files)
            {
                screenshotList.Items.Add(file.Name);
            }

            imageCount = Files.Length;
        }

        private void screenshotButton_Click(object sender, EventArgs e)
        {
            // capture entire screen, and save it to a file
           // Image img = sc.CaptureScreen();
            // display image in a Picture control named imageDisplay
            // capture this window, and save it
            imageCount += 1;
            string fileName = imageCount + ".png";
            fileName = fileName.PadLeft(8, '0');
            sc.CaptureScreenToFile("images/" + fileName, ImageFormat.Png);
            screenshotList.Items.Add(fileName);
            screenshotList.SelectedIndex = screenshotList.Items.Count - 1;
            System.GC.Collect();
        }

        private void cropButton_Click(object sender, EventArgs e)
        {
            if (screenshotList.SelectedIndex == -1) { return; }

            CropScreen crpScrn = new CropScreen();
            crpScrn.SetImage(screenshotList.GetItemText(screenshotList.SelectedItem));
            crpScrn.SetMainWindow(this);
            crpScrn.ShowDialog();
        }

        public void RefreshThumbnail()
        {
            if (screenshotList.SelectedIndex == -1)
            {
                imageDisplay.Image = null;
            }
            else
            {
                Image img;
                using (var bmpTemp = new Bitmap("images/" + screenshotList.GetItemText(screenshotList.SelectedItem)))
                {
                    img = new Bitmap(bmpTemp);
                }
                this.imageDisplay.Image = img;
            }
            System.GC.Collect();
        }

        private void screenshotList_SelectedValueChanged(object sender, EventArgs e)
        {
            if (screenshotList.SelectedIndex == -1) { return; }

            Image img;
            using (var bmpTemp = new Bitmap("images/" + screenshotList.GetItemText(screenshotList.SelectedItem)))
            {
                img = new Bitmap(bmpTemp);
            }
            this.imageDisplay.Image = img;
            System.GC.Collect();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (screenshotList.SelectedIndex == -1) { return; }

            string filename = "images/" + screenshotList.GetItemText(screenshotList.SelectedItem);
            File.Delete(filename);
            screenshotList.Items.RemoveAt(screenshotList.SelectedIndex);
            RefreshThumbnail();
        }

        private void combineButton_Click(object sender, EventArgs e)
        {
            CollageBuilder cb = new CollageBuilder();
            cb.Build();
            Process.Start(@"output");
            System.GC.Collect();
        }
    }
}
