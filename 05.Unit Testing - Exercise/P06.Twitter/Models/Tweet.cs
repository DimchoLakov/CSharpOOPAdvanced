public class Tweet : ITweet
{
    public string Message { get; }

    public Tweet(string message)
    {
        this.Message = message;
    }
}