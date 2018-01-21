using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace eeProGUI
{
    public partial class frRentMenu : Form
    {
        private frMain m;
        private Dictionary<int, String> month = new Dictionary<int, string>();
        private int currentMonth;
        private int currentYear;
        private Dictionary<int[],Label> calendarFields = new Dictionary<int[], Label>();
        public string dateVon;
        public string dateBis;

        public frRentMenu(frMain m)
        {
            this.m = m;
            this.currentMonth = DateTime.Today.Month;
            this.currentYear = DateTime.Today.Year;
            InitializeMonthDict();
            InitializeComponent();
            setCalendar();
            InitializeDateTimePicker();
			if (m.languageEnglisch)
				languageSetEnglish();
        }

        #region "initFunctions"
		/// <summary>
		/// set the Date of DateTimePicke to today
		/// </summary>
        private void InitializeDateTimePicker()
        {
            dtpBis.Value = DateTime.Today;
            dtpVon.Value = DateTime.Today;
        }

		/// <summary>
		/// inits dictionary of monthname and monthnumber
		/// </summary>
        private void InitializeMonthDict()
        {
            month.Add(1, "Jannuar");
            month.Add(2, "Februar");
            month.Add(3, "März");
            month.Add(4, "April");
            month.Add(5, "Mai");
            month.Add(6, "Juni");
            month.Add(7, "Juli");
            month.Add(8, "August");
            month.Add(9, "September");
            month.Add(10, "Oktober");
            month.Add(11, "November");
            month.Add(12, "Dezember");
        }
		#endregion
		
		/// <summary>
		/// sets the language to english
		/// </summary>
		private void languageSetEnglish()
		{
			this.Text = "Rental manager";
			this.lTitle.Text = "Create new reservation/rental";
			this.rbRent.Text = "Rental";
			this.rbRes.Text = "Reservation";
			this.lFrom.Text = "From:";
			this.lUntil.Text = "To:";
			this.lMonday.Text = "Mo";
			this.lTuesday.Text = "Tu";
			this.lWendsday.Text = "We";
			this.lThursday.Text = "Th";
			this.lFriday.Text = "Fr";
			this.lSaturdy.Text = "Sa";
			this.lSunday.Text = "Su";
			this.bSave.Text = "Save";
			this.bCancel.Text = "Cancel";
		}
		
		#region "Calendar"
		/// <summary>
		/// creates the calendar
		/// </summary>
		private void setCalendar()
        {
            List <DateTime> rentDay= m.rentList.getRentedDaysByCarAndMonth(m.carList[m.currentCar], currentMonth, currentYear);
            List<DateTime> resDay = m.rentList.getResDaysByCarAndMonth(m.carList[m.currentCar], currentMonth, currentYear);
            DateTime firstDate = new DateTime(currentYear, currentMonth, 1);
            int column = 0;
            int row = 0;
            this.lMonth.Text = this.month[firstDate.Month];
            this.lYear.Text = currentYear+"";
            switch (firstDate.DayOfWeek)
            {
                case System.DayOfWeek.Monday:
                    column += 1;
                    break;
                case System.DayOfWeek.Tuesday:
                    column += 2;
                    break;
                case System.DayOfWeek.Wednesday:
                    column += 3;
                    break;
                case System.DayOfWeek.Thursday:
                    column += 4;
                    break;
                case System.DayOfWeek.Friday:
                    column += 5;
                    break;
                case System.DayOfWeek.Saturday:
                    column += 6;
                    break;
                case System.DayOfWeek.Sunday:
                    column += 7;
                    break;
            }

			while (firstDate.Month == currentMonth)
			{
				if (currentMonth  == 4)
				{
					System.Console.WriteLine(rentDay.Contains(firstDate));
					System.Console.WriteLine(firstDate.ToShortDateString());
				}
                System.Windows.Forms.Label day = new System.Windows.Forms.Label();
                day.AutoSize = true;
                day.Dock = System.Windows.Forms.DockStyle.Top;
                day.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                day.Location = new System.Drawing.Point(241, 71);
                day.Size = new System.Drawing.Size(36, 36);
                day.TabIndex = 5;
                string tag = firstDate.Day.ToString();
                day.Text = tag;
                day.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
                day.BorderStyle = BorderStyle.FixedSingle;
                this.tlpCalendar.Controls.Add(day, column, row);
                if (rentDay.Contains(firstDate))
                {
                    day.BackColor = Color.Red;
                    this.toolTip1.SetToolTip(day, "Verliehen");
                }
                else if (resDay.Contains(firstDate))
                {
                    day.BackColor = Color.DarkRed;
                    this.toolTip1.SetToolTip(day, "Reserviert");
                }
                else if (m.holidays.ContainsValue(firstDate))
                {
                    day.BackColor = Color.OrangeRed;
                    foreach(string s in m.holidays.Keys)
                    {
                        if (m.holidays[s].Equals(firstDate))
                        {
                            this.toolTip1.SetToolTip(day, s);
                        }
                    }
                }
                if (column >= 7)
                {
                    column = 1;
                    row++;
                }
                else
                {
                    column++;
                }
                firstDate = firstDate.AddDays(1);
            }
            tlpCalendar.Visible = true;
        }

		/// <summary>
		/// removes the calendar
		/// </summary>
        private void deleteCalendar()
        {
            tlpCalendar.Visible = false;
            while (tlpCalendar.Controls.Count > 0)
            {
                tlpCalendar.Controls[0].Dispose();
            }
        }

		/// <summary>
		/// decrements the month and updates the calendar by deleting and repainting it
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
        private void bLeft_Click(object sender, EventArgs e)
        {
            if (currentMonth == 1)
            {
                currentMonth = 12;
                currentYear--;
            }
            else
            {
                currentMonth--;
            }
            deleteCalendar();
            setCalendar();
        }

		/// <summary>
		/// decrements the month and updates the calendar by deleting and repainting it
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bRight_Click(object sender, EventArgs e)
        {
            if (currentMonth == 12)
            {
                currentMonth = 1;
                currentYear++;
            }
            else
            {
                currentMonth++;
            }
            deleteCalendar();
            setCalendar();
        }
		#endregion

		#region "controlButtons"
		/// <summary>
		/// closes form without doing anything
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		/// <summary>
		/// checks if dates of the rents are available and create them if they are, else a MassageBox apppears with additional informations
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void bSave_Click(object sender, EventArgs e)
        {
			List<DateTime> days = m.rentList.getResRentDaysByUser(m.currentUser);

			foreach(DateTime t in days)
			{
				System.Console.WriteLine(t.ToShortDateString());
			}
            //Check if DateInput is Correct
            if(DateTime.Compare(dtpVon.Value, dtpBis.Value) <= 0 && DateTime.Compare(dtpVon.Value, DateTime.Today) >= 0) {
                //Check if one of the Days is a Holiday or Sunday
                if (!m.holidays.ContainsValue(dtpVon.Value) && !m.holidays.ContainsValue(dtpBis.Value))
                {
                    //Check if Car is already Rentet
                    bool start = true;
                    foreach(Rents r in m.rentList.getRentsByCar(m.carList[m.currentCar]))
                    {
                        DateTime currentDate = dtpVon.Value;
                        while (currentDate.CompareTo(dtpBis.Value) <= 0)
                        {
                            if (r.contains(dtpBis.Value) || r.contains(dtpVon.Value))
                            {
                                start = false;
                            }
                            currentDate = currentDate.AddDays(1);
                        }
                        
                    }
                    if (start) {
						DialogResult dialogResult = DialogResult.Yes;
						bool contains = false;
						foreach (DateTime c in m.rentList.getDateArray(dtpVon.Value, dtpBis.Value))
						{
							if (days.Contains(c))
							{
								contains = true;
							}
						}
						if (contains)
						{
							String s = (m.languageEnglisch) ? "You already have a reservation or loan at this time.\nProceed anyway?" : "Sie haben zu diesem Zeitpunkt bereits ein Reservierung oder Ausleihung.\n" +
									"Trotzdem fortfahren?";
							dialogResult = MessageBox.Show(s, "DateTimePicker", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
						}
						if (dialogResult == DialogResult.Yes)
						{
							//build res
							dateVon = dtpVon.Value.ToShortDateString();
							dateBis = dtpBis.Value.ToShortDateString();
							bool rented = false;
							String rent = (m.languageEnglisch) ? "Reserved" : "Reserviert";
							if (rbRent.Checked)
							{
								rent = (m.languageEnglisch) ? "Rented" : "Verliehen";
								rented = true;
							}
							m.rentList.addRent(new Rents(rented, m.currentUser, m.carList[m.currentCar], dtpVon.Value, dtpBis.Value));
							string s = (m.languageEnglisch) ? "From: " : "Von: ";
							string s1 = (m.languageEnglisch) ? "To: " : "Bis: ";
							MessageBox.Show(rent + "\n" + s + dtpVon.Text + "\n" + s1 + dtpBis.Text, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
							//MessageBox.Show(rent + " Bis: " + dtpBis.Text, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
							this.Close();
						}
                    }
                    else
                    {
						string s = (m.languageEnglisch) ? "The car has already been reserved for this period" : "Das Auto ist in diesem Zeitraum schon reserviert";

						MessageBox.Show(s , "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
				{
					string s = (m.languageEnglisch) ? "The indicated day is a holiday" : "Der angegebene Tag ist ein Feiertag";
					MessageBox.Show(s, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }    
            }
            else if (DateTime.Compare(dtpVon.Value, DateTime.Today) < 0)
			{
				string s = (m.languageEnglisch) ? "The given day is not possible" : "Der eingegbene Tag ist nicht möglich";
			MessageBox.Show(s, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(DateTime.Compare(dtpVon.Value, dtpBis.Value) > 0)
            {
				string s = (m.languageEnglisch) ? "The day that has been entered at\n" +
					"From must be before the day entered in To" : "Der Tag, der bei Von eingegeben wird\n" +
					"muss vor dem bei Bis eingegebene Tag sein";

				MessageBox.Show(s, "DateTimePicker", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
		#endregion
	}
}
