namespace eeProGUI
{
    partial class frNewHoliday
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frNewHoliday));
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.lTitle = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lTitle2 = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dtpDate
            // 
            this.dtpDate.CalendarFont = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Location = new System.Drawing.Point(25, 104);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(250, 20);
            this.dtpDate.TabIndex = 0;
            this.dtpDate.Value = new System.DateTime(2017, 6, 1, 0, 0, 0, 0);
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(22, 15);
            this.lTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(191, 16);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "Name des neuen Feiertages:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(25, 42);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(250, 23);
            this.tbName.TabIndex = 2;
            // 
            // lTitle2
            // 
            this.lTitle2.AutoSize = true;
            this.lTitle2.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle2.Location = new System.Drawing.Point(22, 76);
            this.lTitle2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitle2.Name = "lTitle2";
            this.lTitle2.Size = new System.Drawing.Size(178, 16);
            this.lTitle2.TabIndex = 3;
            this.lTitle2.Text = "Tag des neuen Feiertages:";
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Arial", 10.2F);
            this.bSave.Location = new System.Drawing.Point(94, 156);
            this.bSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(97, 24);
            this.bSave.TabIndex = 4;
            this.bSave.Text = "Speichern";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Arial", 10.2F);
            this.bCancel.Location = new System.Drawing.Point(195, 156);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(97, 24);
            this.bCancel.TabIndex = 5;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // frNewHoliday
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(301, 189);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lTitle2);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.dtpDate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frNewHoliday";
            this.ShowInTaskbar = false;
            this.Text = "Neuer Feiertag";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lTitle2;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
    }
}