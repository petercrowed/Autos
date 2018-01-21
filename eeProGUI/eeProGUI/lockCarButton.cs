using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    class lockCarButton : Button
    {

        private frMain m;
        public lockCarButton(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.lockCarButton_Click);
        }

		/// <summary>
		/// toggles car blocked satuts bay car index
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void lockCarButton_Click(object sender, EventArgs e)
        {
            m.toggleLockCar((int)this.Tag);
        }
    }
}
