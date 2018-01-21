using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    public class ChangeRentButton : Button
    {
        private frMain m;
        public ChangeRentButton(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.bChangeRent_Click);
        }

		/// <summary>
		/// changes reservation to rent by index of the rent
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bChangeRent_Click(object sender, EventArgs e)
        {
            m.changedResToRent((int)this.Tag);
        }
    }
}
