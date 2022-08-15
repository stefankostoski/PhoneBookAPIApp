namespace PhoneBookAPIApp
{
    public class KeyGenerator
    {
        public static Guid GenerateKey()
        {
            Guid key = Guid.NewGuid();
            return key;
        }
    }
}
