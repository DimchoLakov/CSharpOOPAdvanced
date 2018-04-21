using System;
using Moq;
using NUnit.Framework;

public class MathTests
{
    [Test]
    public void MathAbsMethodShouldReturnAbsoluteValue()
    {
        Mock<Calculate> math = new Mock<Calculate>();

        decimal negativeValue = -10m;
        decimal result = 10m;
        
        Assert.AreEqual(math.Object.Abs(negativeValue), result);
    }

    [Test]
    public void MathFloorMethodShouldReturnLargerIntegerLessThanOrEqualGivenDecimal()
    {
        Mock<Calculate> math = new Mock<Calculate>();

        decimal someNumber = 5.8421m;
        decimal result = 5m;

        Assert.AreEqual(math.Object.Floor(someNumber), result);
    }
}