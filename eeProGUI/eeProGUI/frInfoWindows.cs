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
	/// <summary>
	/// Creats a from with info icon and the given text
	/// </summary>
	public partial class frInfoWindows : Form
    {
        public frInfoWindows(string aboutInfo)
        {
            InitializeComponent();
            this.lAbout.Text = aboutInfo;
           
        }
    }
}
