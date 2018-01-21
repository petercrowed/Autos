using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
    public class LeihscheinButton : Button
    {
        private frMain m;
        
        public LeihscheinButton(frMain m) : base()
        {
            this.m = m;
            this.Click += new System.EventHandler(this.bLeihscheinButton_Click);
        }

		/// <summary>
		/// opens new leihscheinfrom for a rent in english or german
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bLeihscheinButton_Click(object sender, EventArgs e)
        {
            frLeihschein l = new frLeihschein(m.rentList.getRentsByUser(m.currentUser)[(int)this.Tag], m.languageEnglisch);
            if (!m.languageEnglisch)
                l.setInfoText(!m.languageEnglisch, m.rentList.getRentsByUser(m.currentUser)[(int)this.Tag].car.infosDE);
            else
                l.setInfoText(!m.languageEnglisch, m.rentList.getRentsByUser(m.currentUser)[(int)this.Tag].car.infosENG);

            l.ShowDialog();
        }
    }
}
