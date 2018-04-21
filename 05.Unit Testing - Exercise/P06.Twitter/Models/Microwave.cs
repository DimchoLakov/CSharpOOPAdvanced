using System;

public class Microwave : IClient
{
    public void ReceiveMessage(ITweet tweet)
    {
        Console.WriteLine(FormatMessage(tweet));
    }

    public string FormatMessage(ITweet tweet)
    {
        return tweet.Message;
    }
}