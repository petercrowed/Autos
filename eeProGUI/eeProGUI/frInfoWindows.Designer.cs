namespace eeProGUI
{
    partial class frInfoWindows
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frInfoWindows));
            this.pbInfo = new System.Windows.Forms.PictureBox();
            this.lHelpMenu = new System.Windows.Forms.Label();
            this.lAboutInfo = new System.Windows.Forms.Label();
            this.lAbout = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbInfo
            // 
            this.pbInfo.Image = ((System.Drawing.Image)(resources.GetObject("pbInfo.Image")));
            this.pbInfo.Location = new System.Drawing.Point(11, 11);
            this.pbInfo.Margin = new System.Windows.Forms.Padding(2);
            this.pbInfo.Name = "pbInfo";
            this.pbInfo.Size = new System.Drawing.Size(98, 106);
            this.pbInfo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbInfo.TabIndex = 1;
            this.pbInfo.TabStop = false;
            // 
            // lHelpMenu
            // 
            this.lHelpMenu.AutoSize = true;
            this.lHelpMenu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHelpMenu.Location = new System.Drawing.Point(113, 11);
            this.lHelpMenu.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lHelpMenu.Name = "lHelpMenu";
            this.lHelpMenu.Size = new System.Drawing.Size(122, 22);
            this.lHelpMenu.TabIndex = 3;
            this.lHelpMenu.Text = "Erstellt von:";
            this.lHelpMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lAboutInfo
            // 
            this.lAboutInfo.AutoSize = true;
            this.lAboutInfo.Location = new System.Drawing.Point(128, 47);
            this.lAboutInfo.Name = "lAboutInfo";
            this.lAboutInfo.Size = new System.Drawing.Size(0, 13);
            this.lAboutInfo.TabIndex = 4;
            // 
            // lAbout
            // 
            this.lAbout.AutoSize = true;
            this.lAbout.Location = new System.Drawing.Point(128, 60);
            this.lAbout.Name = "lAbout";
            this.lAbout.Size = new System.Drawing.Size(35, 13);
            this.lAbout.TabIndex = 5;
            this.lAbout.Text = "label1";
            // 
            // frInfoWindows
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 261);
            this.Controls.Add(this.lAbout);
            this.Controls.Add(this.lAboutInfo);
            this.Controls.Add(this.lHelpMenu);
            this.Controls.Add(this.pbInfo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frInfoWindows";
            this.Text = "frInfoWindows";
            ((System.ComponentModel.ISupportInitialize)(this.pbInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbInfo;
        private System.Windows.Forms.Label lHelpMenu;
        private System.Windows.Forms.Label lAboutInfo;
        private System.Windows.Forms.Label lAbout;
    }
}