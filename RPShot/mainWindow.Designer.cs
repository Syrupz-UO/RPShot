namespace RPShot
{
    partial class MainWindow
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
            this.label1 = new System.Windows.Forms.Label();
            this.screenshotList = new System.Windows.Forms.ListBox();
            this.imageDisplay = new System.Windows.Forms.PictureBox();
            this.cropButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.screenshotButton = new System.Windows.Forms.Button();
            this.combineButton = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.hotkeyField = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Screenshots";
            // 
            // screenshotList
            // 
            this.screenshotList.FormattingEnabled = true;
            this.screenshotList.Location = new System.Drawing.Point(16, 29);
            this.screenshotList.Name = "screenshotList";
            this.screenshotList.Size = new System.Drawing.Size(175, 186);
            this.screenshotList.TabIndex = 1;
            this.screenshotList.SelectedValueChanged += new System.EventHandler(this.screenshotList_SelectedValueChanged);
            // 
            // imageDisplay
            // 
            this.imageDisplay.Location = new System.Drawing.Point(197, 29);
            this.imageDisplay.Name = "imageDisplay";
            this.imageDisplay.Size = new System.Drawing.Size(237, 186);
            this.imageDisplay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageDisplay.TabIndex = 3;
            this.imageDisplay.TabStop = false;
            // 
            // cropButton
            // 
            this.cropButton.Location = new System.Drawing.Point(278, 219);
            this.cropButton.Name = "cropButton";
            this.cropButton.Size = new System.Drawing.Size(75, 23);
            this.cropButton.TabIndex = 4;
            this.cropButton.Text = "Crop";
            this.cropButton.UseVisualStyleBackColor = true;
            this.cropButton.Click += new System.EventHandler(this.cropButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.deleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.deleteButton.Location = new System.Drawing.Point(197, 219);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = false;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // screenshotButton
            // 
            this.screenshotButton.Location = new System.Drawing.Point(16, 219);
            this.screenshotButton.Name = "screenshotButton";
            this.screenshotButton.Size = new System.Drawing.Size(75, 23);
            this.screenshotButton.TabIndex = 6;
            this.screenshotButton.Text = "Capture";
            this.screenshotButton.UseVisualStyleBackColor = true;
            this.screenshotButton.Click += new System.EventHandler(this.screenshotButton_Click);
            // 
            // combineButton
            // 
            this.combineButton.Location = new System.Drawing.Point(359, 219);
            this.combineButton.Name = "combineButton";
            this.combineButton.Size = new System.Drawing.Size(75, 23);
            this.combineButton.TabIndex = 7;
            this.combineButton.Text = "Combine";
            this.combineButton.UseVisualStyleBackColor = true;
            this.combineButton.Click += new System.EventHandler(this.combineButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(97, 224);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(28, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Key:";
            // 
            // hotkeyField
            // 
            this.hotkeyField.Location = new System.Drawing.Point(131, 219);
            this.hotkeyField.Name = "hotkeyField";
            this.hotkeyField.Size = new System.Drawing.Size(59, 20);
            this.hotkeyField.TabIndex = 9;
            this.hotkeyField.KeyDown += new System.Windows.Forms.KeyEventHandler(this.hotkeyField_KeyDown);
            this.hotkeyField.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.hotkeyField_KeyPress);
            this.hotkeyField.KeyUp += new System.Windows.Forms.KeyEventHandler(this.hotkeyField_KeyUp);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 254);
            this.Controls.Add(this.hotkeyField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.combineButton);
            this.Controls.Add(this.screenshotButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.cropButton);
            this.Controls.Add(this.imageDisplay);
            this.Controls.Add(this.screenshotList);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "MainWindow";
            this.Text = "RPShot";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageDisplay)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox screenshotList;
        private System.Windows.Forms.PictureBox imageDisplay;
        private System.Windows.Forms.Button cropButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button screenshotButton;
        private System.Windows.Forms.Button combineButton;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hotkeyField;
    }
}

