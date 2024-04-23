namespace Main.Libraries
{
    public class Client
    {


        public int id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        public Client(string FirstName, string LastName, string Phone, string Email, string Address)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Phone = Phone;
            this.Email = Email;
            this.Address = Address;

        }



    }
}
