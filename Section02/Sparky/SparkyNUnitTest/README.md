# NUnit #

Nuget packages for the project:

- [NUnit](https://www.nuget.org/packages/NUnit/)
- [NUnit3TestAdapter](https://www.nuget.org/packages/NUnit3TestAdapter/)
- [Microsoft.NET.Test.Sdk](https://www.nuget.org/packages/Microsoft.NET.Test.Sdk/)

NUnit project namespace:

Change it to the same namespace of tha tested project, on NUnit project
properties.

Test class example:

```csharp
[TestFixture]
public class CalculatorNUnitTests
{
    [Test]
    public void AddNumbers_InputTwoInt_GetCorrectAddition()
    {
        // Arrange (Test initialization)
        Calculator calc = new Calculator();

        // Act (Invoking needed methods)
        int result = calc.AddNumbers(10, 20);

        // Assert (Checking the results)
        Assert.AreEqual(30, result);
    }
}
```

Naming a test class:
`<nameOfTheClassToBeTested>Tests`

- Defining a test class with: `[TestFixture]`
- Defining a test method with: `[Test]`

Naming a test method:
`<nameOfTheMethodToBeTested>_<typesAndAmountOfParameters>_<descriptiveExpectedResult>`

## NUnit Assertion Model ##

### Classic Model ###

The classic Assert model uses a separate method to express each individual
assertion of which it is capable.

- `Assert.AreEqual(30, result)` if the value and the return are equal
- `Assert.IsTrue(result)` for booleans

### Constraint Model (Assert.That) ###

The constraint-based Assert model uses a single method of the Assert class for
all assertions. The logic necessary to carry out each assertion is embedded in
the constraint object passed as the second parameter to that method.

- `Assert.That(30, Is.EqualTo(result))`
- `Assert.That(result, Is.False)`

## Passing values to tests parameters ##

Example method:

```csharp
[Test]
[TestCase(21)]
[TestCase(19)]
public void IsOddNumber_InputOddNumber_ReturnTrue(int num)
{
    // Arrange (Test initialization)
    Calculator calc = new Calculator();

    // Act (Invoking needed methods)
    var result = calc.IsOddNumber(num);

    // Assert (Checking the results)
    Assert.IsTrue(result);
}
```

Defining the value of the parameter:
`[TestCase(21)]`

For multiple parameters:
`[TestCase(21, true)]`
or:
`[TestCase(19.52, "string")]`

Notice that it can be used multiple times.

## Checking expected result ##

Example method:

```csharp
[Test]
[TestCase(20, ExpectedResult = false)]
[TestCase(19, ExpectedResult = true)]
public bool IsOddNumber_InputNumber_ReturnTrueIffOdd(int num)
{
    Calculator calc = new Calculator();
    return calc.IsOddNumber(num);
}
```

Defining the parameter value and the expected result of the test:
`[TestCase(20, ExpectedResult = false)]`

## Global initialization for Class ##

Example class:

```csharp
[TestFixture]
public class CustomerNUnitTests
{
    private Customer _customer;

    [SetUp]
    public void Setup()
    {
        this._customer = new Customer();
    }

    [Test]
    public void GreetAndCombineName_InputFirstAndLastName_ReturnFullName()
    {
        // Arrange

        // Act
        string fullName = this._customer.GreetAndCombineNames("Ben", "Spark");

        // Assert
        Assert.AreEqual("Hello, Ben Spark", this._customer.GreetMessage);
        Assert.That(this._customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
        Assert.That(this._customer.GreetMessage, Does.Contain("Hello,")); // Case sensitive
        Assert.That(this._customer.GreetMessage, Does.Contain("hello,").IgnoreCase);
        Assert.That(this._customer.GreetMessage, Does.StartWith("Hello")); // Case sensitive
        Assert.That(this._customer.GreetMessage, Does.EndWith("Spark")); // Case sensitive
        Assert.That(this._customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
    }

    [Test]
    public void GreetMessage_NotGreeted_ReturnNull()
    {
        // Arrange

        // Act

        // Assert
        Assert.IsNull(this._customer.GreetMessage);
    }
}
```

Defining a SetUp method (act as a Constructor-ish):

```csharp
private <Class> _<field>;

[SetUp]
public void Setup()
{
    ...
}
```


## Mocking ##

Isolation of a class to test it, replacing its dependecies with fake ones.

An object under test may have dependencies on other objects. Mocking is replacing
the actual dependency, with a test time only version that enables easier
isolation of code that we want to test.

Different mocking frameworks:

- [MOQ](https://github.com/moq/moq4)
- [NMock3](https://www.nuget.org/packages/NMock3/)
- [FakeItEasy](https://fakeiteasy.github.io/)
- [NSubstitute](https://nsubstitute.github.io/)