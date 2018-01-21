using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    public partial class frNewHoliday : Form
    {

        private frMain m;

        public frNewHoliday(frMain m)
        {
            this.m = m;
            InitializeComponent();
			if (m.languageEnglisch)
				languageSetEnglish(); 
        }


		/// <summary>
		/// sets the Language of the form
		/// </summary>
		private void languageSetEnglish()
		{
			this.Text = "New Holiday";
			this.lTitle.Text = "Name of new holiday:";
			this.lTitle2.Text = "Day of the new holiday:";
			this.bSave.Text = "Save";
			this.bCancel.Text = "Cancel";
		}

		/// <summary>
		/// checks if datas are correct and creates a new Holiday
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
        {
			string menuName = (m.languageEnglisch) ? "Holiday menu" : "Feiertags Menü";
            if (!tbName.Text.Equals("")) 
            {
                if (m.holidays.ContainsKey(tbName.Text))
                {
					string s = (m.languageEnglisch) ? "Name already exists" : "Name existiert bereits";
					MessageBox.Show(s, menuName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else if (m.holidays.ContainsValue(dtpDate.Value))
				{
					string s = (m.languageEnglisch) ? "The day is already a holiday" : "Der Tag ist bereits ein Feiertag";
					MessageBox.Show(s, menuName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
					string s = (m.languageEnglisch) ? "Holiday successfully created" : "Feiertag erfolgreich angelegt";
					m.holidays.Add(this.tbName.Text, this.dtpDate.Value);
                    MessageBox.Show(s, menuName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m.repaintHolidayMenu();
                    this.Close();
                }
            }
            else
            {
				string s = (m.languageEnglisch) ? "First enter a name" : "Zuerst einen Namen eingeben";
				MessageBox.Show(s, menuName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

		/// <summary>
		/// closes form without doing anything
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
