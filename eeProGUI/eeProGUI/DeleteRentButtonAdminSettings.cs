using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    class DeleteRentButtonAdminSettings : Button
    {

        frMain m;

        public DeleteRentButtonAdminSettings(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.DeleteRentButtonAdminSettings_Click);
        }

		/// <summary>
		/// delete rental or reservation by index
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void DeleteRentButtonAdminSettings_Click(object sender, EventArgs e)
        {
            m.deleteRentAdminMenu((int)this.Tag);
        }
    }
}
