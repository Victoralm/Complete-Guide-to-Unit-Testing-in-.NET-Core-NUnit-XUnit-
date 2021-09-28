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
