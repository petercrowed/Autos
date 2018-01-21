using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    public class DeleteRentButton : Button
    {
        frMain m;

        public DeleteRentButton(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.bDeleteRent_Click);
        }

		/// <summary>
		/// deletes rental or reservation by index
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bDeleteRent_Click(object sender, EventArgs e)
        {
            m.deleteRent((int)this.Tag);
        }

    }
}
