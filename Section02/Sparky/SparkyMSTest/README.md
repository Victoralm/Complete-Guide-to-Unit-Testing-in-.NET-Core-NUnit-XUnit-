# MSTest #

Test class example:

```csharp
[TestClass]
public class CalculatorMSTests
{
    [TestMethod]
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

- Defining a test class with: `[TestClass]`
- Defining a test method with: `[TestMethod]`

Naming a test method:
`<nameOfTheMethodToBeTested>_<typesAndAmountOfParameters>_<descriptiveExpectedResult>`
