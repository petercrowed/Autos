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
	/// Form for the Login of the user
	/// </summary>
    public partial class frLogIn : Form
    {

        private frMain m;

        public frLogIn(frMain m)
        {
            this.m = m;
            InitializeComponent();
			if (m.languageEnglisch)
				languageSetEnglish();
        }
        
		/// <summary>
		/// sets the language to english
		/// </summary>
		private void languageSetEnglish()
		{
			this.lInfo.Text = "Please enter your registration details here:";
			this.lWrongLogData.Text = "Password or username wrong!";
			this.lName.Text = "Username";
			this.lPassword.Text = "Password";
			this.bLogIn.Text = "Log In";
			this.bCancel.Text = "Cancel";
		}

		#region "buttonfunctions"
		/// <summary>
		/// closing the Form without doing anything
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		/// <summary>
		/// if the LogData are correct the user is logged, the Form closed and current user is set in 
		/// else the WrongLogData Button is set
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bLogIn_Click(object sender, EventArgs e)
        {
            bool found = false;
            foreach(User user in m.userList)
            {
                if(user.username.Equals(tbName.Text) && user.password.Equals(tbPassword.Text))
                {
                    found = true;
                    m.currentUser = user;
                }
            }
            if (found)
            {
				string s = (m.languageEnglisch) ? "LogOut" : "Abmelden";
                m.setBLogText(s);
                m.setButtonVisibility(true);
                if (m.currentUser.admin)
                {
                    m.setAdminButtonVisibility(true);
                }
                this.Close();
            }
            else
            {
                lWrongLogData.Visible = true;
            }
        }
        #endregion
    }
}
