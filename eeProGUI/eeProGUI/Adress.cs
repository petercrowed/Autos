namespace eeProGUI
{
	/// <summary>
	/// Adress is a information typ for the User
	/// </summary>
    public class Adress
    {
        public string street { get; set; }
        public int houseNr { get; set; }
        public int plz { get; set; }
        public string place { get; set; }

		/// <summary>
		/// Constructor for reading xml
		/// </summary>
        public Adress()
        {
        }

		/// <summary>
		/// Constructor for setting all Atributes
		/// </summary>
		/// <param name="street">street</param>
		/// <param name="houseNr">house number</param>
		/// <param name="pzl">plz</param>
		/// <param name="place">place</param>
		public Adress(string street, int houseNr, int pzl, string place )
        {
            this.street = street;
            this.houseNr = houseNr;
            this.plz = pzl;
            this.place = place;
        }
    }
}