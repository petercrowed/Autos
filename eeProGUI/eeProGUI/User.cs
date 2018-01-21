namespace eeProGUI
{
    public class User
    {
        public int index { get; set; }
        public bool admin { get; set; }
        public string username { get; set; }
        public string password { get;  set; }
        public string name { get; set; }
        public Adress adress { get; set; }
        public User(){}


		/// <summary>
		/// default constructor
		/// </summary>
		/// <param name="username"></param>
		/// <param name="password"></param>
		/// <param name="name"></param>
		/// <param name="adress"></param>
        public User(string username, string password, string name, Adress adress)
        {
            this.username = username;
            this.password = password;
            this.name = name;
            this.adress = adress;
        }
    }
}