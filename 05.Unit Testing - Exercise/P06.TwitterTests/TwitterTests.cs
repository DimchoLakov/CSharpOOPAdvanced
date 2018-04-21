using System.Reflection;
using NUnit.Framework;

public class TwitterTests
{
    [Test]
    [TestCase("Hello")]
    [TestCase("I am Tweet")]
    [TestCase("Tweeting")]
    public void TestTweetConstructor(string inputMessage)
    {
        Tweet tweet = new Tweet(inputMessage);
        
        Assert.AreEqual(inputMessage, tweet.Message);
    }

    [Test]
    public void TestClientReceivingMessage()
    {
        Tweet tweet = new Tweet("Hello");

        Microwave microwave = new Microwave();
        
        Assert.AreEqual(microwave.FormatMessage(tweet), tweet.Message);
    }
}