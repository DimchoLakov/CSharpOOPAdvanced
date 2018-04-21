public class Startup
{
    public static void Main()
    {
        Tweet tweet = new Tweet("Hello");
        Microwave microwave = new Microwave();
        microwave.ReceiveMessage(tweet);
    }
}