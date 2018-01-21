using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eeProGUI
{
	/// <summary>
	/// creates a window with the libary ticket displayed
	/// </summary>
    public partial class frLeihschein : Form
    {

        private Rents rent;

        public frLeihschein(Rents rent, bool english)
        {
            this.rent = rent;
            InitializeComponent();
            setHeadText();
			
        }

		#region "setTexts"
		/// <summary>
		/// sets the Informations of the receiver
		/// </summary>
		private void setHeadText()
        {
            this.lName.Text = rent.user.name;
            this.lStreet.Text = rent.user.adress.street + " " + rent.user.adress.houseNr;
            this.lplace.Text = rent.user.adress.plz + " " + rent.user.adress.place;
            this.lTime.Text = rent.endTime.ToShortDateString();
            this.lCarName.Text = rent.car.name;
        }

		/// <summary>
		/// sets the informations of the car in english or german
		/// </summary>
		/// <param name="german">true when the language is german</param>
		/// <param name="infos">the infos of the car</param>
        public void setInfoText(bool german, Dictionary<string, string> infos)
        {
            if (german)
            {
                this.lTitelFuel.Text = "Kraftstoff:";
                this.lTitelGears.Text = "Getriebe:";
                this.lTitelHp.Text = "PS:";
                this.lTitelSeats.Text = "Sitze:";
                this.lTitelDoors.Text = "Türen:";
                this.lTitelStorageLoc.Text = "Lagerort:";
            }
            else
			{
				this.lCar.Text = "Awarded product";
				this.lAn.Text = "Receiver";
				this.lTitel.Text = "Libary ticket";
				this.lBackTime.Text = "Return time";
                this.lTitelFuel.Text = "Fuel:";
                this.lTitelGears.Text = "Gears:";
                this.lTitelHp.Text = "HP:";
                this.lTitelSeats.Text = "Seats:";
                this.lTitelDoors.Text = "Doors:";
                this.lTitelStorageLoc.Text = "Storage:";
            }

            this.lFuel.Text = infos["fuel"];
            this.lGears.Text = infos["gears"];
            this.lHp.Text = infos["hp"];
            this.lSeats.Text = infos["seats"];
            this.lDoors.Text = infos["doors"];
            this.lStorageLoc.Text = infos["storage"];
        }
		#endregion
	}
}
