namespace eeProGUI
{
    partial class frHelpWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frHelpWindow));
            this.pbQuestionMark = new System.Windows.Forms.PictureBox();
            this.lHelpMenu = new System.Windows.Forms.Label();
            this.lInfos = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestionMark)).BeginInit();
            this.SuspendLayout();
            // 
            // pbQuestionMark
            // 
            this.pbQuestionMark.Image = global::eeProGUI.Properties.Resources.helpicon;
            this.pbQuestionMark.Location = new System.Drawing.Point(12, 52);
            this.pbQuestionMark.Name = "pbQuestionMark";
            this.pbQuestionMark.Size = new System.Drawing.Size(130, 130);
            this.pbQuestionMark.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbQuestionMark.TabIndex = 0;
            this.pbQuestionMark.TabStop = false;
            // 
            // lHelpMenu
            // 
            this.lHelpMenu.AutoSize = true;
            this.lHelpMenu.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lHelpMenu.Location = new System.Drawing.Point(149, 9);
            this.lHelpMenu.Name = "lHelpMenu";
            this.lHelpMenu.Size = new System.Drawing.Size(314, 29);
            this.lHelpMenu.TabIndex = 2;
            this.lHelpMenu.Text = "Wilkommen im Hilfe-Menü";
            this.lHelpMenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lInfos
            // 
            this.lInfos.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfos.Location = new System.Drawing.Point(150, 52);
            this.lInfos.MinimumSize = new System.Drawing.Size(510, 243);
            this.lInfos.Name = "lInfos";
            this.lInfos.Size = new System.Drawing.Size(510, 274);
            this.lInfos.TabIndex = 3;
            this.lInfos.Text = "Hallo";
            // 
            // frHelpWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(717, 351);
            this.Controls.Add(this.lInfos);
            this.Controls.Add(this.lHelpMenu);
            this.Controls.Add(this.pbQuestionMark);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frHelpWindow";
            this.ShowInTaskbar = false;
            this.Text = "Hilfe";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbQuestionMark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbQuestionMark;
        private System.Windows.Forms.Label lHelpMenu;
        private System.Windows.Forms.Label lInfos;
    }
}