namespace RPShot
{
    partial class CropScreen
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cropImageBox = new System.Windows.Forms.PictureBox();
            this.cropButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.cropImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // cropImageBox
            // 
            this.cropImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cropImageBox.Location = new System.Drawing.Point(0, 0);
            this.cropImageBox.Name = "cropImageBox";
            this.cropImageBox.Size = new System.Drawing.Size(284, 261);
            this.cropImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cropImageBox.TabIndex = 0;
            this.cropImageBox.TabStop = false;
            this.cropImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cropImageBox_MouseDown);
            this.cropImageBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.cropImageBox_MouseMove);
            this.cropImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.cropImageBox_MouseUp);
            // 
            // cropButton
            // 
            this.cropButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cropButton.Location = new System.Drawing.Point(117, 226);
            this.cropButton.Name = "cropButton";
            this.cropButton.Size = new System.Drawing.Size(75, 23);
            this.cropButton.TabIndex = 1;
            this.cropButton.Text = "Crop";
            this.cropButton.UseVisualStyleBackColor = true;
            this.cropButton.Click += new System.EventHandler(this.cropButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(198, 226);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(74, 23);
            this.saveButton.TabIndex = 2;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // CropScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.cropButton);
            this.Controls.Add(this.cropImageBox);
            this.DoubleBuffered = true;
            this.Name = "CropScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crop Image";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.cropImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox cropImageBox;
        private System.Windows.Forms.Button cropButton;
        private System.Windows.Forms.Button saveButton;
    }
}