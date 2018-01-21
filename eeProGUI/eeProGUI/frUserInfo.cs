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
    public partial class frUserInfo : Form
    {
        private frMain m;
        private User user;

        public frUserInfo(frMain m, User user)
        {
            this.m = m;
            this.user = user;
            InitializeComponent();
            setInfos();
            setRentBox();
			if (m.languageEnglisch)
				englishUser();
        }

		/// <summary>
		/// sets language to english
		/// </summary>
		private void englishUser()
		{
			this.Text = "Userwindow";
			this.lTitle.Text = "User information";
			this.lTitleName.Text = "User:";
			this.lAdressTitle.Text = "Adress";
		}

		/// <summary>
		/// sets name and adress of the user
		/// </summary>
        private void setInfos()
        {
            this.lName.Text = user.name;
            this.lStreet.Text = user.adress.street + " " + user.adress.houseNr;
            this.lPlace.Text = user.adress.plz + " " + user.adress.place;
        }

		/// <summary>
		/// set all rentPanels
		/// </summary>
        private void setRentBox()
        {
            foreach(Rents rent in m.rentList.getRentsByUser(user))
            {
                if (rent.endTime.CompareTo(DateTime.Today) >= 0)
                {
                    createSingleRentPanel(rent);
                }
            }
        }

		/// <summary>
		/// creats single rentpanel by rent
		/// </summary>
		/// <param name="rent">displayed rent</param>
        private void createSingleRentPanel(Rents rent)
        {
            Panel pRentBG = new Panel();
            Label lUntil = new Label();
            Label lFrom = new Label();
            Label lRentRes = new Label();
            Label lCarName = new Label();

            pRentBG.SuspendLayout();
            // 
            // pRentBG
            // 
            pRentBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pRentBG.Controls.Add(lUntil);
            pRentBG.Controls.Add(lFrom);
            pRentBG.Controls.Add(lRentRes);
            pRentBG.Controls.Add(lCarName);
            pRentBG.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            pRentBG.Location = new System.Drawing.Point(3, 3);
            pRentBG.Name = "pRentBG";
            pRentBG.Size = new System.Drawing.Size(545, 50);
            pRentBG.TabIndex = 0;
            // 
            // lCarName
            // 
            lCarName.AutoSize = true;
            lCarName.Location = new System.Drawing.Point(129, 11);
            lCarName.Name = "lCarName";
            lCarName.Size = new System.Drawing.Size(82, 19);
            lCarName.TabIndex = 0;
            lCarName.Text = rent.car.name;
            // 
            // lRentRes
            // 
            lRentRes.AutoSize = true;
            lRentRes.Location = new System.Drawing.Point(3, 11);
            lRentRes.Name = "lRentRes";
            lRentRes.Size = new System.Drawing.Size(105, 19);
            lRentRes.TabIndex = 1;
			if (m.languageEnglisch)
			{
				lRentRes.Text = (rent.rent) ? "Rented" : "Reserved";
			}
			else
			{
				lRentRes.Text = (rent.rent) ? "Ausgeliehen" : "Reseviert";
			}
            // 
            // lFrom
            // 
            lFrom.AutoSize = true;
            lFrom.Location = new System.Drawing.Point(270, 11);
            lFrom.Name = "lFrom";
            lFrom.Size = new System.Drawing.Size(42, 19);
            lFrom.TabIndex = 2;
            lFrom.Text = (m.languageEnglisch) ? ("From: " + rent.startTime.ToShortDateString()) : ("Von: " + rent.startTime.ToShortDateString());
            // 
            // lUntil
            // 
            lUntil.AutoSize = true;
            lUntil.Location = new System.Drawing.Point(417, 11);
            lUntil.Name = "lUntil";
            lUntil.Size = new System.Drawing.Size(37, 19);
            lUntil.TabIndex = 3;
            lUntil.Text = (m.languageEnglisch) ? ("To: " + rent.endTime.ToShortDateString()) : ("Bis: " + rent.endTime.ToShortDateString());

			pRentBG.ResumeLayout(false);
            pRentBG.PerformLayout();
            this.flpResRents.Controls.Add(pRentBG);
        }
    }
}
