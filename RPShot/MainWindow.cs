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
using GlobalHotKey;
using System.Windows.Input;

namespace RPShot
{
    public partial class MainWindow : Form
    {
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

            HotKeyManager hotKeyManager = new HotKeyManager();

            // Register Ctrl+Alt+F5 hotkey. Save this variable somewhere for the further unregistering.
            var hotKey = hotKeyManager.Register(Key.PrintScreen, System.Windows.Input.ModifierKeys.None);

            // Handle hotkey presses.
            hotKeyManager.KeyPressed += HotKeyManagerPressed;
        }

        

        private void HotKeyManagerPressed(object sender, KeyPressedEventArgs e)
        {
            Console.WriteLine(e.HotKey.Key.ToString());
           // if (e.HotKey.Key == keyData)
           // {
          //      Console.WriteLine("triggering!");

          //  }
            if (e.HotKey.Key == Key.PrintScreen)
                screenshotButton_Click(sender, e);
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

        Key Hotkey;
        Keys keyData;
        string keyCombo = "";
        private void hotkeyField_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine(e.KeyData.ToString());
            hotkeyField.Text = e.KeyData.ToString();// e.KeyData.ToString();
            keyCombo = e.KeyData.ToString();
            if (keyCombo == e.KeyData.ToString())
            {
                Console.WriteLine("same key pressed");
            }

            keyData = e.KeyData;
            // Hotkey = e.;
            e.Handled = true;
        }

        private void hotkeyField_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }

        private void hotkeyField_KeyUp(object sender, KeyEventArgs e)
        {
            
        }
    }
}
