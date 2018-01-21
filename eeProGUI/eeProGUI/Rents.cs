using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eeProGUI
{
    public class Rents
    {
        public bool lockMarker { get; set; }
        public bool rent { get; set; }
        public User user { get; set; }
        public Car car { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }

        public Rents()
        {

        }
        public Rents(Boolean rent, User user, Car car, DateTime startTime, DateTime endTime)
        {
            this.rent = rent;
            this.user = user;
            this.car = car;
            this.startTime = startTime;
            this.endTime = endTime;
        }

		/// <summary>
		/// returns all days of the rental or reservation
		/// </summary>
		/// <returns>all days of the rental or reservation</returns>
		public List<DateTime> getDateArray()
        {
            DateTime currentDate = startTime;
            List<DateTime> dates = new List<DateTime>();
            while (currentDate.CompareTo(endTime) <= 0)
            {
                dates.Add(currentDate);
                currentDate = currentDate.AddDays(1);
            }
            return dates;
        }

		/// <summary>
		/// checks if day is part of the rental
		/// </summary>
		/// <param name="dt">to be tested day</param>
		/// <returns>true when the day is part of the rental</returns>
		public bool contains(DateTime dt)
        {
            return getDateArray().Contains(dt);
        }

    }
}
