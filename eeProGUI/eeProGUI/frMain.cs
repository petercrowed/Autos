using eeProGUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.Globalization;


namespace eeProGUI
{
    public partial class frMain : Form
    {
        public List<Car> carList { get; set; } = new List<Car>();
        public List<User> userList { get; set; }
        public int currentCar { get; set; } = 0;
        public User currentUser { get; set; }
        public RentList rentList { get; set; } = new RentList();
        public Dictionary<String, DateTime> holidays { get; set; } = new Dictionary<string, DateTime>();
        public ResourceManager res_man;    // declare Resource manager to access to specific cultureinfo
        public CultureInfo cul;            // declare culture info
        public bool languageEnglisch { get; set; }

		/// <summary>
		/// Constructor which initialize the components, reads the xml files and set the Info Text
		/// </summary>
        public frMain()
        {
            userList = new List<User>();
            //this.german = true;
            InitializeComponent();
            InitializeUserlist();
            InitializeCarList();
            InitializeRentList();
            InitializeSearchBox();
            InitializeHolidays();
            initLanguagBox();
            setInfos();
            setImages();

        }
		
        #region "initFunctions"
		/// <summary>
		/// reads carList.xml and sets the attribut carList
		/// </summary>
        private void InitializeCarList()
        {
            XmlReader reader = XmlReader.Create(@"carList.xml");
            int index = 0;
            Car car = null;
            List<System.Drawing.Image> carImages = new List<System.Drawing.Image>();
            Dictionary<string, string> info = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "car":
                            car = new Car();
                            car.index = index;
                            index++;
                            carList.Add(car);
                            break;
                        case "name":
                            car.name = reader.ReadElementContentAsString();
                            break;
                        case "rent":
                            car.gesperrt = reader.ReadElementContentAsBoolean();
                            break;
                        case "image":
                            car.addImage(GetImageByName(reader.ReadElementContentAsString()));
                            break;
                        case "infoDE":
                            info = new Dictionary<string, string>();
                            car.infosDE = info;
                            break;
                        case "infoENG":
                            info = new Dictionary<string, string>();
                            car.infosENG = info;
                            break;
                        case "fuel":
                            info.Add("fuel", reader.ReadElementContentAsString());
                            break;
                        case "gears":
                            info.Add("gears", reader.ReadElementContentAsString());
                            break;
                        case "hp":
                            info.Add("hp", reader.ReadElementContentAsString());
                            break;
                        case "seats":
                            info.Add("seats", reader.ReadElementContentAsString());
                            break;
                        case "doors":
                            info.Add("doors", reader.ReadElementContentAsString());
                            break;
                        case "storage":
                            info.Add("storage", reader.ReadElementContentAsString());
                            break;
                    }
                }
            }
            reader.Close();
        }

		/// <summary>
		/// adds the names of all cars and users to the search box for suggest
		/// </summary>
        private void InitializeSearchBox()
        {
            List<string> cars = Resources.MyXmlParser.GetItemsFromXmlUsingTagNames("carList.xml", "name");
            List<string> users = Resources.MyXmlParser.GetItemsFromXmlUsingTagNames("userListe.xml", "username");
            List<string> usersName = Resources.MyXmlParser.GetItemsFromXmlUsingTagNames("userListe.xml", "name");
            //Add them to the ComboBox

            for (int i = 0; i < cars.Count(); i++)
            {
                cars[i] += "(Car)";
             
            }

            for (int i = 0; i < users.Count(); i++)
            {
                users[i] += "(User)";
                usersName[i] += "(User)";
            }
            //cbSearch.Items.AddRange(cars.ToArray());
            //cbSearch.Items.AddRange(users.ToArray());
            //cbSearch.AutoCompleteCustomSource.AddRange(cars.ToArray());
            tbSearch.AutoCompleteCustomSource.AddRange(usersName.ToArray());
            tbSearch.AutoCompleteCustomSource.AddRange(users.ToArray());
            tbSearch.AutoCompleteCustomSource.AddRange(cars.ToArray());

        }

		/// <summary>
		/// reads all user from userListe.xml to the attribute userList
		/// </summary>
        private void InitializeUserlist()
        {
            XmlReader reader = XmlReader.Create(@"userListe.xml");
            User user = null;
            int index = 0;
            Adress adress = null;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "user":
                            user = new User();
                            user.index = index;
                            index++;
                            userList.Add(user);
                            break;
                        case "admin":
                            user.admin = reader.ReadElementContentAsBoolean();
                            break;
                        case "username":
                            user.username = reader.ReadElementContentAsString();
                            break;
                        case "password":
                            user.password = reader.ReadElementContentAsString();
                            break;
                        case "name":
                            user.name = reader.ReadElementContentAsString();
                            break;
                        case "adress":
                            adress = new Adress();
                            break;
                        case "street":
                            adress.street = reader.ReadElementContentAsString();
                            break;
                        case "housenr":
                            adress.houseNr = reader.ReadElementContentAsInt();
                            break;
                        case "plz":
                            adress.plz = reader.ReadElementContentAsInt();
                            break;
                        case "place":
                            adress.place = reader.ReadElementContentAsString();
                            user.adress = adress;
                            break;
                    }
                }
            }
            reader.Close();
        }

		/// <summary>
		/// reads all rents from rentListe.xml to the attribute rentList
		/// </summary>
		private void InitializeRentList()
        {
            XmlReader reader = XmlReader.Create(@"rentList.xml");
            Rents rent = null;
            bool v = true;
            int year = 0;
            int month = 0;
            int day = 0;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "rent":
                            rent = new Rents();
                            rentList.addRent(rent);
                            break;
                        case "rented":
                            //gleich zu as boolean
                            rent.rent = reader.ReadElementContentAsBoolean();
                            break;
                        case "car":
                            rent.car = carList[reader.ReadElementContentAsInt()];
                            break;
                        case "user":
                            rent.user = userList[reader.ReadElementContentAsInt()];
                            break;
                        case "dateV":
                            v = true;
                            break;
                        case "dateB":
                            v = false;
                            break;
                        case "year":
                            year = reader.ReadElementContentAsInt();
                            break;
                        case "month":
                            month = reader.ReadElementContentAsInt();
                            break;
                        case "day":
                            day = reader.ReadElementContentAsInt();
                            if (v)
                            {
                                rent.startTime = new DateTime(year, month, day);
                            }
                            else
                            {
                                rent.endTime = new DateTime(year, month, day);
                            }
                            break;
                    }
                }
            }
            reader.Close();
            foreach(Car c in carList)
            {
                foreach (Rents r in rentList.getRentsByCar(c)){
                    r.lockMarker = c.gesperrt;
                }
            }
        }

		/// <summary>
		/// reads all holidays from holidaysListe.xml to the attribute holidaysList
		/// </summary>
		private void InitializeHolidays()
        {
            XmlReader reader = XmlReader.Create(@"holidayList.xml");
            string name = "";
            int year = 0;
            int month = 0;
            int day = 0;
            while (reader.Read())
            {
                if (reader.NodeType == XmlNodeType.Element)
                {
                    switch (reader.Name)
                    {
                        case "name":
                            name = reader.ReadElementContentAsString();
                            break;
                        case "year":
                            year = reader.ReadElementContentAsInt();
                            break;
                        case "month":
                            month = reader.ReadElementContentAsInt();
                            break;
                        case "day":
                            day = reader.ReadElementContentAsInt();
                            holidays.Add(name, new DateTime(year, month, day));
                            break;
                    }
                }
            }
            reader.Close();
        }

		/// <summary>
		/// returns the image by the given sting path 
		/// </summary>
		/// <param name="imageName">path</param>
		/// <returns>Image</returns>
		private Bitmap GetImageByName(string imageName)
		{
			System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();
			Stream myStream = myAssembly.GetManifestResourceStream("eeProGUI.Resources." + imageName);
			//string[] resourceNames = myAssembly.GetManifestResourceNames();-> alle möglich eingaben für den String
			//string nameDerAssembly = myAssembly.GetName().Name; -> für Assemblyname
			return new Bitmap(myStream);
		}

		/// <summary>
		/// adds the Language name to the combobox
		/// </summary>
		private void initLanguagBox()
		{
			cbLanguageSelect.Items.Add("Deutsch");
			cbLanguageSelect.Items.Add("Englisch");
			cbLanguageSelect.SelectedIndex = 0;
		}
		#endregion

		#region "logg In"
		/// <summary>
		/// sets the text of the bLog in german and english
		/// </summary>
		/// <param name="s"></param>
		public void setBLogText(String s)
        {
            this.bLog.Text = s;
        }

		/// <summary>
		/// sets the visibility of the buttons which are only seen when you are logged in 
		/// </summary>
		/// <param name="visible"></param>
        public void setButtonVisibility(bool visible)
        {
            this.bRentRes.Visible = visible;
            this.bProfile.Visible = visible;
        }

		/// <summary>
		/// set the visiblity of the Admin Button
		/// </summary>
		/// <param name="visible"></param>
        public void setAdminButtonVisibility(bool visible)
        {
            this.bAdminSettings.Visible = visible;
        }

		/// <summary>
		/// opens frLogIn when no user is logged or is logs the current user out
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bLog_Click(object sender, EventArgs e)
        {
            if (bLog.Text.Equals("Anmelden")|| bLog.Text.Equals("LogIn"))
            {
                frLogIn logIn = new frLogIn(this);
                logIn.ShowDialog();
            }
            else
            {
                setButtonVisibility(false);
                setAdminButtonVisibility(false);
                currentUser = null;
                bLog.Text = (languageEnglisch) ? "LogIn" : "Anmelden";
            }

            
        }
        #endregion

        #region "page1"
        #region "ImageButtonfunctions"
		/// <summary>
		/// sets the image of Button1 as image to the pictureBox pbBigPicture
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void rbPic1_CheckedChanged(object sender, EventArgs e)
        {
            this.pbBigImage.Image = carList[currentCar].images[0];
        }

		/// <summary>
		/// sets the image of Button2 as image to the pictureBox pbBigPicture
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbPic2_CheckedChanged(object sender, EventArgs e)
        {
            this.pbBigImage.Image = carList[currentCar].images[1];
        }

		/// <summary>
		/// sets the image of Button3 as image to the pictureBox pbBigPicture
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbPic3_CheckedChanged(object sender, EventArgs e)
        {
            this.pbBigImage.Image = carList[currentCar].images[2];
        }

		/// <summary>
		/// sets the image of Button4 as image to the pictureBox pbBigPicture
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void rbPic4_CheckedChanged(object sender, EventArgs e)
        {
            this.pbBigImage.Image = carList[currentCar].images[3];
        }

		/// <summary>
		/// scrolls to the previous car of carList
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bArrowLeft_Click(object sender, EventArgs e)
        {
            previousCar();
        }

		/// <summary>
		/// scrolls to the next car of carList
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bArrowRight_Click(object sender, EventArgs e)
        {
            nextCar();
        }

		/// <summary>
		/// set the image of the Buttons to the right images of the car
		/// </summary>
        private void setImages()
        {
            if (carList[currentCar].gesperrt)
            {
                this.lLock.Visible = true;
            }
            else
            {
                this.lLock.Visible = false;
            }
            this.lCarName.Text = carList[currentCar].name;
            this.rbPic1.Checked = true;
            this.pbBigImage.Image = carList[currentCar].images[0];
            this.rbPic1.ImageList = carList[currentCar].il;
            this.rbPic2.ImageList = carList[currentCar].il;
            this.rbPic3.ImageList = carList[currentCar].il;
            this.rbPic4.ImageList = carList[currentCar].il;
        }

		/// <summary>
		/// increments the currentCar, when it is the last car it sets currentCar to 0.
		/// Repaints Infos and Images
		/// </summary>
        private void nextCar()
        {
            if (this.currentCar < carList.Count - 1)
            {
                this.currentCar++;
            }
            else
            {
                currentCar = 0;
            }
            setInfos();
            setImages();
        }

		/// <summary>
		/// decreases the currentCar, when it is the last car it sets currentCar to the last Car index:
		/// :repaints Infos and Images
		/// </summary>
		private void previousCar()
        {
            if (this.currentCar > 0)
            {
                this.currentCar--;
            }
            else
            {
                currentCar = carList.Count - 1;
            }
            setImages();
            setInfos();
        }
        #endregion
		
		/// <summary>
		/// sets the info of the car to the Form in the rigth language
		/// </summary>
        private void setInfos()
        {
            this.lCarName.Text = carList[currentCar].name;
            if (!languageEnglisch)
            {
                this.lFuel.Text = carList[currentCar].infosDE["fuel"];
                this.lGears.Text = carList[currentCar].infosDE["gears"];
                this.lHp.Text = carList[currentCar].infosDE["hp"];
                this.lSeats.Text = carList[currentCar].infosDE["seats"];
                this.lDoors.Text = carList[currentCar].infosDE["doors"];
                this.lStorageLoc.Text = carList[currentCar].infosDE["storage"];
                this.lStatus.Text = (rentList.checkIfCarIsRentedToday(carList[currentCar])) ? "ausgeliehen" : "zur Verfügung";
            }
            else
            {
                this.lFuel.Text = carList[currentCar].infosENG["fuel"];
                this.lGears.Text = carList[currentCar].infosENG["gears"];
                this.lHp.Text = carList[currentCar].infosENG["hp"];
                this.lSeats.Text = carList[currentCar].infosENG["seats"];
                this.lDoors.Text = carList[currentCar].infosENG["doors"];
                this.lStorageLoc.Text = carList[currentCar].infosENG["storage"];
				this.lStatus.Text = (rentList.checkIfCarIsRentedToday(carList[currentCar])) ? "rented" : "to disposal";

			}
        }

		/// <summary>
		/// reads the text of tbSearch and checks if there is a user or a car name which equals the text
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bSearch_Click(object sender, EventArgs e)
		{
			if (tbSearch.Text != "")
			{
				string text = tbSearch.Text;
				//List<Car> resultsCar = new List<Car>();
				//List<User> resultsUserName = new List<User>();
				bool notFound = true;
				String carWithoutTag = text.Replace("(Car)", "");
				foreach (Car c in carList)
				{
					if (c.name.ToLower().Equals(carWithoutTag.ToLower()))
					{
						currentCar = c.index;
						setImages();
						notFound = false;
					}
				}
					String userWithoutTag = text.Replace("(User)", "");
					foreach (User user in userList)
					{
					if (user.name.ToLower().Equals(userWithoutTag.ToLower()) || user.username.ToLower().Equals(userWithoutTag.ToLower()))
					{
						frUserInfo ui = new frUserInfo(this, user);
						ui.ShowDialog();
						notFound = false;
					}
					}
          
				if (notFound)
				{
					MessageBox.Show("Auto oder Benutzer nicht gefunden", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
        }

		/// <summary>
		/// opens the Rentmenu From when the car is not blocked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bRent_Click(object sender, EventArgs e)
        {
            if (!carList[currentCar].gesperrt)
            {
                frRentMenu rm = new frRentMenu(this);
                rm.ShowDialog();
            }
        }
		#endregion

		#region "page2"
		/// <summary>
		/// sets this page visibility to false and sets page1 visibility to true and resets the rentPanel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bBack_Click(object sender, EventArgs e)
        {
            pPage2.Visible = false;
            pPage1.Visible = true;
            deleteShowRentList();
			setImages();
        }

		/// <summary>
		/// sets page1 visibility to false and sets page2 visibility to true and sets the text and the shown Rents
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bProfile_Click(object sender, EventArgs e)
        {
            this.lNameUser.Text = currentUser.name;
            this.lStreetUser.Text = currentUser.adress.street + " " + currentUser.adress.houseNr;
            this.lPlaceUser.Text = currentUser.adress.plz + " " + currentUser.adress.place;
            pPage1.Visible = false;
            pPage2.Visible = true;
            refreshShowRentList();
        }

		/// <summary>
		/// changes reservation to rental by index
		/// </summary>
		/// <param name="i">index of reservation</param>
        public void changedResToRent(int i)
        {
            this.rentList.getRentsByUser(currentUser)[i].rent = true;
            deleteShowRentList();
            refreshShowRentList();
        }

		/// <summary>
		/// deletes a rental or reservation by index
		/// </summary>
		/// <param name="i">index of rental or reservation</param>
        public void deleteRent(int i)
        {
            rentList.rentList.Remove(rentList.getRentsByUser(currentUser)[i]);
            deleteShowRentList();
            refreshShowRentList();
        }

		/// <summary>
		/// repaint all rents of rentlist
		/// </summary>
        private void refreshShowRentList()
        {
            this.lNoRents.Visible = false;
            int tag = 0;
            int counter = 0;
            foreach (Rents r in rentList.getRentsByUser(currentUser))
            {
                //nur aktuelle anzeigen
                if (r.endTime.CompareTo(DateTime.Today) >= 0 || cbOldRents.Checked)
                {
                    addSingleRentPanel(r, tag);
                    counter++;
                }
                tag++;
            }
            if(counter == 0)
            {
                this.lNoRents.Visible = true;
            }
        }

		/// <summary>
		/// resets all rents of rentlist
		/// </summary>
        private void deleteShowRentList()
        {
            while (flpRentList.Controls.Count > 0)
            {
                flpRentList.Controls[0].Dispose();
            }
        }

		/// <summary>
		/// creates a single rent panel
		/// </summary>
		/// <param name="r">displayed rent</param>
		/// <param name="tag">index of the rent</param>
        private void addSingleRentPanel(Rents r, int tag)
        {
            Panel pRents = new Panel();
            Button bDeleteRent = new DeleteRentButton(this);
            Button bLeihschein = null;
            Button bChangeRent = null;
            if (!r.rent)
            {
                bChangeRent = new ChangeRentButton(this);
            }
            else
            {
                bLeihschein = new LeihscheinButton(this);
            }
            Label lUntil = new Label();
            Label lFrom = new Label();
            Label lUntilDate = new Label();
            Label lFromDate = new Label();
            Label lRent = new Label();
            Label lRentStatus = new Label();
            Label lCar = new Label();
            PictureBox pbRentetCar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbRentetCar)).BeginInit();
            // 
            // pRents
            // 
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                pRents.BackColor = Color.DarkGray;
            }
            pRents.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            if (!(cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0))
            {
                pRents.Controls.Add(bDeleteRent);
                if (!r.rent)
                {
                    pRents.Controls.Add(bChangeRent);
                }
                else
                {
                    pRents.Controls.Add(bLeihschein);
                }
            }
            pRents.Controls.Add(lUntil);
            pRents.Controls.Add(lFrom);
            pRents.Controls.Add(lUntilDate);
            pRents.Controls.Add(lFromDate);
            pRents.Controls.Add(lRent);
            pRents.Controls.Add(lRentStatus);
            pRents.Controls.Add(lCar);
            pRents.Controls.Add(pbRentetCar);
            pRents.Cursor = System.Windows.Forms.Cursors.Default;
            pRents.ForeColor = System.Drawing.SystemColors.ControlText;
            //pRents.Location = new System.Drawing.Point(3, 3);
            pRents.Name = "pRents";
            pRents.Size = new System.Drawing.Size(665, 90);
            //pRents.TabIndex = 0;
            this.flpRentList.Controls.Add(pRents);
            // 
            // bLeihschein
            // 
            if (r.rent && !(cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)) {
                bLeihschein.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bLeihschein.Location = new System.Drawing.Point(515, 13);
                bLeihschein.Name = "bLeihschein";
                bLeihschein.Size = new System.Drawing.Size(135, 28);
                //bLeihschein.TabIndex = tag;
                bLeihschein.Text = (languageEnglisch) ? "Library ticket" : "Leihschein";
                bLeihschein.UseVisualStyleBackColor = true;
                bLeihschein.Tag = tag;
            }
            // 
            // bDeleteRent
            // 
            if (!(cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)) { 
                bDeleteRent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bDeleteRent.Location = new System.Drawing.Point(515, 45);
                bDeleteRent.Name = "bDeleteRent";
                bDeleteRent.Size = new System.Drawing.Size(135, 28);
                //bDeleteRent.TabIndex = 6;
                bDeleteRent.Text = (languageEnglisch) ? "Delete" : "Löschen";
                bDeleteRent.UseVisualStyleBackColor = true;
                bDeleteRent.Tag = tag;
            }
            // 
            // bChangeRent
            // 
            if (!r.rent && !(cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0))
            {
                bChangeRent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                bChangeRent.Location = new System.Drawing.Point(515, 13);
                bChangeRent.Name = "bChangeRent";
                bChangeRent.Size = new System.Drawing.Size(135, 28);
                //bChangeRent.TabIndex = 5;
                bChangeRent.Text = (languageEnglisch) ? "Rental" : "Ausleihen";
                bChangeRent.UseVisualStyleBackColor = true;
                bChangeRent.Tag = tag;
            }
            // 
            // lUntil
            //
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lUntil.ForeColor = Color.DimGray;
            }
            lUntil.AutoSize = true;
            lUntil.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lUntil.Location = new System.Drawing.Point(295, 57);
            lUntil.Name = "lUntil";
            lUntil.Size = new System.Drawing.Size(37, 19);
            //lUntil.TabIndex = 4;
            lUntil.Text = (languageEnglisch) ? "To:" : "Bis:";
            // 
            // lUntilDate
            //
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lUntilDate.ForeColor = Color.DimGray;
            }
            lUntilDate.AutoSize = true;
            lUntilDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lUntilDate.Location = new System.Drawing.Point(330, 57);
            lUntilDate.Name = "lUntil";
            lUntilDate.Size = new System.Drawing.Size(37, 19);
            //lUntilDate.TabIndex = 4;
            lUntilDate.Text = r.endTime.ToShortDateString();
            // 
            // lFrom
            //
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lFrom.ForeColor = Color.DimGray;
            }
            lFrom.AutoSize = true;
            lFrom.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lFrom.Location = new System.Drawing.Point(135, 57);
            lFrom.Name = "lFrom";
            lFrom.Size = new System.Drawing.Size(42, 19);
            //lFrom.TabIndex = 3;
            lFrom.Text = (languageEnglisch) ? "From:" : "Von:";
            // 
            // lFromDate
            //
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lFromDate.ForeColor = Color.DimGray;
            }
            lFromDate.AutoSize = true;
            lFromDate.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lFromDate.Location = new System.Drawing.Point(170, 57);
            lFromDate.Name = "lFrom";
            lFromDate.Size = new System.Drawing.Size(42, 19);
            //lFromDate.TabIndex = 3;
            lFromDate.Text = r.startTime.ToShortDateString();
            // 
            // lRent
            // 
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lRent.ForeColor = Color.DimGray;
            }
            lRent.AutoSize = true;
            lRent.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lRent.Location = new System.Drawing.Point(135, 35);
            lRent.Name = "lRent";
            lRent.Size = new System.Drawing.Size(157, 19);
            //lRent.TabIndex = 2;
            lRent.Text = "Status:";
            // 
            // lRentStatus
            //  
            lRentStatus.AutoSize = true;
            lRentStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lRentStatus.Location = new System.Drawing.Point(195, 35);
            lRentStatus.Name = "lRent";
            lRentStatus.Size = new System.Drawing.Size(157, 19);
            //lRent.TabIndex = 2;
            if (r.rent && !r.lockMarker)
            {
                lRentStatus.Text = (languageEnglisch) ? "Rented" : "Geliehen";
            }
            else if (!r.rent && !r.lockMarker)
            {
                lRentStatus.Text = (languageEnglisch) ? "Reserved" : "Reserviert";
            }
            else
            {
                lRentStatus.ForeColor = Color.Red;
                lRentStatus.Text = (languageEnglisch) ? "Blocked" : "Gesperrt!";
            }
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lRentStatus.ForeColor = Color.DimGray;
            }

            // 
            // lCar
            //   
            if (cbOldRents.Checked && r.endTime.CompareTo(DateTime.Today) < 0)
            {
                lCar.ForeColor = Color.DimGray;
            }
            lCar.AutoSize = true;
            lCar.Font = new System.Drawing.Font("Arial", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCar.Location = new System.Drawing.Point(135, 3);
            lCar.Name = "lCar";
            lCar.Size = new System.Drawing.Size(89, 29);
            //lCar.TabIndex = 1;
            lCar.Text = r.car.name;
            // 
            // pbRentetCar
            // 
            pbRentetCar.Image = r.car.images[0];
            pbRentetCar.Location = new System.Drawing.Point(10, 7);
            pbRentetCar.Name = "pbRentetCar";
            pbRentetCar.Size = new System.Drawing.Size(120, 75);
            pbRentetCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            //pbRentetCar.TabIndex = 0;
            pbRentetCar.TabStop = false;

            pRents.ResumeLayout(false);
            pRents.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)(pbRentetCar)).EndInit();
        }

		/// <summary>
		/// when it is checked the old entrys are shown
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void cbOldRents_CheckedChanged(object sender, EventArgs e)
        {
            deleteShowRentList();
            refreshShowRentList();
        }
		#endregion

		#region "page3"
		#region "controlButtons"
		/// <summary>
		/// sets page1 visibility to false and sets page3 visibility to true and paint panels of rentMenu
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bAdminSettings_Click(object sender, EventArgs e)
        {
            pPage1.Visible = false;
            pPage3.Visible = true;
            this.rBRes.Checked = true;
            this.cbAdminShowOld.Visible = true;
            deleteShowInfos();
            setAllRentMenuPanels();
        }

		/// <summary>
		/// sets this page visibility to false and sets page1 visibility to true
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bABack_Click(object sender, EventArgs e)
        {
            pPage3.Visible = false;
            pPage1.Visible = true;
            setImages();
        }

		/// <summary>
		/// resets the showInfo Panel
		/// </summary>
        private void deleteShowInfos()
        {
            flpAShowInformations.Visible = false;
            while (flpAShowInformations.Controls.Count > 0)
            {
                flpAShowInformations.Controls[0].Dispose();
            }
        }
		#endregion

		#region "rentMenu"
		/// <summary>
		/// deletes a rent by index
		/// </summary>
		/// <param name="i"></param>
		public void deleteRentAdminMenu(int i)
        {
            rentList.rentList.Remove(rentList.rentList[i]);
            deleteShowInfos();
            setAllRentMenuPanels();
        }
        
		/// <summary>
		/// paint all rentpanels
		/// </summary>
        private void setAllRentMenuPanels()
        {
            int tag = 0;
            foreach(Rents rent in rentList.rentList)
            {
                //nur aktuelle anzeigen
                if (rent.endTime.CompareTo(DateTime.Today) >= 0 || cbAdminShowOld.Checked)
                {
                    setRentMenuSingelPanel(rent, tag);
                }
                tag++;
            }
            flpAShowInformations.Visible = true;
        }

		/// <summary>
		/// creats single rentpanel by rent and index
		/// </summary>
		/// <param name="rent">displayed rent</param>
		/// <param name="tag">index</param>
        private void setRentMenuSingelPanel(Rents rent, int tag)
        {
            Panel pRentBG = new Panel();
            Button bDeleteEx = new DeleteRentButtonAdminSettings(this);
            Label lDate2Ex = new Label();
            Label lBisEx = new Label();
            Label lDateEx = new Label();
            Label lVonEx = new Label();
            Label lNameEx = new Label();
            Label lUserEx = new Label();
            Label lRentEx = new Label();
            Label lLockStatus = new Label();
            Label lCarNameEx = new Label();
            Label lCarEx = new Label();
            // 
            // pRentBG
            //
            pRentBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            if (!(rent.endTime.CompareTo(DateTime.Today) < 0))
            {
                pRentBG.Controls.Add(bDeleteEx);
            }
            pRentBG.Controls.Add(lDate2Ex);
            pRentBG.Controls.Add(lBisEx);
            pRentBG.Controls.Add(lDateEx);
            pRentBG.Controls.Add(lVonEx);
            pRentBG.Controls.Add(lNameEx);
            pRentBG.Controls.Add(lUserEx);
            pRentBG.Controls.Add(lRentEx);
            pRentBG.Controls.Add(lLockStatus);
            pRentBG.Controls.Add(lCarNameEx);
            pRentBG.Controls.Add(lCarEx);
            pRentBG.Location = new System.Drawing.Point(3, 3);
            pRentBG.Name = "pRentBG";
            pRentBG.Size = new System.Drawing.Size(675, 60);
            pRentBG.TabIndex = 0;
            // 
            // lDate2Ex
            //
            lDate2Ex.AutoSize = true;
            lDate2Ex.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lDate2Ex.Location = new System.Drawing.Point(465, 30);
            lDate2Ex.Name = "lDate2Ex";
            lDate2Ex.Size = new System.Drawing.Size(121, 19);
            lDate2Ex.TabIndex = 8;
            lDate2Ex.Text = rent.endTime.ToShortDateString();
            // 
            // lBisEx
            // 
            lBisEx.AutoSize = true;
            lBisEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lBisEx.Location = new System.Drawing.Point(406, 30);
            lBisEx.Name = "lBisEx";
            lBisEx.Size = new System.Drawing.Size(37, 19);
            lBisEx.TabIndex = 7;
            lBisEx.Text = (languageEnglisch) ? "To:" : "Bis:";
            // 
            // lDateEx
            // 
            lDateEx.AutoSize = true;
            lDateEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lDateEx.Location = new System.Drawing.Point(465, 9);
            lDateEx.Name = "lDateEx";
            lDateEx.Size = new System.Drawing.Size(121, 19);
            lDateEx.TabIndex = 6;
            lDateEx.Text = rent.startTime.ToShortDateString();
            // 
            // lVonEx
            // 
            lVonEx.AutoSize = true;
            lVonEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lVonEx.Location = new System.Drawing.Point(406, 9);
            lVonEx.Name = "lVonEx";
            lVonEx.Size = new System.Drawing.Size(42, 19);
            lVonEx.TabIndex = 5;
            lVonEx.Text = (languageEnglisch) ? "From:" : "Von:";
            // 
            // lNameEx
            // 
            lNameEx.AutoSize = true;
            lNameEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNameEx.Location = new System.Drawing.Point(216, 30);
            lNameEx.Name = "lNameEx";
            lNameEx.Size = new System.Drawing.Size(123, 19);
            lNameEx.TabIndex = 4;
            lNameEx.Text = rent.user.name;
            // 
            // lUserEx
            // 
            lUserEx.AutoSize = true;
            lUserEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lUserEx.Location = new System.Drawing.Point(134, 30);
            lUserEx.Name = "lUserEx";
            lUserEx.Size = new System.Drawing.Size(61, 19);
            lUserEx.TabIndex = 3;
            lUserEx.Text = (languageEnglisch) ? "Customer:" : "Kunde:";
            // 
            // lRentEx
            // 
            lRentEx.AutoSize = true;
            lRentEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lRentEx.Location = new System.Drawing.Point(5, 9);
            lRentEx.Name = "lRentEx";
            lRentEx.Size = new System.Drawing.Size(105, 19);
            lRentEx.TabIndex = 2;
            if(rent.rent)
                lRentEx.Text = (languageEnglisch) ? "Rental" : "Verleih";
            else
                lRentEx.Text = (languageEnglisch) ? "Reservation" : "Reservierung";
            // 
            // lLockStatus
            // 
            lLockStatus.AutoSize = true;
            lLockStatus.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lLockStatus.Location = new System.Drawing.Point(5, 30);
            lLockStatus.Name = "lRentEx";
            lLockStatus.Size = new System.Drawing.Size(105, 19);
            lLockStatus.TabIndex = 2;
            lLockStatus.Text = "Gesperrt!";
            lLockStatus.ForeColor = Color.Red;
            if (rent.lockMarker)
                lLockStatus.Visible = true;
            else
                lLockStatus.Visible = false;
            // 
            // lCarNameEx
            // 
            lCarNameEx.AutoSize = true;
            lCarNameEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCarNameEx.Location = new System.Drawing.Point(216, 9);
            lCarNameEx.Name = "lCarNameEx";
            lCarNameEx.Size = new System.Drawing.Size(57, 19);
            lCarNameEx.TabIndex = 1;
            lCarNameEx.Text = rent.car.name;
            // 
            // lCarEx
            // 
            lCarEx.AutoSize = true;
            lCarEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCarEx.Location = new System.Drawing.Point(134, 9);
            lCarEx.Name = "lCarEx";
            lCarEx.Size = new System.Drawing.Size(47, 19);
            lCarEx.TabIndex = 0;
            lCarEx.Text = (languageEnglisch) ? "Car:" : "Auto:";
            // 
            // bDeleteEx
            // 
            bDeleteEx.Font = new System.Drawing.Font("Arial", 10.2F);
            bDeleteEx.Location = new System.Drawing.Point(565, 27);
            bDeleteEx.Name = "bDeleteEx";
            bDeleteEx.Size = new System.Drawing.Size(98, 26);
            bDeleteEx.TabIndex = 9;
            bDeleteEx.Text = (languageEnglisch) ? "Delete" : "Löschen";
            bDeleteEx.UseVisualStyleBackColor = true;
            bDeleteEx.Tag = tag;

            if (rent.endTime.CompareTo(DateTime.Today) < 0)
            {
                lDate2Ex.ForeColor = Color.Gray;
                lBisEx.ForeColor = Color.Gray;
                lDateEx.ForeColor = Color.Gray;
                lVonEx.ForeColor = Color.Gray;
                lNameEx.ForeColor = Color.Gray;
                lUserEx.ForeColor = Color.Gray;
                lRentEx.ForeColor = Color.Gray;
                lLockStatus.ForeColor = Color.Gray;
                lCarNameEx.ForeColor = Color.Gray;
                lCarEx.ForeColor = Color.Gray;

            }

            this.flpAShowInformations.Controls.Add(pRentBG);
            pRentBG.SuspendLayout();
            pRentBG.ResumeLayout(false);
            pRentBG.PerformLayout();
        }

		/// <summary>
		/// sets the rentmenu to active and paint rents in showInfo Panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void rBRes_CheckedChanged(object sender, EventArgs e)
        {
            this.cbAdminShowOld.Visible = true;
            this.bAddHoliday.Visible = false;
            deleteShowInfos();
            setAllRentMenuPanels();
        }

		/// <summary>
		/// shows old entrys if checked
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void cbAdminShowOld_CheckedChanged(object sender, EventArgs e)
        {
            deleteShowInfos();
            setAllRentMenuPanels();
        }
		#endregion

        #region "customerMenu"
		/// <summary>
		/// paint all customerPanels in showInfo Panel
		/// </summary>
        private void setAllCustomerMenuPanels()
        {
            foreach (User user in userList)
            {
                setCustomerMenuSingelPanel(user);
            }
            flpAShowInformations.Visible = true;
        }

		/// <summary>
		/// creates single user panel by user
		/// </summary>
		/// <param name="user">displayed user</param>
        private void setCustomerMenuSingelPanel(User user)
        {
            Panel pCustomerBG = new Panel();
            Label lNrRentNrEx = new Label();
            Label lNrRentEx = new Label();
            Label lNrResNrEx = new Label();
            Label lNrResEx = new Label();
            Label lAdressPlaceEx = new Label();
            Label lNameEx = new Label();
            Label lAdressStreetEx = new Label();
            Label lAdressEx = new Label();
            // 
            // pCustomerBG
            //
            pCustomerBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pCustomerBG.Controls.Add(lNrRentNrEx);
            pCustomerBG.Controls.Add(lNrRentEx);
            pCustomerBG.Controls.Add(lNrResNrEx);
            pCustomerBG.Controls.Add(lNrResEx);
            pCustomerBG.Controls.Add(lAdressPlaceEx);
            pCustomerBG.Controls.Add(lNameEx);
            pCustomerBG.Controls.Add(lAdressStreetEx);
            pCustomerBG.Controls.Add(lAdressEx);
            pCustomerBG.Location = new System.Drawing.Point(3, 3);
            pCustomerBG.Name = "pRentBG";
            pCustomerBG.Size = new System.Drawing.Size(675, 60);
            pCustomerBG.TabIndex = 0;
            // 
            // lNrRentNrEx
            // 
            lNrRentNrEx.AutoSize = true;
            lNrRentNrEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNrRentNrEx.Location = new System.Drawing.Point(570, 30);
            lNrRentNrEx.Name = "lDate2Ex";
            lNrRentNrEx.Size = new System.Drawing.Size(121, 19);
            lNrRentNrEx.TabIndex = 8;
            lNrRentNrEx.Text = rentList.getOnlyRentsByUser(user).Count() + "";
            // 
            // lNrRentEx
            // 
            lNrRentEx.AutoSize = true;
            lNrRentEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNrRentEx.Location = new System.Drawing.Point(406, 30);
            lNrRentEx.Name = "lBisEx";
            lNrRentEx.Size = new System.Drawing.Size(37, 19);
            lNrRentEx.TabIndex = 7;
            lNrRentEx.Text = (languageEnglisch) ? "Number of Rents" : "Anzahl Verleihungen:";
            // 
            // lNrResNrEx
            // 
            lNrResNrEx.AutoSize = true;
            lNrResNrEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNrResNrEx.Location = new System.Drawing.Point(570, 9);
            lNrResNrEx.Name = "lDateEx";
            lNrResNrEx.Size = new System.Drawing.Size(121, 19);
            lNrResNrEx.TabIndex = 6;
            lNrResNrEx.Text = 
            lNrResNrEx.Text = rentList.getOnlyResByUser(user).Count() + "";
            // 
            // lNrResEx
            // 
            lNrResEx.AutoSize = true;
            lNrResEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNrResEx.Location = new System.Drawing.Point(406, 9);
            lNrResEx.Name = "lVonEx";
            lNrResEx.Size = new System.Drawing.Size(42, 19);
            lNrResEx.TabIndex = 5;
            lNrResEx.Text = (languageEnglisch) ? "Number of Reservations" : "Anzahl Reservierungen:";
            // 
            // lAdressPlaceEx
            // 
            lAdressPlaceEx.AutoSize = true;
            lAdressPlaceEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lAdressPlaceEx.Location = new System.Drawing.Point(216, 30);
            lAdressPlaceEx.Name = "lNameEx";
            lAdressPlaceEx.Size = new System.Drawing.Size(123, 19);
            lAdressPlaceEx.TabIndex = 4;
            lAdressPlaceEx.Text = user.adress.plz + " " + user.adress.place;
            // 
            // lNameEx
            // 
            lNameEx.AutoSize = true;
            lNameEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lNameEx.Location = new System.Drawing.Point(5, 9);
            lNameEx.Name = "lRentEx";
            lNameEx.Size = new System.Drawing.Size(105, 19);
            lNameEx.TabIndex = 2;
            lNameEx.Text = user.name;
            // 
            // lAdressStreetEx
            // 
            lAdressStreetEx.AutoSize = true;
            lAdressStreetEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lAdressStreetEx.Location = new System.Drawing.Point(216, 9);
            lAdressStreetEx.Name = "lCarNameEx";
            lAdressStreetEx.Size = new System.Drawing.Size(57, 19);
            lAdressStreetEx.TabIndex = 1;
            lAdressStreetEx.Text = user.adress.street + " " + user.adress.houseNr;
            // 
            // lAdressEx
            // 
            lAdressEx.AutoSize = true;
            lAdressEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lAdressEx.Location = new System.Drawing.Point(150, 9);
            lAdressEx.Name = "lCarEx";
            lAdressEx.Size = new System.Drawing.Size(47, 19);
            lAdressEx.TabIndex = 0;
            lAdressEx.Text = (languageEnglisch) ? "Adress:" : "Adresse:";


            this.flpAShowInformations.Controls.Add(pCustomerBG);
            pCustomerBG.SuspendLayout();
            pCustomerBG.ResumeLayout(false);
            pCustomerBG.PerformLayout();
        }

		/// <summary>
		/// set cutomer menu to active and shows them in showInfo panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void rbUser_CheckedChanged(object sender, EventArgs e)
        {
            this.cbAdminShowOld.Visible = false;
            this.bAddHoliday.Visible = false;
            deleteShowInfos();
            setAllCustomerMenuPanels();
        }
        #endregion

        #region "carMenu"
		/// <summary>
		/// toggles the boolean gesperrt of the car and write the change in the xml file
		/// </summary>
		/// <param name="i"></param>
        public void toggleLockCar(int i)
        {
            //toggle gesperrt
            carList[i].gesperrt = !carList[i].gesperrt;

            //save changes in carList.xml
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(@"carList.xml");

            XmlNode node = xmlDoc.SelectSingleNode("/carlist");
            foreach (System.Xml.XmlElement nod in node.ChildNodes)
            {
                if (nod.FirstChild.InnerText.Equals(carList[i].name))
                {
                    nod.FirstChild.NextSibling.InnerText = carList[i].gesperrt.ToString().ToLower();
                }
            }
            xmlDoc.Save(@"carList.xml");

            //mark rent --> evtl. vor programmstart abgleichen bzw setzen nch einlesen von Autos
            foreach(Rents rent in rentList.getRentsByCar(carList[i]))
            {
                rent.lockMarker = carList[i].gesperrt;
            }

            //updatePanel
            deleteShowInfos();
            setAllCarMenuPanels();
        }

		/// <summary>
		/// paint all carPanels in showInfo Panel
		/// </summary>
		private void setAllCarMenuPanels()
        {
            int tag = 0;
            foreach (Car car in carList)
            {
                setCarMenuSingelPanel(car, tag);
                tag++;
            }
            flpAShowInformations.Visible = true;
        }

		/// <summary>
		/// creates a single carPanel by car and index 
		/// </summary>
		/// <param name="car">displayed car</param>
		/// <param name="tag">index of the car</param>
        private void setCarMenuSingelPanel(Car car, int tag)
        {
            Panel pCarBG = new Panel();
            Button bDeleteEx = new lockCarButton(this);
            Label lStatusEx = new Label();
            Label lStatusTitleEx = new Label();
            Label lCarNameEx = new Label();
            Label lCarEx = new Label();
            PictureBox pbRentetCar = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(pbRentetCar)).BeginInit();
            // 
            // pRentBG
            //
            pCarBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pCarBG.Controls.Add(bDeleteEx);
            pCarBG.Controls.Add(lStatusEx);
            pCarBG.Controls.Add(lStatusTitleEx);
            pCarBG.Controls.Add(lCarNameEx);
            pCarBG.Controls.Add(pbRentetCar);
            pCarBG.Location = new System.Drawing.Point(3, 3);
            pCarBG.Name = "pRentBG";
            pCarBG.Size = new System.Drawing.Size(675, 90);
            pCarBG.TabIndex = 0;
            // 
            // lStatusEx
            // 
            lStatusEx.AutoSize = true;
            lStatusEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lStatusEx.Location = new System.Drawing.Point(365, 15);
            lStatusEx.Name = "lDateEx";
            lStatusEx.Size = new System.Drawing.Size(121, 19);
            lStatusEx.TabIndex = 6;
            if(car.gesperrt)
                lStatusEx.Text = (languageEnglisch) ? "blocked" : "gesperrt";
            else
                lStatusEx.Text = "normal";
            // 
            // lStatusTitleEx
            // 
            lStatusTitleEx.AutoSize = true;
            lStatusTitleEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lStatusTitleEx.Location = new System.Drawing.Point(306, 15);
            lStatusTitleEx.Name = "lVonEx";
            lStatusTitleEx.Size = new System.Drawing.Size(42, 19);
            lStatusTitleEx.TabIndex = 5;
            lStatusTitleEx.Text = "Status:";
            // 
            // lRentEx
            // 
            lCarNameEx.AutoSize = true;
            lCarNameEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lCarNameEx.Location = new System.Drawing.Point(140, 15);
            lCarNameEx.Name = "lRentEx";
            lCarNameEx.Size = new System.Drawing.Size(105, 19);
            lCarNameEx.TabIndex = 2;
            lCarNameEx.Text = car.name;
            // 
            // bDeleteEx
            // 
            bDeleteEx.Font = new System.Drawing.Font("Arial", 10.2F);
            bDeleteEx.Location = new System.Drawing.Point(565, 55);
            bDeleteEx.Name = "bDeleteEx";
            bDeleteEx.Size = new System.Drawing.Size(98, 26);
            bDeleteEx.TabIndex = 9;
            if (car.gesperrt)
            {
                bDeleteEx.Text = (languageEnglisch) ? "unlock" : "Entsperren";
            }
            else
            {
                bDeleteEx.Text = (languageEnglisch) ? "Lock" : "Sperren";

            }
            bDeleteEx.UseVisualStyleBackColor = true;
            bDeleteEx.Tag = tag;
            // 
            // pbRentetCar
            // 
            pbRentetCar.Image = car.images[0];
            pbRentetCar.Location = new System.Drawing.Point(10, 7);
            pbRentetCar.Name = "pbRentetCar";
            pbRentetCar.Size = new System.Drawing.Size(120, 75);
            pbRentetCar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pbRentetCar.TabIndex = 0;
            pbRentetCar.TabStop = false;

            ((System.ComponentModel.ISupportInitialize)(pbRentetCar)).EndInit();


            this.flpAShowInformations.Controls.Add(pCarBG);
            pCarBG.SuspendLayout();
            pCarBG.ResumeLayout(false);
            pCarBG.PerformLayout();
        }

		/// <summary>
		/// sets the carMenu to active and shows it in showInfo panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void rbCars_CheckedChanged(object sender, EventArgs e)
        {
            this.cbAdminShowOld.Visible = false;
            this.bAddHoliday.Visible = false;
            deleteShowInfos();
            setAllCarMenuPanels();
        }
        #endregion

        #region "holidaysMenu"
		/// <summary>
		/// paint all holiday panels in showInfo Panel
		/// </summary>
        private void setAllHolidayMenuPanels()
        {
            int tag = 0;
            foreach (string dt in holidays.Keys)
            {
                setHolidayMenuSingelPanel(dt);
                tag++;
            }
            flpAShowInformations.Visible = true;
        }

		/// <summary>
		/// creates a singel holidayPanel by DateTime
		/// </summary>
		/// <param name="dt">DateTime of displayed holiday</param>
        private void setHolidayMenuSingelPanel(string dt)
        {
            Panel pRentBG = new Panel();
            DateTimePicker dtpTagEx = new System.Windows.Forms.DateTimePicker();
            Button bSaveEx = new HolidaySaveButton(this, dtpTagEx); 
            Button bDeleteEx = new HolidaysDeleteButton(this);
            Label lHolidayEx = new Label();
            Label lTagEx = new Label();
            // 
            // pRentBG
            //
            pRentBG.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            pRentBG.Controls.Add(bSaveEx);
            pRentBG.Controls.Add(bDeleteEx);
            pRentBG.Controls.Add(lHolidayEx);
            pRentBG.Controls.Add(dtpTagEx);
            pRentBG.Controls.Add(lTagEx);
            pRentBG.Location = new System.Drawing.Point(3, 3);
            pRentBG.Name = "pRentBG";
            pRentBG.Size = new System.Drawing.Size(675, 45);
            pRentBG.TabIndex = 0;
            // 
            // lRentEx
            // 
            lHolidayEx.AutoSize = true;
            lHolidayEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lHolidayEx.Location = new System.Drawing.Point(5, 12);
            lHolidayEx.Name = "lRentEx";
            lHolidayEx.Size = new System.Drawing.Size(105, 19);
            lHolidayEx.TabIndex = 2;
            lHolidayEx.Text = dt;
            // 
            // lTagEx
            // 
            lTagEx.AutoSize = true;
            lTagEx.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            lTagEx.Location = new System.Drawing.Point(74, 12);
            lTagEx.Name = "lCarEx";
            lTagEx.Size = new System.Drawing.Size(47, 19);
            lTagEx.TabIndex = 0;
            lTagEx.Text = (languageEnglisch) ? "Day:" : "Tag:";
            // 
            // dtpTagEx
            // 
            dtpTagEx.Location = new System.Drawing.Point(166, 12);
            dtpTagEx.Margin = new System.Windows.Forms.Padding(4);
            dtpTagEx.Name = "dtpVon";
            dtpTagEx.Size = new System.Drawing.Size(265, 22);
            dtpTagEx.TabIndex = 13;
            dtpTagEx.Value = new System.DateTime(holidays[dt].Year, holidays[dt].Month, holidays[dt].Day);
            // 
            // bSaveEx
            // 
            bSaveEx.Font = new System.Drawing.Font("Arial", 10.2F);
            bSaveEx.Location = new System.Drawing.Point(565, 9);
            bSaveEx.Name = "bSaveEx";
            bSaveEx.Size = new System.Drawing.Size(98, 26);
            bSaveEx.TabIndex = 9;
            bSaveEx.Text = (languageEnglisch) ? "Save" : "Speichern";
            bSaveEx.UseVisualStyleBackColor = true;
            bSaveEx.Tag = dt;
            // 
            // bDeleteEx
            // 
            bDeleteEx.Font = new System.Drawing.Font("Arial", 10.2F);
            bDeleteEx.Location = new System.Drawing.Point(465, 9);
            bDeleteEx.Name = "bDeleteEx";
            bDeleteEx.Size = new System.Drawing.Size(98, 26);
            bDeleteEx.TabIndex = 9;
            bDeleteEx.Text = (languageEnglisch) ? "Delete" : "Löschen";
            bDeleteEx.UseVisualStyleBackColor = true;
            bDeleteEx.Tag = dt;


            this.flpAShowInformations.Controls.Add(pRentBG);
            pRentBG.SuspendLayout();
            pRentBG.ResumeLayout(false);
            pRentBG.PerformLayout();
        }

		/// <summary>
		/// set holidayMenu to active and paint informations in showInfo panel
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void rbHolidays_CheckedChanged(object sender, EventArgs e)
        {
            this.cbAdminShowOld.Visible = false;
            this.bAddHoliday.Visible = true;
            deleteShowInfos();
            setAllHolidayMenuPanels();
        }
        
		/// <summary>
		/// saves the changes of a modified holiday
		/// </summary>
		/// <param name="key">modified holiday name</param>
		/// <param name="dt">new DateTime</param>
        public void saveHolidayChanges(string key, DateTime dt)
        {
            holidays[key] = dt;
			string s1 = (languageEnglisch) ? "Changes saved successfully" : "Änderungen erfolgriech gespeichert";
			string s2 = (languageEnglisch) ? "Save" : "Speichern";
			MessageBox.Show(s1, "Speichern", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }
        
		/// <summary>
		/// delets a holiday by its name
		/// </summary>
		/// <param name="key">name of the holiday</param>
        public void deleteHoliday(string key)
        {
            holidays.Remove(key);
            deleteShowInfos();
            setAllHolidayMenuPanels();
        }

		/// <summary>
		/// repaints all holiday panels
		/// </summary>
        public void repaintHolidayMenu()
        {
            deleteShowInfos();
            setAllHolidayMenuPanels();
        }

		/// <summary>
		/// shows the window to create a new holiday
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bAddHoliday_Click(object sender, EventArgs e)
        {
            frNewHoliday frnh = new frNewHoliday(this);
            frnh.ShowDialog();
        }
        #endregion
        #endregion
		
		#region "language"
		/// <summary>
		/// changes language when the index of the combobox item changes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void cbLanguageSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLanguageSelect.SelectedItem.ToString() == "Deutsch")
            {
                languageEnglisch = false;
                ChangeLanguage("en");
            }
            else if (cbLanguageSelect.SelectedItem.ToString() == "Englisch")
            {
                languageEnglisch = true;
                ChangeLanguage("en-DE");
            }
        }

		/// <summary>
		/// updates all panels with the new language
		/// </summary>
		/// <param name="lang"></param>
        private void ChangeLanguage(string lang)
        {

            ComponentResourceManager resources = new ComponentResourceManager(typeof(frMain));
            foreach (Control c in this.pPage1.Controls) 
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }

			if (currentUser != null && languageEnglisch)
			{
				this.bLog.Text = "LogOut";
			}
			else if (currentUser != null && languageEnglisch)
			{
				this.bLog.Text = "Abmelden";
			}

			foreach (Control c in this.pPage2.Controls)
			{
				resources.ApplyResources(c, c.Name, new CultureInfo(lang));
			}

			foreach (Control c in this.pPage3.Controls)
			{
				resources.ApplyResources(c, c.Name, new CultureInfo(lang));
			}

			setButtonVisibility(currentUser != null);
            foreach (Control c in this.pInfo.Controls)
            {
                resources.ApplyResources(c, c.Name, new CultureInfo(lang));
            }
			if(currentUser != null)
				this.bAdminSettings.Visible = currentUser.admin;

            setInfos();
        }
		#endregion

		#region "informationButtons"
		/// <summary>
		/// shows the credit in an new window
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bInfo_Click(object sender, EventArgs e)
        {
			String s = (languageEnglisch) ? "This project was developed within the framework\nof the usability project" : "Dieses Pogramm enstand im Rahmen des Usabilityprojekts";

			String creditsAbout = s + "\n\nMalte Riechmann und Piotr Wronski.\n" +
                "Version 1.0";

              frInfoWindows infoAbout = new frInfoWindows(creditsAbout);
            infoAbout.ShowDialog();
        }

		/// <summary>
		/// show help text in a new dialogue
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bHelp_Click(object sender, EventArgs e)
		{
			String info = "";
			if (currentUser == null)
			{
				if (languageEnglisch)
				{
					info = "In order to see the different pictures of the car, you can click on the " +
						"small pictures on the left side to get them displayed. To add the cars, use " +
						"the arrow keys under the big picture.Via the text input field you can search for cars or users. " +
						"For further functions you have to log in.";
				}
				else
				{
					info = "Um sich die verschiedenen Bilder des Autos ansehen zukönnen, können Sie " +
						"an der linken Seite die kleinen Bilder anklicken um sie sich groß anzeigen zu lassen." +
						"Um die Autos weiter zuschlaten nutzen Sie die Pfeiltasten unter dem großen Bild." +
						"Über das Text eingabe Feld können sie nach Autos oder Nutzer suchen" +
						"Für weitere Funktionen müssen Sie sich an melden.";
				}
			}
			else if (currentUser.admin)
			{
				if (languageEnglisch)
				{
					info = "To view and edit your reservations and loans, you must go to \"Profile\"." +
						"There you can also look at your personal information and your old entries. " +
						"To borrow a new car, click on \"Rent/Reserving\".If over the button " +
						"\"locked\" stands they can not borrow this at the time unfortunately. Under \"Admin\", " +
						"the \"Reservations\", \"Customers\", \"Cars\" and \"Holidays\" options are available for editing";
				}
				else
				{
					info = "Um sich Ihre Reservierungen und Ausleihung ansehen und bearbeiten" +
					"zu können müssen sie auf \"Profil\" gehen. Dort könne sie sich auch Ihre " +
					"persönlichen Informationen ansehen und Ihre alten Einträge. " +
					"Um ein neues Auto auszuleihen klicken sie auf \"Leihen/Reserviern\"." +
					" Wenn über dem Knopf \"gesperrt\" steht können sie sich dieses zur Zeit leider nicht " +
					"ausleihen. " +
					"Unter \"Admin\" stehen ihnen die Optionen \"Reservierungen\", \"Kunden\", " +
					"\"Autos\" und \"Feiertage\" zur Verfügung, um dies zu bearbeiten.";
				}

			}
			else
			{
				if (languageEnglisch)
				{
					info = "To view and edit your reservations and loans, you need to go to \"Profile\", " +
						"where you can also view your personal information and your old entries, to borrow " +
						"a new car, click on \" Rent/Reserving \"If the button is \"blocked\", " +
						"you can not borrow this at the moment.";
				}
				else
				{
					info = "Um sich Ihre Reservierungen und Ausleihung ansehen und bearbeiten\r" +
						"zu können müssen sie auf \"Profil\" gehen. Dort könne sie sich auch Ihre " +
						"persönlichen Informationen ansehen und Ihre alten Einträge.\n" +
						"Um ein neues Auto auszuleihen klicken sie auf \"Leihen/Reserviern\"." +
						" Wenn über dem Knopf \"gesperrt\" steht können sie sich dieses zur Zeit leider nicht " +
						"ausleihen.";

				}
			}
			frHelpWindow help = new frHelpWindow(info);
			help.ShowDialog();
		}
		#endregion

		/// <summary>
		/// saves changes in xml files when the form closes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void frMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			#region "saveRentlist"
			XmlWriterSettings settings = new XmlWriterSettings();
			settings.Indent = true;
			settings.IndentChars = "  ";
			try
			{
				//Klappt nicht wenn es geschlossen werden soll und vorher nichts gemacht wurde
				XmlWriter writer = XmlWriter.Create(@"rentList.xml", settings);
				writer.WriteStartDocument();
				//StartTag von rentList
				writer.WriteStartElement("rentlist");
				foreach (Rents r in rentList.rentList)
				{
					//StartTag von rent
					writer.WriteStartElement("rent");


					writer.WriteElementString("lockMarker", r.lockMarker.ToString().ToLower());
					writer.WriteElementString("rented", r.rent.ToString().ToLower());
					writer.WriteElementString("car", r.car.index + "");
					writer.WriteElementString("user", r.user.index + "");

					//Von
					writer.WriteStartElement("dateV");
					writer.WriteElementString("year", r.startTime.Year + "");
					writer.WriteElementString("month", r.startTime.Month + "");
					writer.WriteElementString("day", r.startTime.Day + "");
					writer.WriteEndElement();

					//Bis
					writer.WriteStartElement("dateB");
					writer.WriteElementString("year", r.endTime.Year + "");
					writer.WriteElementString("month", r.endTime.Month + "");
					writer.WriteElementString("day", r.endTime.Day + "");
					writer.WriteEndElement();

					//EndTag rent
					writer.WriteEndElement();
				}
				//EndTag von rendList
				writer.WriteEndElement();

				writer.WriteEndDocument();
				writer.Close();
			}
			catch
			{

			}
			#endregion

			#region "saveHolidays"
			XmlWriterSettings settings1 = new XmlWriterSettings();
			settings1.Indent = true;
			settings1.IndentChars = "  ";
			try
			{
				//Klappt nicht wenn es geschlossen werden soll und vorher nichts gemacht wurde
				XmlWriter writer = XmlWriter.Create(@"holidayList.xml", settings);
				writer.WriteStartDocument();
				//StartTag von rentList
				writer.WriteStartElement("holidayList");
				foreach (string s in holidays.Keys)
				{
					//StartTag von rent
					writer.WriteStartElement("holiday");


					writer.WriteElementString("name", s);
					writer.WriteElementString("year", holidays[s].Year + "");
					writer.WriteElementString("month", holidays[s].Month + "");
					writer.WriteElementString("day", holidays[s].Day + "");

					//EndTag rent
					writer.WriteEndElement();
				}
				//EndTag von rendList
				writer.WriteEndElement();

				writer.WriteEndDocument();
				writer.Close();
			}
			catch
			{

			}
			#endregion
		}
	}
}
