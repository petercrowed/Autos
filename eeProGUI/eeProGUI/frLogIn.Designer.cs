namespace eeProGUI
{
    partial class frLogIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frLogIn));
            this.lInfo = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.lName = new System.Windows.Forms.Label();
            this.lPassword = new System.Windows.Forms.Label();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.bLogIn = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.lWrongLogData = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lInfo
            // 
            this.lInfo.AutoSize = true;
            this.lInfo.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lInfo.Location = new System.Drawing.Point(28, 40);
            this.lInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lInfo.Name = "lInfo";
            this.lInfo.Size = new System.Drawing.Size(283, 17);
            this.lInfo.TabIndex = 0;
            this.lInfo.Text = "Bitte geben sie hier ihre Anmeldedaten ein:";
            // 
            // tbName
            // 
            this.tbName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbName.Location = new System.Drawing.Point(32, 107);
            this.tbName.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(276, 23);
            this.tbName.TabIndex = 1;
            this.tbName.Text = "Name";
            // 
            // lName
            // 
            this.lName.AutoSize = true;
            this.lName.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lName.Location = new System.Drawing.Point(28, 89);
            this.lName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lName.Name = "lName";
            this.lName.Size = new System.Drawing.Size(103, 16);
            this.lName.TabIndex = 2;
            this.lName.Text = "Benutzername:";
            // 
            // lPassword
            // 
            this.lPassword.AutoSize = true;
            this.lPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPassword.Location = new System.Drawing.Point(28, 141);
            this.lPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lPassword.Name = "lPassword";
            this.lPassword.Size = new System.Drawing.Size(69, 16);
            this.lPassword.TabIndex = 3;
            this.lPassword.Text = "Passwort:";
            // 
            // tbPassword
            // 
            this.tbPassword.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPassword.Location = new System.Drawing.Point(32, 159);
            this.tbPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(276, 23);
            this.tbPassword.TabIndex = 4;
            this.tbPassword.Text = "Passwort";
            // 
            // bLogIn
            // 
            this.bLogIn.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bLogIn.Location = new System.Drawing.Point(128, 210);
            this.bLogIn.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bLogIn.Name = "bLogIn";
            this.bLogIn.Size = new System.Drawing.Size(87, 25);
            this.bLogIn.TabIndex = 5;
            this.bLogIn.Text = "Einloggen";
            this.bLogIn.UseVisualStyleBackColor = true;
            this.bLogIn.Click += new System.EventHandler(this.bLogIn_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(220, 210);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(87, 25);
            this.bCancel.TabIndex = 6;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // lWrongLogData
            // 
            this.lWrongLogData.AutoSize = true;
            this.lWrongLogData.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWrongLogData.ForeColor = System.Drawing.Color.Red;
            this.lWrongLogData.Location = new System.Drawing.Point(29, 67);
            this.lWrongLogData.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lWrongLogData.Name = "lWrongLogData";
            this.lWrongLogData.Size = new System.Drawing.Size(187, 14);
            this.lWrongLogData.TabIndex = 7;
            this.lWrongLogData.Text = "Passwort oder Benutzername falsch!";
            this.lWrongLogData.Visible = false;
            // 
            // frLogIn
            // 
            this.AcceptButton = this.bLogIn;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(338, 275);
            this.Controls.Add(this.lWrongLogData);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bLogIn);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.lPassword);
            this.Controls.Add(this.lName);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.lInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frLogIn";
            this.ShowInTaskbar = false;
            this.Text = "LogIn";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lInfo;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label lName;
        private System.Windows.Forms.Label lPassword;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Button bLogIn;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.Label lWrongLogData;
    }
}