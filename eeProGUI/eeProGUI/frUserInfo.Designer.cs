namespace eeProGUI
{
    partial class frUserInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frUserInfo));
            this.lTitleName = new System.Windows.Forms.Label();
            this.lAdressTitle = new System.Windows.Forms.Label();
            this.lTitle = new System.Windows.Forms.Label();
            this.lName = new System.Windows.Forms.Label();
            this.lStreet = new System.Windows.Forms.Label();
            this.lPlace = new System.Windows.Forms.Label();
            this.flpResRents = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // lTitleName
            // 
            this.lTitleName.AutoSize = true;
            this.lTitleName.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitleName.Location = new System.Drawing.Point(18, 64);
            this.lTitleName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitleName.Name = "lTitleName";
            this.lTitleName.Size = new System.Drawing.Size(47, 20);
            this.lTitleName.TabIndex = 0;
            this.lTitleName.Text = "Nutzer:";
            // 
            // lAdressTitle
            // 
            this.lAdressTitle.AutoSize = true;
            this.lAdressTitle.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAdressTitle.Location = new System.Drawing.Point(18, 91);
            this.lAdressTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lAdressTitle.Name = "lAdressTitle";
            this.lAdressTitle.Size = new System.Drawing.Size(56, 20);
            this.lAdressTitle.TabIndex = 1;
            this.lAdressTitle.Text = "Adresse:";
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(18, 22);
            this.lTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(199, 22);
            this.lTitle.TabIndex = 2;
            this.lTitle.Text = "Nutzerinformationen";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(90, 64);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(43, 20);
            this.lName.TabIndex = 3;
            this.lName.Text = "Name";
            // 
            // lStreet
            // 
            this.lStreet.AutoSize = true;
            this.lStreet.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lStreet.Location = new System.Drawing.Point(90, 91);
            this.lStreet.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lStreet.Name = "lStreet";
            this.lStreet.Size = new System.Drawing.Size(46, 20);
            this.lStreet.TabIndex = 4;
            this.lStreet.Text = "Straße";
            // 
            // lPlace
            // 
            this.lPlace.AutoSize = true;
            this.lPlace.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPlace.Location = new System.Drawing.Point(90, 118);
            this.lPlace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPlace.Name = "lPlace";
            this.lPlace.Size = new System.Drawing.Size(26, 20);
            this.lPlace.TabIndex = 5;
            this.lPlace.Text = "Ort";
            // 
            // flpResRents
            // 
            this.flpResRents.AutoScroll = true;
            this.flpResRents.Location = new System.Drawing.Point(21, 139);
            this.flpResRents.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.flpResRents.Name = "flpResRents";
            this.flpResRents.Size = new System.Drawing.Size(557, 179);
            this.flpResRents.TabIndex = 6;
            // 
            // frUserInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(609, 347);
            this.Controls.Add(this.flpResRents);
            this.Controls.Add(this.lPlace);
            this.Controls.Add(this.lStreet);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.lAdressTitle);
            this.Controls.Add(this.lTitleName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frUserInfo";
            this.ShowInTaskbar = false;
            this.Text = "Nutzerfenster";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lTitleName;
        private System.Windows.Forms.Label lAdressTitle;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lStreet;
        private System.Windows.Forms.Label lPlace;
        private System.Windows.Forms.FlowLayoutPanel flpResRents;
    }
}