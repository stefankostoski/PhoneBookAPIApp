using PhoneBookAPIApp.Models;

namespace PhoneBookAPIApp
{
    public static class StaticDb
    {
        public static List<Contact> Contacts = new List<Contact>()
        {
            new Contact(1, "Stefan Kostoski", "070221221", true),
            new Contact(2, "Trpe Trpeski", "070221221", false),
            new Contact(3, "Mirko Mirkoski", "070225225", true),
            new Contact(4, "Dragan Draganoski", "071987987", false),
            new Contact(5, "John Doe", "077136587", true),
            new Contact(6, "Prl Prleski", "075364987", false),
        };

        public static Guid key = KeyGenerator.GenerateKey();
    }
}
