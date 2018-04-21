using System;
using CustomLinkedList;
using NUnit.Framework;

public class Tests
{
    [Test]
    public void AddMethoudShouldAddItemToList()
    {
        DynamicList<string> dynList = new DynamicList<string>();

        int currentCount = dynList.Count;

        dynList.Add("Test");

        int finalCount = dynList.Count;

        Assert.That(currentCount, Is.LessThan(finalCount));
    }

    [Test]
    public void ContainsMethodShouldReturnFalseWhenGivenItemIsNotInTheList()
    {
        DynamicList<string> dynList = new DynamicList<string>();
        
        Assert.False(dynList.Contains("Test"));
    }

    [Test]
    public void ContainsMethodShouldReturnTrueThenGivenItemIsInTheList()
    {
        var dynList = new DynamicList<string>();
        dynList.Add("Test");

        Assert.True(dynList.Contains("Test"));
    }

    [Test]
    public void IndexOfShouldReturnIndexOfItemIfTheItemIsInTheList()
    {
        var dynList = new DynamicList<string>();
        dynList.Add("Test");
        int actualIndex = dynList.IndexOf("Test");
        int expectedIndex = 0;

        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [Test]
    public void IndexOfShouldReturnMinusOneWhenItemIsNotFoundInTheList()
    {
        var dynList = new DynamicList<string>();
        int actual = dynList.IndexOf("Test");
        int expected = -1;

        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RemoveShouldReturnCorrectIndexWhenExistingItemIsRemoved()
    {
        var dynList = new DynamicList<string>();
        dynList.Add("Test");
        int actualIndex = dynList.Remove("Test");
        int expectedIndex = 0;

        Assert.AreEqual(expectedIndex, actualIndex);
    }

    [Test]
    public void RemoveShouldReturnNegativeIndexWhenNonExistingItemIsRemoved()
    {
        var dynList = new DynamicList<string>();
        int actualIndex = dynList.Remove("Test");
        int expectedIndex = 0;

        Assert.AreNotEqual(expectedIndex, actualIndex);
    }

    [Test]
    public void RemoveAtShouldReturnItemWhenGiveIndexExists()
    {
        var dynList = new DynamicList<string>();
        dynList.Add("Test");
        string expectedString = "Test";
        string actualString = dynList.RemoveAt(0);

        Assert.AreEqual(expectedString, actualString);
    }

    [Test]
    public void RemoveAtShouldThrowExceptionWhenRemovingItemAtNonExistingItem()
    {
        var dynList = new DynamicList<string>();

        Assert.That(() => dynList.RemoveAt(0), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }
}