using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eeProGUI
{
	/// <summary>
	/// class with a list of rents as attribute and methods to get a part of them for special situations
	/// </summary>
    public class RentList
    {
        public List<Rents> rentList { get; set; } = new List<Rents>();

        public RentList()
        {
        }

		/// <summary>
		/// adds rents to user
		/// </summary>
		/// <param name="r"></param>
        public void addRent(Rents r)
        {
            this.rentList.Add(r);
        }

		/// <summary>
		/// returns all reservations of a user in a list
		/// </summary>
		/// <param name="u">user</param>
		/// <returns>list of all reservations of the user</returns>
		public List<Rents> getOnlyResByUser(User u)
        {
            List<Rents> user = new List<Rents>();
            foreach (Rents rent in rentList)
            {
                if (rent.user.name.Equals(u.name) && !rent.rent)
                {
                    user.Add(rent);
                }
            }
            return user;
        }

		/// <summary>
		/// returns all rentals of a user in a list
		/// </summary>
		/// <param name="u">user</param>
		/// <returns>rentals of the user</returns>
		public List<Rents> getOnlyRentsByUser(User u)
        {
            List<Rents> user = new List<Rents>();
            foreach (Rents rent in rentList)
            {
                if (rent.user.name.Equals(u.name) && rent.rent)
                {
                    user.Add(rent);
                }
            }
            return user;
        }

		/// <summary>
		/// returns all rentals and reservations of the user
		/// </summary>
		/// <param name="u">user</param>
		/// <returns>list of all rentals and reservations of user</returns>
        public List<Rents> getRentsByUser(User u)
        {
            List<Rents> user = new List<Rents>();
            foreach(Rents rent in rentList)
            {
                if (rent.user.name.Equals(u.name))
                {
                    user.Add(rent);
                }
            }
            return user;
        }

		/// <summary>
		/// returns all rentals and reservations of a car
		/// </summary>
		/// <param name="c">car</param>
		/// <returns>list of rentals and reservations of the car</returns>
		public List<Rents> getRentsByCar(Car c)
        {
            List<Rents> cars = new List<Rents>();
            foreach (Rents rent in rentList)
            {
                if (rent.car.name.Equals(c.name))
                {
                    cars.Add(rent);
                }
            }
            return cars;
        }

		/// <summary>
		/// returns all rented days of a car in the month of a year
		/// </summary>
		/// <param name="c">car</param>
		/// <param name="month">month</param>
		/// <param name="year">year</param>
		/// <returns>all days in a list</returns>
        public List<DateTime> getRentedDaysByCarAndMonth(Car c, int month, int year)
        {
            List<DateTime> day = new List<DateTime>();
            foreach (Rents rent in rentList)
            {
				foreach (DateTime dt in rent.getDateArray())
				{
					if (rent.rent && rent.car.name.Equals(c.name) && dt.Month == month && dt.Year == year)
					{
						if (dt.Month == month && dt.Year == year)
						{
							day.Add(dt);
						}
					}
				}
            }
            return day;
        }

		/// <summary>
		/// returns all reserved days of a car in the month of a year
		/// </summary>
		/// <param name="c">car</param>
		/// <param name="month">month</param>
		/// <param name="year">year</param>
		/// <returns>all days in a list</returns>
		public List<DateTime> getResDaysByCarAndMonth(Car c, int month, int year)
        {
            List<DateTime> day = new List<DateTime>();
            foreach (Rents rent in rentList)
            {
				foreach (DateTime dt in rent.getDateArray())
				{
					if (!rent.rent && rent.car.name.Equals(c.name) && rent.startTime.Month == month && dt.Year == year)
					{
						if (dt.Month == month && dt.Year == year)
						{
							day.Add(dt);
						}
					}
				}
            }
            return day;
        }

		/// <summary>
		/// checks if the car is rented today
		/// </summary>
		/// <param name="car">car</param>
		/// <returns>true when the car is rented today</returns>
        public bool checkIfCarIsRentedToday(Car car)
        {
            foreach(Rents rent in rentList)
            {
                //search Rents by Car
                if (rent.car.name.Equals(car.name))
                {
                    if(rent.startTime.CompareTo(DateTime.Today) <= 0 && rent.endTime.CompareTo(DateTime.Today) >= 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

		public List<DateTime> getResRentDaysByUser(User u)
		{
			List<DateTime> days = new List<DateTime>();
			List<Rents> rents = getRentsByUser(u);
			{
				foreach(Rents r in rents)
				{
					foreach(DateTime dt in r.getDateArray())
					{
						if (!days.Contains(dt))
						{
							days.Add(dt);
						}
					}
				}
			}
			return days;
		}

		public List<DateTime> getDateArray(DateTime dt1, DateTime dt2)
		{
			DateTime currentDate = dt1;
			List<DateTime> dates = new List<DateTime>();
			while (currentDate.CompareTo(dt2) <= 0)
			{
				dates.Add(currentDate);
				currentDate = currentDate.AddDays(1);
			}
			return dates;
		}
	}
}
