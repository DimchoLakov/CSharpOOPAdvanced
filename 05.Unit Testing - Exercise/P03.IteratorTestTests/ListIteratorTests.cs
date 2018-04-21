using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

public class ListIteratorTests
{
    [Test]
    public void TestValidConstructor()
    {
        var initialValues = new string[] { "Pesho", "Gosho" };

        var listIterator = new ListIterator(initialValues);

        FieldInfo fieldInfo = typeof(ListIterator)
            .GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .First(f => f.FieldType == typeof(List<string>));

        var actualValues = (List<string>)fieldInfo.GetValue(listIterator);

        Assert.That(initialValues, Is.EquivalentTo(actualValues));
    }

    [Test]
    public void ConstructorShouldThrowExceptionWhenNullIsGivenAsArgument()
    {
        Assert.That(() => new ListIterator(null), Throws.ArgumentNullException);
    }

    [Test]
    public void MoveMethodShouldReturnTrueWhenIndexIsSmallerThanListSize()
    {
        Type typeOfListIterator = typeof(ListIterator);

        ListIterator listIterator = (ListIterator)Activator
            .CreateInstance(typeOfListIterator, new object[] { "Gosho", "Pesho" });

        MethodInfo moveMethod = typeOfListIterator
            .GetMethod("Move", BindingFlags.Instance | BindingFlags.Public);

        bool result = (bool)moveMethod.Invoke(listIterator, new object[] { });

        Assert.That(result == true);
    }

    [Test]
    public void MoveMethodShouldReturnFalseWhenIndexIsBiggerThanListSize()
    {
        Type typeOfListIterator = typeof(ListIterator);

        ListIterator listIterator =
            (ListIterator)Activator.CreateInstance(typeOfListIterator, new object[] { });

        MethodInfo indexMethod = typeOfListIterator
            .GetMethod("set_Index", BindingFlags.NonPublic | BindingFlags.Instance);

        int indexValue = 5;
        indexMethod.Invoke(listIterator, new object[] { indexValue });

        MethodInfo moveMethod = typeOfListIterator
            .GetMethod("Move", BindingFlags.Public | BindingFlags.Instance);

        bool result = (bool)moveMethod.Invoke(listIterator, new object[] { });

        Assert.That(result == false);
    }

    [Test]
    public void HasNextMethodShouldReturnTrueWhenIndexIsSmallerThanListSize()
    {
        Type typeOfListIterator = typeof(ListIterator);

        var instance = Activator
            .CreateInstance(typeOfListIterator, new object[] { "Gosho", "Pesho" });

        MethodInfo hasNextMethodInfo = typeOfListIterator
            .GetMethod("HasNext", BindingFlags.Public | BindingFlags.Instance);

        bool result = (bool)hasNextMethodInfo.Invoke(instance, null);

        Assert.That(result == true);
    }

    [Test]
    public void HasNextMethodShouldReturnFalseWhenIndexIsTheLastIndex()
    {
        Type typeOfListIterator = typeof(ListIterator);

        var instance = Activator
            .CreateInstance(typeOfListIterator, new object[] { "Gosho", "Pesho" });

        FieldInfo iteratorListFieldInfo = typeOfListIterator
            .GetField("iteratorList", BindingFlags.NonPublic | BindingFlags.Instance);

        var iteratorList = (List<string>)iteratorListFieldInfo.GetValue(instance);
        var iteratorListCount = iteratorList.Count;

        PropertyInfo indexPropertyInfo = typeOfListIterator
            .GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);

        var lastIndex = iteratorListCount - 1;

        indexPropertyInfo.SetValue(instance, lastIndex);

        MethodInfo hasNextMethodInfo = typeOfListIterator
            .GetMethod("HasNext", BindingFlags.Instance | BindingFlags.Public);

        var result = (bool)hasNextMethodInfo.Invoke(instance, null);

        Assert.That(result == false);
    }

    [Test]
    public void TestInvalidPrintMethod()
    {
        Type typeOfListIterator = typeof(ListIterator);

        var instance = (ListIterator)Activator
            .CreateInstance(typeOfListIterator, new object[] { });

        Assert.That(() => instance.Print(), Throws.InvalidOperationException);
    }

    [Test]
    public void PrintMethodShouldThrowExceptionWhenIndexIsLessThanZero()
    {
        Type typeOfListIterator = typeof(ListIterator);

        var instance = (ListIterator)Activator
            .CreateInstance(typeOfListIterator, new object[] { "Pesho", "Gosho" });

        PropertyInfo indexPropertyInfo = typeOfListIterator
            .GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);

        int negativeIndex = -5;

        indexPropertyInfo.SetValue(instance, negativeIndex);

        Assert.That(() => instance.Print(), Throws.InvalidOperationException);
    }

    [Test]
    public void PrintMethodShouldThrowExceptionWhenIndexIsBiggerThanListSize()
    {
        Type typeOfListIterator = typeof(ListIterator);

        var instance = (ListIterator)Activator
            .CreateInstance(typeOfListIterator, new object[] { "Pesho", "Gosho" });

        PropertyInfo indexPropertyInfo = typeOfListIterator
            .GetProperty("Index", BindingFlags.Instance | BindingFlags.NonPublic);

        FieldInfo listFieldInfo = typeOfListIterator
            .GetField("iteratorList", BindingFlags.Instance | BindingFlags.NonPublic);

        int listCount = ((List<string>)listFieldInfo.GetValue(instance)).Count;

        int index = listCount + 1;

        indexPropertyInfo.SetValue(instance, index);

        Assert.That(() => instance.Print(), Throws.InvalidOperationException);
    }
}