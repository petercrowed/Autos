using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    class HolidaysDeleteButton : Button
    {
        private frMain m;

        public HolidaysDeleteButton(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.holidaySaveButton_Click);
        }

		/// <summary>
		/// deletes holiday by name
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void holidaySaveButton_Click(object sender, EventArgs e)
        {
            m.deleteHoliday((string)this.Tag);
        }
    }
}
