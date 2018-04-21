using System;
using System.Linq;
using System.Reflection;
using NUnit.Framework;

[TestFixture]
public class DatabaseTests
{
    [Test]
    public void FindByIdShouldThrowExceptionWhenNoUserWithGivenIdIsFound()
    {
        var person = new Person("Pesho", 5);

        var db = new Database(person);

        var idToLookFor = 6;

        Assert.That(() => db.FindById(idToLookFor), Throws.InvalidOperationException);
    }

    [Test]
    public void FindByIdShouldThrowExceptionWhenGivenIdIsNegative()
    {
        var person = new Person("Pesho", -5);

        var db = new Database(person);

        var negativeId = person.Id;

        Assert.That(() => db.FindById(negativeId), Throws.InstanceOf<ArgumentOutOfRangeException>());
    }

    [Test]
    public void FindByUsernameShouldThrowExceptionWhenNoUserWithGivenUsernameIsFound()
    {
        var db = new Database(new Person("Pesho", 1));

        var notExistingName = "Gosho";

        Assert.That(() => db.FindByName(notExistingName), Throws.InvalidOperationException.With.Message.EqualTo($"No person with name {notExistingName} is found!"));
    }

    [Test]
    public void FindByUsernameShouldThrowExceptionWhenUsernameIsNull()
    {
        var person = new Person("Gosho", 1);

        var db = new Database(person);

        string username = null;

        Assert.That(() => db.FindByName(username), Throws.ArgumentNullException);
    }

    [Test]
    public void AddMethodShoudlThrowExceptionWhenAddPersonWithSameNameOrSameId()
    {
        var person = new Person("Pesho", 1);

        var db = new Database(person);

        var newPersonWithSameName = new Person("Pesho", 2);

        Assert.That(() => db.Add(newPersonWithSameName), Throws.InvalidOperationException.With.Message.EqualTo($"Person with name {newPersonWithSameName.Name} already exists!"));

        var newPersonWithSameId = new Person("Gosho", 1);
        Assert.That(() => db.Add(newPersonWithSameId), Throws.InvalidOperationException.With.Message.EqualTo($"Person with name {newPersonWithSameId.Id} already exists!"));
    }

    [Test]
    public void AddMethodShouldThrowExceptionWhenAddMoreThan16Elements()
    {
        var people = new Person[16];

        var database = new Database(people);

        Assert.That(() => database.Add(new Person("Gosho", 200)), Throws.InvalidOperationException);
    }

    [Test]
    public void AddMethodShouldAddOnePersonAtTime()
    {
        var people = new Person[]
        {
                new Person("Pesho", 10),
                new Person("Gosho", 20)
        };

        var db = new Database(people);

        FieldInfo fieldInfo = typeof(Database)
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(f => f.FieldType == typeof(Person[]));

        var peopleArr = (Person[])fieldInfo.GetValue(db);

        int initialCount = peopleArr.Count(p => p != null);

        db.Add(new Person("Ivan", 30));

        int finalCount = peopleArr.Count(p => p != null);


        Assert.That(initialCount, Is.LessThan(finalCount));
    }

    [Test]
    public void RemoveMethodShouldThrowExceptionWhenThereIsNoElements()
    {
        var database = new Database();

        Assert.That(() => database.Remove(), Throws.InvalidOperationException);
    }

    [Test]
    public void TestValidConstructorMethod()
    {
        var expectedValues = new Person[]
        {
                new Person("A", 1),
                new Person("B", 2),
                new Person("C", 3),
                new Person("D", 4),
                new Person("E", 5),
        };

        var db = new Database(expectedValues);

        Type databaseType = typeof(Database);

        FieldInfo fieldInfo = databaseType
            .GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
            .First(ft => ft.FieldType == typeof(Person[]));

        Person[] actualValues = ((Person[])fieldInfo.GetValue(db)).Take(expectedValues.Length).ToArray();

        Assert.That(expectedValues, Is.EquivalentTo(actualValues));
    }

    [Test]
    public void TestInvalidConstructorMethod()
    {
        Person[] arr = new Person[17];

        Assert.That(() => new Database(arr), Throws.InvalidOperationException);
    }

    [Test]
    public void TestFetchMethod()
    {
        Person[] numbers = new Person[]
        {
                new Person("A", 1),
                new Person("B", 2),
                new Person("C", 3),
                new Person("D", 4),
                new Person("E", 5),
        };

        var db = new Database(numbers);

        //Type databaseType = typeof(Database);

        //MethodInfo fetchMethodInfo = databaseType
        //    .GetMethods(BindingFlags.Public | BindingFlags.Instance)
        //    .First(m => m.ReturnType == typeof(Person[]));

        //Person[] result = (Person[])fetchMethodInfo.Invoke(db, null);

        Person[] result = db.Fetch();

        Assert.That(result, Is.EquivalentTo(numbers));
    }
}