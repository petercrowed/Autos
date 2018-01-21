using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    class HolidaySaveButton : Button
    {
        private frMain m;
        private DateTimePicker dtp;

        public HolidaySaveButton(frMain m, DateTimePicker dtp) : base()
        {
            this.m = m;
            this.dtp = dtp;
            this.Click += new System.EventHandler(this.holidaySaveButton_Click);
        }

		/// <summary>
		/// saves changes of a holiday by name of the holiday
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void holidaySaveButton_Click(object sender, EventArgs e)
        {
            m.saveHolidayChanges((string)this.Tag, dtp.Value);
        }
    }
    
}
