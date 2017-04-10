namespace LoWLancher
{
    partial class Form1
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.MainNamelabel = new System.Windows.Forms.Label();
            this.Versionlabel = new System.Windows.Forms.Label();
            this.LaunchButton = new System.Windows.Forms.Button();
            this.MuteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(12, 74);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScrollBarsEnabled = false;
            this.webBrowser1.Size = new System.Drawing.Size(1240, 595);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.Url = new System.Uri("https://sites.google.com/site/loworiginsupdates/", System.UriKind.Absolute);
            // 
            // MainNamelabel
            // 
            this.MainNamelabel.AutoSize = true;
            this.MainNamelabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MainNamelabel.Font = new System.Drawing.Font("Arial", 30F, System.Drawing.FontStyle.Bold);
            this.MainNamelabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(153)))), ((int)(((byte)(0)))));
            this.MainNamelabel.Location = new System.Drawing.Point(4, 9);
            this.MainNamelabel.Name = "MainNamelabel";
            this.MainNamelabel.Size = new System.Drawing.Size(637, 46);
            this.MainNamelabel.TabIndex = 1;
            this.MainNamelabel.Text = "Legends of the Warriors: Origins";
            this.MainNamelabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Versionlabel
            // 
            this.Versionlabel.AutoSize = true;
            this.Versionlabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Versionlabel.Location = new System.Drawing.Point(12, 55);
            this.Versionlabel.Name = "Versionlabel";
            this.Versionlabel.Size = new System.Drawing.Size(246, 13);
            this.Versionlabel.TabIndex = 2;
            this.Versionlabel.Text = "Game Version: Alpha 0.8      Launcher Version: 1.1";
            // 
            // LaunchButton
            // 
            this.LaunchButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.LaunchButton.FlatAppearance.BorderColor = System.Drawing.Color.Green;
            this.LaunchButton.FlatAppearance.BorderSize = 5;
            this.LaunchButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Green;
            this.LaunchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.LaunchButton.Font = new System.Drawing.Font("Arial", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LaunchButton.ForeColor = System.Drawing.Color.Black;
            this.LaunchButton.Location = new System.Drawing.Point(962, 12);
            this.LaunchButton.Name = "LaunchButton";
            this.LaunchButton.Size = new System.Drawing.Size(290, 56);
            this.LaunchButton.TabIndex = 3;
            this.LaunchButton.Text = "Launch Game";
            this.LaunchButton.UseVisualStyleBackColor = false;
            this.LaunchButton.Click += new System.EventHandler(this.LaunchButton_Click);
            // 
            // MuteButton
            // 
            this.MuteButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.MuteButton.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.MuteButton.FlatAppearance.BorderSize = 2;
            this.MuteButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Maroon;
            this.MuteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.MuteButton.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MuteButton.Location = new System.Drawing.Point(902, 12);
            this.MuteButton.Name = "MuteButton";
            this.MuteButton.Size = new System.Drawing.Size(54, 31);
            this.MuteButton.TabIndex = 4;
            this.MuteButton.Text = "Mute";
            this.MuteButton.UseVisualStyleBackColor = false;
            this.MuteButton.Click += new System.EventHandler(this.MuteButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.MuteButton);
            this.Controls.Add(this.LaunchButton);
            this.Controls.Add(this.Versionlabel);
            this.Controls.Add(this.MainNamelabel);
            this.Controls.Add(this.webBrowser1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1280, 720);
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "Form1";
            this.Text = " ";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label MainNamelabel;
        private System.Windows.Forms.Label Versionlabel;
        private System.Windows.Forms.Button LaunchButton;
        private System.Windows.Forms.Button MuteButton;
    }
}

