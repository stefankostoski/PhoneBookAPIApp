namespace PhoneBookAPIApp.Models
{
    public class Contact
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public bool HasViber { get; set; }

        public Contact(int id, string fullname, string phonenumber, bool hasviber)
        {
            Id = id;
            FullName = fullname;
            PhoneNumber = phonenumber;
            HasViber = hasviber;
        }

    }
}
