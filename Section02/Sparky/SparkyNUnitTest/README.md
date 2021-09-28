# NUnit #

Nuget packages for the project:

- NUnit
- NUnit3TestAdapter
- Microsoft.NET.Test.Sdk

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
