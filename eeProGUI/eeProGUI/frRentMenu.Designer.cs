namespace eeProGUI
{
    partial class frRentMenu
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frRentMenu));
            this.rbRent = new System.Windows.Forms.RadioButton();
            this.lTitle = new System.Windows.Forms.Label();
            this.rbRes = new System.Windows.Forms.RadioButton();
            this.lFrom = new System.Windows.Forms.Label();
            this.lUntil = new System.Windows.Forms.Label();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.tlpCalendar = new System.Windows.Forms.TableLayoutPanel();
            this.pTitel = new System.Windows.Forms.Panel();
            this.bRight = new System.Windows.Forms.Button();
            this.bLeft = new System.Windows.Forms.Button();
            this.lMonth = new System.Windows.Forms.Label();
            this.lTuesday = new System.Windows.Forms.Label();
            this.lWendsday = new System.Windows.Forms.Label();
            this.lThursday = new System.Windows.Forms.Label();
            this.lFriday = new System.Windows.Forms.Label();
            this.lSaturdy = new System.Windows.Forms.Label();
            this.lSunday = new System.Windows.Forms.Label();
            this.lMonday = new System.Windows.Forms.Label();
            this.tlpDays = new System.Windows.Forms.TableLayoutPanel();
            this.pBackgrounCalendar = new System.Windows.Forms.Panel();
            this.lYear = new System.Windows.Forms.Label();
            this.dtpVon = new System.Windows.Forms.DateTimePicker();
            this.dtpBis = new System.Windows.Forms.DateTimePicker();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pTitel.SuspendLayout();
            this.tlpDays.SuspendLayout();
            this.pBackgrounCalendar.SuspendLayout();
            this.SuspendLayout();
            // 
            // rbRent
            // 
            this.rbRent.AutoSize = true;
            this.rbRent.Checked = true;
            this.rbRent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRent.Location = new System.Drawing.Point(37, 43);
            this.rbRent.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbRent.Name = "rbRent";
            this.rbRent.Size = new System.Drawing.Size(69, 20);
            this.rbRent.TabIndex = 0;
            this.rbRent.TabStop = true;
            this.rbRent.Text = "Leihen";
            this.rbRent.UseVisualStyleBackColor = true;
            // 
            // lTitle
            // 
            this.lTitle.AutoSize = true;
            this.lTitle.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTitle.Location = new System.Drawing.Point(28, 9);
            this.lTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTitle.Name = "lTitle";
            this.lTitle.Size = new System.Drawing.Size(281, 19);
            this.lTitle.TabIndex = 1;
            this.lTitle.Text = "Neue Reservierung/Verleih erstellen";
            // 
            // rbRes
            // 
            this.rbRes.AutoSize = true;
            this.rbRes.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbRes.Location = new System.Drawing.Point(36, 67);
            this.rbRes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.rbRes.Name = "rbRes";
            this.rbRes.Size = new System.Drawing.Size(111, 20);
            this.rbRes.TabIndex = 2;
            this.rbRes.TabStop = true;
            this.rbRes.Text = "Reservierung";
            this.rbRes.UseVisualStyleBackColor = true;
            // 
            // lFrom
            // 
            this.lFrom.AutoSize = true;
            this.lFrom.Font = new System.Drawing.Font("Arial", 10.2F);
            this.lFrom.Location = new System.Drawing.Point(33, 102);
            this.lFrom.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFrom.Name = "lFrom";
            this.lFrom.Size = new System.Drawing.Size(36, 16);
            this.lFrom.TabIndex = 5;
            this.lFrom.Text = "Von:";
            // 
            // lUntil
            // 
            this.lUntil.AutoSize = true;
            this.lUntil.Font = new System.Drawing.Font("Arial", 10.2F);
            this.lUntil.Location = new System.Drawing.Point(34, 132);
            this.lUntil.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lUntil.Name = "lUntil";
            this.lUntil.Size = new System.Drawing.Size(31, 16);
            this.lUntil.TabIndex = 6;
            this.lUntil.Text = "Bis:";
            // 
            // bSave
            // 
            this.bSave.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bSave.Location = new System.Drawing.Point(97, 435);
            this.bSave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(92, 24);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Speichern";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bCancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bCancel.Location = new System.Drawing.Point(207, 435);
            this.bCancel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(92, 24);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Abbrechen";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // tlpCalendar
            // 
            this.tlpCalendar.BackColor = System.Drawing.SystemColors.Info;
            this.tlpCalendar.ColumnCount = 9;
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpCalendar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpCalendar.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tlpCalendar.Location = new System.Drawing.Point(32, 239);
            this.tlpCalendar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpCalendar.Name = "tlpCalendar";
            this.tlpCalendar.RowCount = 6;
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tlpCalendar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpCalendar.Size = new System.Drawing.Size(267, 147);
            this.tlpCalendar.TabIndex = 10;
            // 
            // pTitel
            // 
            this.pTitel.BackColor = System.Drawing.SystemColors.Control;
            this.pTitel.Controls.Add(this.bRight);
            this.pTitel.Controls.Add(this.bLeft);
            this.pTitel.Controls.Add(this.lMonth);
            this.pTitel.Location = new System.Drawing.Point(32, 164);
            this.pTitel.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pTitel.Name = "pTitel";
            this.pTitel.Size = new System.Drawing.Size(267, 50);
            this.pTitel.TabIndex = 8;
            // 
            // bRight
            // 
            this.bRight.BackColor = System.Drawing.SystemColors.Control;
            this.bRight.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bRight.Location = new System.Drawing.Point(218, 2);
            this.bRight.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bRight.Name = "bRight";
            this.bRight.Size = new System.Drawing.Size(25, 30);
            this.bRight.TabIndex = 10;
            this.bRight.Text = ">";
            this.bRight.UseVisualStyleBackColor = false;
            this.bRight.Click += new System.EventHandler(this.bRight_Click);
            // 
            // bLeft
            // 
            this.bLeft.BackColor = System.Drawing.SystemColors.Control;
            this.bLeft.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.bLeft.Location = new System.Drawing.Point(26, 0);
            this.bLeft.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.bLeft.Name = "bLeft";
            this.bLeft.Size = new System.Drawing.Size(25, 30);
            this.bLeft.TabIndex = 9;
            this.bLeft.Text = "<";
            this.bLeft.UseVisualStyleBackColor = false;
            this.bLeft.Click += new System.EventHandler(this.bLeft_Click);
            // 
            // lMonth
            // 
            this.lMonth.BackColor = System.Drawing.SystemColors.Control;
            this.lMonth.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMonth.Location = new System.Drawing.Point(61, 9);
            this.lMonth.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMonth.Name = "lMonth";
            this.lMonth.Size = new System.Drawing.Size(150, 30);
            this.lMonth.TabIndex = 8;
            this.lMonth.Text = "Month";
            this.lMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTuesday
            // 
            this.lTuesday.AutoSize = true;
            this.lTuesday.BackColor = System.Drawing.SystemColors.Info;
            this.lTuesday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lTuesday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTuesday.Location = new System.Drawing.Point(55, 0);
            this.lTuesday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lTuesday.Name = "lTuesday";
            this.lTuesday.Size = new System.Drawing.Size(28, 30);
            this.lTuesday.TabIndex = 1;
            this.lTuesday.Text = "Di";
            this.lTuesday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lWendsday
            // 
            this.lWendsday.AutoSize = true;
            this.lWendsday.BackColor = System.Drawing.SystemColors.Info;
            this.lWendsday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lWendsday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWendsday.Location = new System.Drawing.Point(87, 0);
            this.lWendsday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lWendsday.Name = "lWendsday";
            this.lWendsday.Size = new System.Drawing.Size(28, 30);
            this.lWendsday.TabIndex = 2;
            this.lWendsday.Text = "Mi";
            this.lWendsday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lThursday
            // 
            this.lThursday.AutoSize = true;
            this.lThursday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lThursday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lThursday.Location = new System.Drawing.Point(119, 0);
            this.lThursday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lThursday.Name = "lThursday";
            this.lThursday.Size = new System.Drawing.Size(28, 30);
            this.lThursday.TabIndex = 3;
            this.lThursday.Text = "Do";
            this.lThursday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lFriday
            // 
            this.lFriday.AutoSize = true;
            this.lFriday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lFriday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFriday.Location = new System.Drawing.Point(151, 0);
            this.lFriday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lFriday.Name = "lFriday";
            this.lFriday.Size = new System.Drawing.Size(28, 30);
            this.lFriday.TabIndex = 4;
            this.lFriday.Text = "Fr";
            this.lFriday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSaturdy
            // 
            this.lSaturdy.AutoSize = true;
            this.lSaturdy.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSaturdy.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSaturdy.Location = new System.Drawing.Point(183, 0);
            this.lSaturdy.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSaturdy.Name = "lSaturdy";
            this.lSaturdy.Size = new System.Drawing.Size(28, 30);
            this.lSaturdy.TabIndex = 5;
            this.lSaturdy.Text = "Sa";
            this.lSaturdy.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSunday
            // 
            this.lSunday.AutoSize = true;
            this.lSunday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lSunday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSunday.Location = new System.Drawing.Point(215, 0);
            this.lSunday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lSunday.Name = "lSunday";
            this.lSunday.Size = new System.Drawing.Size(28, 30);
            this.lSunday.TabIndex = 6;
            this.lSunday.Text = "So";
            this.lSunday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lMonday
            // 
            this.lMonday.AutoSize = true;
            this.lMonday.BackColor = System.Drawing.SystemColors.Info;
            this.lMonday.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lMonday.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lMonday.Location = new System.Drawing.Point(23, 0);
            this.lMonday.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lMonday.Name = "lMonday";
            this.lMonday.Size = new System.Drawing.Size(28, 30);
            this.lMonday.TabIndex = 7;
            this.lMonday.Text = "Mo";
            this.lMonday.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlpDays
            // 
            this.tlpDays.BackColor = System.Drawing.SystemColors.Info;
            this.tlpDays.ColumnCount = 9;
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDays.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tlpDays.Controls.Add(this.lMonday, 1, 0);
            this.tlpDays.Controls.Add(this.lTuesday, 2, 0);
            this.tlpDays.Controls.Add(this.lSaturdy, 6, 0);
            this.tlpDays.Controls.Add(this.lSunday, 7, 0);
            this.tlpDays.Controls.Add(this.lFriday, 5, 0);
            this.tlpDays.Controls.Add(this.lThursday, 4, 0);
            this.tlpDays.Controls.Add(this.lWendsday, 3, 0);
            this.tlpDays.Location = new System.Drawing.Point(32, 209);
            this.tlpDays.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.tlpDays.Name = "tlpDays";
            this.tlpDays.RowCount = 1;
            this.tlpDays.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpDays.Size = new System.Drawing.Size(267, 30);
            this.tlpDays.TabIndex = 11;
            // 
            // pBackgrounCalendar
            // 
            this.pBackgrounCalendar.BackColor = System.Drawing.SystemColors.Info;
            this.pBackgrounCalendar.Controls.Add(this.lYear);
            this.pBackgrounCalendar.Location = new System.Drawing.Point(32, 239);
            this.pBackgrounCalendar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.pBackgrounCalendar.Name = "pBackgrounCalendar";
            this.pBackgrounCalendar.Size = new System.Drawing.Size(267, 178);
            this.pBackgrounCalendar.TabIndex = 12;
            // 
            // lYear
            // 
            this.lYear.BackColor = System.Drawing.SystemColors.Info;
            this.lYear.Font = new System.Drawing.Font("Arial", 10.8F);
            this.lYear.Location = new System.Drawing.Point(58, 149);
            this.lYear.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lYear.Name = "lYear";
            this.lYear.Size = new System.Drawing.Size(153, 23);
            this.lYear.TabIndex = 11;
            this.lYear.Text = "Year";
            this.lYear.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtpVon
            // 
            this.dtpVon.Location = new System.Drawing.Point(90, 98);
            this.dtpVon.Name = "dtpVon";
            this.dtpVon.Size = new System.Drawing.Size(200, 20);
            this.dtpVon.TabIndex = 13;
            // 
            // dtpBis
            // 
            this.dtpBis.Location = new System.Drawing.Point(90, 128);
            this.dtpBis.Name = "dtpBis";
            this.dtpBis.Size = new System.Drawing.Size(200, 20);
            this.dtpBis.TabIndex = 14;
            this.dtpBis.Value = new System.DateTime(2017, 5, 27, 10, 52, 39, 0);
            // 
            // frRentMenu
            // 
            this.AcceptButton = this.bSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.CancelButton = this.bCancel;
            this.ClientSize = new System.Drawing.Size(325, 470);
            this.Controls.Add(this.dtpBis);
            this.Controls.Add(this.dtpVon);
            this.Controls.Add(this.tlpCalendar);
            this.Controls.Add(this.pBackgrounCalendar);
            this.Controls.Add(this.tlpDays);
            this.Controls.Add(this.pTitel);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bSave);
            this.Controls.Add(this.lUntil);
            this.Controls.Add(this.lFrom);
            this.Controls.Add(this.rbRes);
            this.Controls.Add(this.lTitle);
            this.Controls.Add(this.rbRent);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frRentMenu";
            this.ShowInTaskbar = false;
            this.Text = "Verleih Manager";
            this.TopMost = true;
            this.pTitel.ResumeLayout(false);
            this.tlpDays.ResumeLayout(false);
            this.tlpDays.PerformLayout();
            this.pBackgrounCalendar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rbRent;
        private System.Windows.Forms.Label lTitle;
        private System.Windows.Forms.RadioButton rbRes;
        private System.Windows.Forms.Label lFrom;
        private System.Windows.Forms.Label lUntil;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Button bCancel;
        private System.Windows.Forms.TableLayoutPanel tlpCalendar;
        private System.Windows.Forms.Label lTuesday;
        private System.Windows.Forms.Label lWendsday;
        private System.Windows.Forms.Label lThursday;
        private System.Windows.Forms.Label lFriday;
        private System.Windows.Forms.Label lSaturdy;
        private System.Windows.Forms.Label lSunday;
        private System.Windows.Forms.Label lMonday;
        private System.Windows.Forms.Label lMonth;
        private System.Windows.Forms.Panel pTitel;
        private System.Windows.Forms.Button bLeft;
        private System.Windows.Forms.Button bRight;
        private System.Windows.Forms.TableLayoutPanel tlpDays;
        private System.Windows.Forms.Panel pBackgrounCalendar;
        private System.Windows.Forms.Label lYear;
        private System.Windows.Forms.DateTimePicker dtpVon;
        private System.Windows.Forms.DateTimePicker dtpBis;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}